namespace YANLib;

public static class YANLibDomainErrorCodes
{
    public const string BAD_REQUEST = "YANLib:400";
    public const string BAD_REQUEST_NAME = "YANLib:410";
    public const string BAD_REQUEST_ID_CARD = "YANLib:420";
    public const string BAD_REQUEST_ID = "YANLib:430";
    public const string BAD_REQUEST_GPA = "YANLib:440";
    public const string BAD_REQUEST_DEV_ID = "YANLib:450";
    public const string BAD_REQUEST_USER_NAME = "YANLib:460";
    public const string BAD_REQUEST_PWD = "YANLib:470";

    public const string BUSINESS_ERROR = "YANLib:403";
    public const string EXIST_ID = "YANLib:413";
    public const string EXIST_ID_CARD = "YANLib:423";

    public const string NOT_FOUND = "YANLib:404";
    public const string NOT_FOUND_CERT = "YANLib:434";
    public const string NOT_FOUND_DEV_CERT = "YANLib:444";

    public const string INTERNAL_SERVER_ERROR = "YANLib:500";
    public const string SQL_SERVER_ERROR = "YANLib:501";
    public const string ELASTICSEARCH_SERVER_ERROR = "YANLib:502";
    public const string REDIS_SERVER_ERROR = "YANLib:503";
}
