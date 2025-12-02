namespace YANLib;

public static class BaseErrorMessages
{
    public const string BAD_REQUEST = "Yêu cầu không hợp lệ!";
    public const string BAD_REQUEST_ID = "Id không hợp lệ!";
    public const string BAD_REQUEST_NAME = "Tên không hợp lệ!";
    public const string BAD_REQUEST_TYPE = "Loại không hợp lệ!";

    public const string BUSINESS_ERROR = "Lỗi nghiệp vụ!";
    public const string EXIST_ID = "Id đã tồn tại!";
    public const string EXIST_NAME = "Tên đã tồn tại!";

    public const string NOT_FOUND = "Không tìm thấy!";
    public const string NOT_FOUND_ID = "Không tìm thấy Id!";
    public const string NOT_FOUND_NAME = "Không tìm thấy Tên!";

    public const string INTERNAL_SERVER_ERROR = "Lỗi trong quá trình xử lý!";
    public const string SQL_SERVER_ERROR = "Lỗi trong quá trình xử lý SQL!";
    public const string ES_SERVER_ERROR = "Lỗi trong quá trình xử lý Elasticsearch!";
    public const string REDIS_SERVER_ERROR = "Lỗi trong quá trình xử lý Redis!";
    public const string MQ_SERVER_ERROR = "Lỗi trong quá trình xử lý Message Queue!";
}
