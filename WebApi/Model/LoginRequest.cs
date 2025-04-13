using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApi.Model
{
    public class LoginRequest
    {
        /// <summary>
        /// user
        /// </summary>
        /// <example>admin</example>
        [Required]
        [JsonPropertyName("user")]
        public string user { get; set; }

        /// <summary>
        /// pass
        /// </summary>
        /// <example>0000</example>
        [Required]
        [JsonPropertyName("pass")]
        public string pass { get; set; }
    }
}
