namespace YANLib;

public static class YANLibDomainErrorMessages
{
    public const string BAD_REQUEST = "Dữ liệu truyền vào không hợp lệ!";
    public const string BAD_REQUEST_NAME = "Tên truyền vào không hợp lệ!";
    public const string BAD_REQUEST_ID_CARD = "Mã định danh truyền vào không hợp lệ!";
    public const string BAD_REQUEST_ID = "Mã truyền vào không hợp lệ!";
    public const string BAD_REQUEST_GPA = "Điểm truyền vào không hợp lệ!";
    public const string BAD_REQUEST_DEV_ID = "Mã hồ sơ lập trình viên truyền vào không hợp lệ!";
    public const string BAD_REQUEST_USER_NAME = "Tên người dùng truyền vào không hợp lệ!";
    public const string BAD_REQUEST_PWD = "Mật khẩu truyền vào không hợp lệ!";

    public const string BUSINESS_ERROR = "Lỗi quy tắc!";
    public const string EXIST_ID = "Mã đã tồn tại!";
    public const string EXIST_ID_CARD = "Mã định danh đã tồn tại!";

    public const string NOT_FOUND = "Không tìm thấy dữ liệu!";
    public const string NOT_FOUND_CERT = "Không tìm thấy chứng chỉ!";
    public const string NOT_FOUND_DEV_CERT = "Không tìm thấy chứng chỉ của lập trình viên!";

    public const string INTERNAL_SERVER_ERROR = "Lỗi trong quá trình xử lý!";
    public const string SQL_SERVER_ERROR = "Lỗi trong quá trình xử lý SQL!";
    public const string ELASTICSEARCH_SERVER_ERROR = "Lỗi trong quá trình xử lý Elasticsearch!";
    public const string REDIS_SERVER_ERROR = "Lỗi trong quá trình xử lý Redis!";
}
