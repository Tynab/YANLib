using Amazon;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text.Json;
using Volo.Abp;
using Volo.Abp.Modularity;
using YANLib.ConnectionFactories;
using YANLib.Core;
using YANLib.Services;
using YANLib.Services.Implements;

namespace YANLib;

[DependsOn(
    typeof(YANLibApplicationContractsModule),
    typeof(YANLibDomainModule)
)]
public class YANLibApplicationRedisModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();

        Configure<RedisOptions>(o => o.RedisConnectionString = configuration["Redis:Configuration"]);
        Cc();
        _ = context.Services.AddSingleton(typeof(IRedisService<>), typeof(RedisService<>));
    }

    public override void OnApplicationShutdown(ApplicationShutdownContext context) => context.ServiceProvider.GetRequiredService<IRedisConnectionFactory>().Connection().CloseAsync();

    private void Cc()
    {
        //var config = new AmazonSecretsManagerConfig
        //{
        //    RegionEndpoint = RegionEndpoint.APSoutheast1
        //};

        //var credentials = new StoredProfileAWSCredentials("Tynab");
        //var client = new AmazonSecretsManagerClient(credentials, config);

        var netSdkFile = new SharedCredentialsFile();

        if (netSdkFile.TryGetProfile("Tynab", out var profile) && AWSCredentialsFactory.TryGetAWSCredentials(profile, netSdkFile, out var credentials))
        {
            var client = new AmazonSecretsManagerClient(credentials, RegionEndpoint.APSoutheast1);
            var request = new GetSecretValueRequest
            {
                SecretId = "local/yanlib/appsettings",
            };

            var response = client.GetSecretValueAsync(request).Result;
            var secret = response.SecretString;
            var secretData = JsonSerializer.Deserialize<Dictionary<string, string>>(secret);

            // Duyệt qua tất cả các cặp key-value trong secret
            foreach (var kvp in secretData)
            {
                Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }

            // Lấy giá trị của một key cụ thể, ví dụ "mongo-default"
            if (secretData.TryGetValue("mssql-default", out string mongoConnectionString))
            {
                Console.WriteLine("MongoDB Connection String: " + mongoConnectionString);
            }
            else
            {
                Console.WriteLine("Không tìm thấy key 'mongo-default'");
            }
        }
        else
        {
            //Console.WriteLine("Không tìm thấy profile hoặc không thể lấy credentials.");
        }
    }
}
