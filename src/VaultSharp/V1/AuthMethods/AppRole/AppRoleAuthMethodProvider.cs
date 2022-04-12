using System.Net.Http;
using System.Threading.Tasks;
using VaultSharp.Core;
using VaultSharp.V1.AuthMethods.AppRole.Models;
using VaultSharp.V1.Commons;

namespace VaultSharp.V1.AuthMethods.AppRole
{
    internal class AppRoleAuthMethodProvider : IAppRoleAuthMethod
    {
        private readonly Polymath _polymath;

        public AppRoleAuthMethodProvider(Polymath polymath)
        {
            Checker.NotNull(polymath, "polymath");
            this._polymath = polymath;
        }

        public async Task<Secret<AppRoleInfo>> ReadRoleAsync(string roleName, string mountPoint = AuthMethodDefaultPaths.AppRole)
        {
            Checker.NotNull(mountPoint, "mountPoint");
            Checker.NotNull(roleName, "roleName");
            return await _polymath.MakeVaultApiRequest<Secret<AppRoleInfo>>("v1/auth/"+ mountPoint.Trim('/')+"/role/"+roleName.Trim('/'), HttpMethod.Get).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }

        public async Task<Secret<AppRoleSecretId>> CreateSecretIdAsync(string roleName, AppRoleSecretConfig request, string mountPoint = "approle")
        {
            Checker.NotNull(roleName, nameof(roleName));
            Checker.NotNull(request, nameof(request));
            Checker.NotNull(mountPoint, nameof(mountPoint));

            var mountPointTrimmed = mountPoint.Trim('/');
            var roleNameTrimmed = roleName.Trim('/');
            return await _polymath.MakeVaultApiRequest<Secret<AppRoleSecretId>>($"v1/auth/{mountPointTrimmed}/role/{roleNameTrimmed}/secret-id", HttpMethod.Post, request).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }
    }
}
