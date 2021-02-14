﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.Server.Installation
{
    public partial interface IInstallationService
    {
        /// <summary>
        /// Install required data
        /// </summary>
        /// <param name="defaultUserEmail">Default user email</param>
        /// <param name="defaultUserPassword">Default user password</param>
        /// <param name="languagePackDownloadLink">Language pack download link</param>
        /// <param name="regionInfo">RegionInfo</param>
        /// <param name="cultureInfo">CultureInfo</param>
        Task InstallRequiredDataAsync(string defaultUserEmail, string defaultUserPassword,
            string languagePackDownloadLink, RegionInfo regionInfo, CultureInfo cultureInfo);

        /// <summary>
        /// Install sample data
        /// </summary>
        /// <param name="defaultUserEmail">Default user email</param>
        Task InstallSampleDataAsync(string defaultUserEmail);
    }
}
