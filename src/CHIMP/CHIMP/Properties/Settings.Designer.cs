﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Chimp.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.1.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("sha256")]
        public string HashAlgorithm {
            get {
                return ((string)(this["HashAlgorithm"]));
            }
            set {
                this["HashAlgorithm"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("4096")]
        public int ExtractBufferSize {
            get {
                return ((int)(this["ExtractBufferSize"]));
            }
            set {
                this["ExtractBufferSize"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("8192")]
        public int DownloadBufferSize {
            get {
                return ((int)(this["DownloadBufferSize"]));
            }
            set {
                this["DownloadBufferSize"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("100")]
        public int VolumeLockDelay {
            get {
                return ((int)(this["VolumeLockDelay"]));
            }
            set {
                this["VolumeLockDelay"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("100")]
        public int VolumeLockRetryCount {
            get {
                return ((int)(this["VolumeLockRetryCount"]));
            }
            set {
                this["VolumeLockRetryCount"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("500")]
        public int VolumeEjectDelay {
            get {
                return ((int)(this["VolumeEjectDelay"]));
            }
            set {
                this["VolumeEjectDelay"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("2")]
        public int VolumeSmallSizeMB {
            get {
                return ((int)(this["VolumeSmallSizeMB"]));
            }
            set {
                this["VolumeSmallSizeMB"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("CANON_SMALL")]
        public string VolumeSmallLabel {
            get {
                return ((string)(this["VolumeSmallLabel"]));
            }
            set {
                this["VolumeSmallLabel"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("CANON_LARGE")]
        public string VolumeLargeLabel {
            get {
                return ((string)(this["VolumeLargeLabel"]));
            }
            set {
                this["VolumeLargeLabel"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("CANON_DC")]
        public string VolumeLabel {
            get {
                return ((string)(this["VolumeLabel"]));
            }
            set {
                this["VolumeLabel"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool SkipIntroStep {
            get {
                return ((bool)(this["SkipIntroStep"]));
            }
            set {
                this["SkipIntroStep"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool SkipLicensesStep {
            get {
                return ((bool)(this["SkipLicensesStep"]));
            }
            set {
                this["SkipLicensesStep"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool SkipCardStep {
            get {
                return ((bool)(this["SkipCardStep"]));
            }
            set {
                this["SkipCardStep"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool SkipSoftwareStep {
            get {
                return ((bool)(this["SkipSoftwareStep"]));
            }
            set {
                this["SkipSoftwareStep"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool SkipCameraStep {
            get {
                return ((bool)(this["SkipCameraStep"]));
            }
            set {
                this["SkipCameraStep"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool SkipActionStep {
            get {
                return ((bool)(this["SkipActionStep"]));
            }
            set {
                this["SkipActionStep"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool SkipDownloadStep {
            get {
                return ((bool)(this["SkipDownloadStep"]));
            }
            set {
                this["SkipDownloadStep"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool SkipInstallStep {
            get {
                return ((bool)(this["SkipInstallStep"]));
            }
            set {
                this["SkipInstallStep"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool SkipEjectStep {
            get {
                return ((bool)(this["SkipEjectStep"]));
            }
            set {
                this["SkipEjectStep"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool SkipSummaryStep {
            get {
                return ((bool)(this["SkipSummaryStep"]));
            }
            set {
                this["SkipSummaryStep"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("10000")]
        public int ToastMaxDuration {
            get {
                return ((int)(this["ToastMaxDuration"]));
            }
            set {
                this["ToastMaxDuration"] = value;
            }
        }
    }
}
