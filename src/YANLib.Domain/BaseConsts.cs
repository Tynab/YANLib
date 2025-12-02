namespace YANLib;

public static class BaseConsts
{
    public const string DbTablePrefix = "App";

    public readonly struct DbSchema
    {
        public const string Sample = "smp";
    }

    public readonly struct ConnectionStringName
    {
        public const string Default = "Default";
    }

    public readonly struct RedisConstant
    {
        public const string KeyCommand = "KEYS";

        public const string SAMPLE_GROUP = "eoe:yanlib:sample";
    }

    public readonly struct EsIndex
    {
        public const string Sample = "Elasticsearch:Indices:Sample";
    }

    public readonly struct RabbitMQTopic
    {
        public const string EOE_YANLIB_SAMPLE = "eoe.yanlib.sample";
    }
}
