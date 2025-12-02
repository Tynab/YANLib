namespace YANLib;

public static class BaseErrorCodes
{
    public const string BAD_REQUEST = "YANLib:00400";
    public const string BAD_REQUEST_ID = "YANLib:00410";
    public const string BAD_REQUEST_NAME = "YANLib:00420";
    public const string BAD_REQUEST_TYPE = "YANLib:00430";

    public const string BUSINESS_ERROR = "YANLib:00403";
    public const string EXIST_ID = "YANLib:00413";
    public const string EXIST_NAME = "YANLib:00423";

    public const string NOT_FOUND = "YANLib:00404";
    public const string NOT_FOUND_ID = "YANLib:00414";
    public const string NOT_FOUND_NAME = "YANLib:00424";

    public const string INTERNAL_SERVER_ERROR = "YANLib:00500";
    public const string SQL_SERVER_ERROR = "YANLib:00510";
    public const string ES_SERVER_ERROR = "YANLib:00520";
    public const string REDIS_SERVER_ERROR = "YANLib:00530";
    public const string MQ_SERVER_ERROR = "YANLib:00540";
}
