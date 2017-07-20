﻿using Net.Chdk.Model.Software;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Chimp.Providers.Software
{
    sealed class ChdkSoftwareProvider : SoftwareProvider
    {
        public ChdkSoftwareProvider(SoftwareSourceInfo source, CultureInfo language)
            : base(source, language)
        {
        }

        protected override string CategoryName => "PS";

        protected override string ProductName => "CHDK";

        protected override Version GetVersion(Match match)
        {
            var version = match.Groups["version"].Value;
            var build = match.Groups["build"].Value;
            return Version.Parse($"{version}.{build}");
        }
    }
}
