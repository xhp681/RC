using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Rs.Server
{
    public partial class CaptchaResponse
    {
        public CaptchaResponse()
        {
            Errors = new List<string>();
        }

        /// <summary>
        /// Gets or sets the action name for this request (important to verify)
        /// </summary>
        [JsonPropertyName("action")]

        public string Action { get; set; }

        [JsonPropertyName("score")]
        public decimal Score { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether validation is success
        /// </summary>
        [JsonPropertyName("success")]
        public bool IsValid { get; set; }

        /// <summary>
        /// Gets or sets a date and time of the challenge load
        /// </summary>
        [JsonPropertyName("challenge_ts")]
        public DateTime? ChallengeDateTime { get; set; }

        /// <summary>
        /// Gets or sets the hostname of the site where the reCAPTCHA was solved
        /// </summary>
        [JsonPropertyName("hostname")]
        public string Hostname { get; set; }

        /// <summary>
        /// Gets or sets errors
        /// </summary>
        [JsonPropertyName("error-codes")]
        public List<string> Errors { get; set; }
    }
}