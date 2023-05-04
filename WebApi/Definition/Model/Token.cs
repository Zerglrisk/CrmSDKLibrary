using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WebApi_ADAL.Definition.Model
{
    /// <summary>
    /// Authentication Token Response Model
    /// <see href="https://learn.microsoft.com/en-us/azure/active-directory/develop/v2-oauth-ropc"/>
    /// </summary>
    public class Token
    {
        /// <summary>
        /// Always set to Bearer.
        /// </summary> 
        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }

        /// <summary>
        /// If an access token was returned, this parameter lists the scopes the access token is valid for.
        /// </summary>
        [JsonPropertyName("scope")]
        public string Scope { get; set; }

        /// <summary>
        /// Number of seconds that the included access token is valid for.
        /// The length of time the access token is valid (in seconds).
        /// </summary>
        [JsonPropertyName("expires_in")]
        public long? ExpiresIn { get; set; }

        /// <summary>
        /// seconds
        /// </summary>
        [JsonPropertyName("ext_expires_in")]
        public long? ExtExpiresIn { get; set; }

        /// <summary>
        /// The time when the access token expires. The date is represented as the number of seconds from 1970-01-01T0:0:0Z UTC until the expiration time. This value is used to determine the lifetime of cached tokens.
        /// </summary>
        [JsonPropertyName("expires_on")]
        public long? ExpiresOn { get; set; }

        [JsonIgnore]
        public DateTime? ExpiresOnDateTime { get { return this.ExpiresOn.HasValue ? DateTimeOffset.FromUnixTimeSeconds(this.ExpiresOn.Value).LocalDateTime : default; } }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("not_before")]
        public long? NotBefore { get; set; }

        [JsonIgnore]
        public DateTime? NotBeforeDateTime { get { return this.ExpiresOn.HasValue ? DateTimeOffset.FromUnixTimeSeconds(this.ExpiresOn.Value).LocalDateTime : default; } }

        /// <summary>
        /// The app ID URI of the receiving service (secured resource).
        /// </summary>
        [JsonPropertyName("resource")]
        public string Resource { get; set; }

        /// <summary>
        /// Issued for the scopes that were requested.
        /// </summary>
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// Issued if the original scope parameter included offline_access.
        /// </summary>
        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }
    }
}
