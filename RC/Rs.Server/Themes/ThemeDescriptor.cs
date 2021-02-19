using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Rs.Server.Themes
{
    public class ThemeDescriptor: IDescriptor
    {
        /// <summary>
        /// Gets or sets the theme system name
        /// </summary>
        [JsonPropertyName("SystemName")]
        public string SystemName { get; set; }

        /// <summary>
        /// Gets or sets the theme friendly name
        /// </summary>
        [JsonPropertyName("FriendlyName")]
        public string FriendlyName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the theme supports RTL (right-to-left)
        /// </summary>
        [JsonPropertyName("SupportRTL")]
        public bool SupportRtl { get; set; }

        /// <summary>
        /// Gets or sets the path to the preview image of the theme
        /// </summary>
        [JsonPropertyName("PreviewImageUrl")]
        public string PreviewImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the preview text of the theme
        /// </summary>
        [JsonPropertyName("PreviewText")]
        public string PreviewText { get; set; }
    }
}