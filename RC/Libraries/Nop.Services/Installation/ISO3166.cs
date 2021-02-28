using System.Collections.Generic;
using System.Linq;

namespace Nop.Services.Installation
{
    /// <summary>
    /// Represents the implementation of ISO3166-1
    /// </summary>
    /// <remarks>https://en.wikipedia.org/wiki/List_of_ISO_3166_country_codes</remarks>
    public static class ISO3166
    {
        /// <summary>
        /// Obtain ISO3166-1 Country based on its ISO code.
        /// </summary>
        /// <param name="codeISO"></param>
        /// <returns>ISO3166Country</returns>
        public static ISO3166Country FromISOCode(int codeISO)
        {
            return GetCollection().FirstOrDefault(p => p.NumericCode == codeISO);
        }

        /// <summary>
        /// Obtain ISO3166-1 Country based on its alpha-2.
        /// </summary>
        /// <param name="countryCode"></param>
        /// <returns>ISO3166Country</returns>
        public static ISO3166Country FromCountryCode(string countryCode)
        {
            return GetCollection().FirstOrDefault(p => p.Alpha2 == countryCode);
        }

        /// <summary>
        /// Collection localization info for country
        /// </summary>
        /// <param name="countryCode"></param>
        /// <returns>IEnumerable<LocalizationInfo></returns>
        public static IEnumerable<LocalizationInfo> GetLocalizationInfo(string countryCode)
        {
            return FromCountryCode(countryCode).LocalizationInfo;
        }

        #region Collection of counties
        /// <summary>
        /// Collection of standard defining codes for the names of countries by ISO 3166-1
        /// </summary>
        /// <returns>IEnumerable<ISO3166Country></returns>
        public static IEnumerable<ISO3166Country> GetCollection()
        {
            // This collection built from Wikipedia entry on ISO3166-1 on 8th Dec 2020
            return new[] {
                new ISO3166Country("China", "CN", "CHN", 156, new[] { "86" }, localizationInfo: new[] { new LocalizationInfo("zh-CN", "Chinese") }),
             };
        }
        #endregion
    }

    /// <summary>
    /// Representation of an ISO3166-1 Country
    /// </summary>
    public class ISO3166Country
    {
        public ISO3166Country(string name, string alpha2, string alpha3, int numericCode, string[] dialCodes = null, bool subjectToVat = false, IEnumerable<LocalizationInfo> localizationInfo = null)
        {
            Name = name;
            Alpha2 = alpha2;
            Alpha3 = alpha3;
            NumericCode = numericCode;
            DialCodes = dialCodes;
            SubjectToVat = subjectToVat;
            LocalizationInfo = localizationInfo ?? (new[] { new LocalizationInfo("zh-CN", "Chinese") });
        }

        /// <summary>
        ///English short name of country
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Two-letter country code
        /// </summary>
        public string Alpha2 { get; private set; }

        /// <summary>
        /// three-letter country code which allow a better visual association between the codes and the country names than the alpha-2 codes
        /// </summary>
        public string Alpha3 { get; private set; }

        /// <summary>
        /// Three-digit country code which are identical to those developed and maintained by the United Nations Statistics Division
        /// </summary>
        public int NumericCode { get; private set; }

        /// <summary>
        /// Phone codes
        /// </summary>
        public string[] DialCodes { get; private set; }

        /// <summary>
        /// Belonging to the European Union
        /// </summary>
        public bool SubjectToVat { get; private set; }

        public IEnumerable<LocalizationInfo> LocalizationInfo { get; private set; }
    }

    public class LocalizationInfo
    {
        public LocalizationInfo(string culture, string language)
        {
            Culture = culture;
            Language = language;
        }

        public string Culture { get; private set; }

        public string Language { get; private set; }
    }
}
