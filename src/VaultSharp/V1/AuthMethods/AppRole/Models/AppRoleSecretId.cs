using Newtonsoft.Json;

namespace VaultSharp.V1.AuthMethods.AppRole.Models
{
    public class AppRoleSecretId
    {
        [JsonProperty("secret_id_accessor")]
        public string SecretAccessor { get; set; }

        [JsonProperty("secret_id")]
        public string SecretId { get; set; }

        [JsonProperty("secret_id_ttl")]
        public string SecretIdTimeToLive { get; set; }
    }
}