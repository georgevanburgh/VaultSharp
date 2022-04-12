using System.Collections.Generic;
using Newtonsoft.Json;

namespace VaultSharp.V1.AuthMethods.AppRole.Models
{
    public class AppRoleSecretConfig
    {
        [JsonProperty("metadata")]
        public Dictionary<string, string> Metadata { get; set; }

        [JsonProperty("cidr_list")]
        public List<string> CidrUsageAllowList { get; set; }

        [JsonProperty("token_bound_cidrs")]
        public string CidrTokenBindList { get; set; }
    }
}