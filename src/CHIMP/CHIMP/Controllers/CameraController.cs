﻿using Chimp.Properties;
using Chimp.ViewModels;
using Microsoft.Extensions.Logging;
using Net.Chdk.Detectors.Camera;
using Net.Chdk.Detectors.CameraModel;
using Net.Chdk.Model.Camera;
using Net.Chdk.Model.CameraModel;
using Net.Chdk.Providers.Camera;
using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chimp.Controllers
{
    sealed class CameraController : Controller<CameraController, CameraViewModel>
    {
        protected override bool CanSkipStep =>
            ViewModel.SelectedItem != null
            && SoftwareViewModel.SelectedItem?.Info?.Product?.Version?.MinorRevision >= 0;

        private ICameraModelDetector CameraModelDetector { get; }
        private IFileCameraModelDetector FileCameraModelDetector { get; }
        private ICameraProvider CameraProvider { get; }
        private IDialogService DialogService { get; }

        public CameraController(ICameraModelDetector cameraModelDetector, IFileCameraModelDetector fileCameraModelDetector, ICameraProvider cameraProvider, IDialogService dialogService,
            MainViewModel mainViewModel, IStepProvider stepProvider, string stepName, ILoggerFactory loggerFactory)
            : base(mainViewModel, stepProvider, stepName, loggerFactory)
        {
            CameraModelDetector = cameraModelDetector;
            FileCameraModelDetector = fileCameraModelDetector;
            CameraProvider = cameraProvider;
            DialogService = dialogService;
        }

        protected override void Initialize()
        {
            base.Initialize();
            Subscribe();
        }

        public override void Dispose()
        {
            base.Dispose();
            Unsubscribe();
        }

        protected override void EnterStep()
        {
            if (ViewModel == null)
                ViewModel = CreateViewModel();
            Subscribe2();
            UpdateCanContinue();
            UpdateIsPaused();
        }

        protected override void LeaveStep()
        {
            base.LeaveStep();
            Unsubscribe2();
        }

        private void Subscribe2()
        {
            if (ViewModel != null)
                ViewModel.PropertyChanged += SelectedItemChanged;
        }

        private void Unsubscribe2()
        {
            if (ViewModel != null)
                ViewModel.PropertyChanged -= SelectedItemChanged;
        }

        private void UpdateCanContinue()
        {
            StepViewModel.CanContinue = ViewModel?.SelectedItem != null;
        }

        private void UpdateIsPaused()
        {
            MainViewModel.IsWarning = ViewModel?.SelectedItem == null;
        }

        protected override void Card_SelectedItemChanged()
        {
            ViewModel = null;
        }

        protected override void Software_SelectedItemChanged()
        {
            ViewModel = null;
        }

        private CameraViewModel CreateViewModel()
        {
            var cardInfo = CardViewModel.SelectedItem.Info;
            var softwareInfo = SoftwareViewModel.SelectedItem?.Info;
            var camera = CameraModelDetector.GetCameraModels(cardInfo, softwareInfo, null, default(CancellationToken));
            var viewModel = new CameraViewModel();
            Update(viewModel, camera);
            return viewModel;
        }

        private void SelectedItemChanged(object sender, PropertyChangedEventArgs e)
        {
            if (ViewModel.SelectedItem != null)
                Logger.LogInformation("Selected {0}", ViewModel.SelectedItem.DisplayName);

            UpdateCanContinue();
            UpdateIsPaused();
        }

        public async Task DetectCameraAsync(string path)
        {
            await Task.Run(() => DetectCamera(path))
                .ContinueWith(UpdateCamera, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private CameraModels DetectCamera(string path)
        {
            return FileCameraModelDetector.GetCameraModels(path, null, default(CancellationToken));
        }

        private void UpdateCamera(Task<CameraModels> task)
        {
            if (task.Exception != null)
            {
                if (task.Exception is AggregateException aggregateException)
                {
                    foreach (var ex in aggregateException.InnerExceptions)
                    {
                        if (typeof(CameraDetectionException).IsAssignableFrom(ex.GetType()))
                            DialogService.ShowErrorMessage(ex.Message);
                        else
                            throw ex;
                    }
                }
                else
                {
                    throw task.Exception;
                }
            }
            else
            {
                Update(ViewModel, task.Result);
            }
        }

        private void Update(CameraViewModel viewModel, CameraModels camera)
        {
            Logger.LogObject(LogLevel.Information, "Detected {0}", camera);

            viewModel.IsSelect = false;

            if (camera == null)
            {
                viewModel.Info = null;
                viewModel.Error = Resources.Camera_NoImage_Text;
                viewModel.Items = new CameraItemViewModel[0];
                return;
            }

            viewModel.Info = camera.Info;
            viewModel.Error = GetError(camera);
            if (viewModel.Error != null)
            {
                viewModel.Items = new CameraItemViewModel[0];
                return;
            }

            viewModel.Items = camera.Models
                .Select(m => CreateItem(camera.Info, m))
                .ToArray();

            var cameraModels = CameraProvider.GetCameraModels(camera.Info);
            viewModel.CardType = cameraModels?.CardType;

            if (camera.Models.Length == 1)
            {
                viewModel.SelectedItem = viewModel.Items[0];
                return;
            }

            viewModel.SelectedItem = null;
            viewModel.IsSelect = true;
        }

        private static string GetError(CameraModels camera)
        {
            if (camera.Info == null)
                return null;

            if (camera.Info.Base == null)
                return Resources.Camera_NoMetadata_Text;

            if (!"Canon".Equals(camera.Info.Base.Make, StringComparison.InvariantCulture))
                return Resources.Camera_NonCanon_Text;

            if (camera.Info.Canon == null)
                return Resources.Camera_NoCanonMakernote_Text;

            if (camera.Info.Canon.ModelId == 0)
                return Resources.Camera_NoModelId_Text;

            if (camera.Info.Canon.FirmwareRevision == 0 && camera.Info.Canon.FirmwareVersion == null)
                return Resources.Camera_NoFirmwareRevision_Text;

            if (camera.Models == null)
                return Resources.Camera_UnsupportedModel_Text;

            return null;
        }

        private CameraItemViewModel CreateItem(CameraInfo info, CameraModelInfo model)
        {
            return new CameraItemViewModel
            {
                DisplayName = GetDisplayName(model),
                Model = model,
            };
        }

        private static string GetDisplayName(CameraModelInfo model)
        {
            return string.Join("\n", model.Names);
        }
    }
}
