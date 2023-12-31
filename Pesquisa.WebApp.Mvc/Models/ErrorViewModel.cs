namespace Pesquisa.WebApp.Mvc.Models
{
    public class ErrorViewModel
    {
        public int ErrorCode { get; set; }

        public string ErrorTitle { get; set; }

        public string ErrorMessage { get; set; }

        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }

    public class ResponseResult
    {
        public string Title { get; set; }
        public int Status { get; set; }
        public ResponseErrorMessages Errors { get; set; }
    }

    public class ResponseErrorMessages
    {
        public List<string> Messages { get; set; }
    }
}