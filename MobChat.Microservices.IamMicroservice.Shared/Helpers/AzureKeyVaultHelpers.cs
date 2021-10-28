// Original file comes from: https://github.com/damienbod/IdentityServer4AspNetCoreIdentityTemplate
// Modified by Jan Škoruba

using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using MobChat.Microservices.IamMicroservice.Shared.Configuration.Common;
using MobChat.Microservices.IamMicroservice.Shared.Services;

namespace MobChat.Microservices.IamMicroservice.Shared.Helpers
{
    public class AzureKeyVaultHelpers
    {
        public static async Task<(X509Certificate2 ActiveCertificate, X509Certificate2 SecondaryCertificate)> GetCertificates(AzureKeyVaultConfiguration certificateConfiguration)
        {
            (X509Certificate2 ActiveCertificate, X509Certificate2 SecondaryCertificate) certs = (null, null);

            if (!string.IsNullOrEmpty(certificateConfiguration.AzureKeyVaultEndpoint))
            {
                var keyVaultCertificateService = new AzureKeyVaultService(certificateConfiguration);

                certs = await keyVaultCertificateService.GetCertificatesFromKeyVault().ConfigureAwait(false);
            }

            return certs;
        }
    }
}





