﻿namespace YANLib;

public static class YANLibConsts
{
    public const string DbTablePrefix = "App";

    public readonly struct ElasticsearchIndex
    {
        public const string Developer = "Elasticsearch:Indices:Developer";
        public const string Project = "Elasticsearch:Indices:Project";
    }

    public readonly struct DbSchema
    {
        public const string Sample = "smp";
    }

    public readonly struct ConnectionStringName
    {
        public const string Default = "Default";
    }

    public readonly struct SnowflakeId
    {
        public readonly struct DatacenterId
        {
            public const int YanlibId = 1;
        }

        public readonly struct WorkerId
        {
            public const int DeveloperId = 1;
        }
    }

    public readonly struct RedisConstant
    {
        public const string KeyCommand = "KEYS";

        public const string YanlibPrefix = "yanlib";
        public const string SamplePrefix = "sample";
        public const string DeveloperTypePrefix = "developertype";
        public const string DeveloperPrefix = "developer";
        public const string ProjectPrefix = "project";

        public const string DeveloperProjectGroupPrefix = $"{YanlibPrefix}:{SamplePrefix}:{DeveloperPrefix}{ProjectPrefix}";

        public const string DeveloperTypeGroup = $"{YanlibPrefix}:{SamplePrefix}:{DeveloperTypePrefix}";
    }

    public readonly struct RemoteService
    {
        public const string EcommerceApi = "EcommerceApi";

        public readonly struct Path
        {
            public const string Login = "login";
            public const string TokenRefresh = "token/refresh";
        }
    }
}
