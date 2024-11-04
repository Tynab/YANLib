using Amazon.Runtime.CredentialManagement;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;
using YANLib.Core;
using static Amazon.RegionEndpoint;
using static Amazon.Runtime.CredentialManagement.AWSCredentialsFactory;
using static Newtonsoft.Json.Linq.JObject;
using static System.Text.Encoding;

namespace YANLib.Utilities;

public static class ConfigurationBuilderExtensions
{
    public static async ValueTask<IConfigurationBuilder> AddConfigFromAws(this IConfigurationBuilder configurationBuilder)
    {
        var profileName = "Tynab";
        var secretId = "dev/yanlib/appsettings";
        var profileSource = new SharedCredentialsFile();

        if (profileSource.TryGetProfile(profileName, out var profile) && TryGetAWSCredentials(profile, profileSource, out var credentials))
        {

            var response = await new AmazonSecretsManagerClient(credentials, APSoutheast1).GetSecretValueAsync(new GetSecretValueRequest
            {
                SecretId = secretId
            });

            if (response.SecretString.IsNotWhiteSpaceAndNull())
            {
                using var memoryStream = new MemoryStream(UTF8.GetBytes(Parse(response.SecretString).ToString()));

                _ = configurationBuilder.AddJsonStream(memoryStream);
            }
        }

        return configurationBuilder;
    }
}

