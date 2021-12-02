namespace Stoqui.Models
{
    public class ApiResult<T> : ApiResult
    {
        public ApiResult(string title, bool success, T result, IEnumerable<string> notifications = null)
        : base(title, success, notifications)
        {
            Result = result;
        }

       
        public T Result { get; set; }

    }

    public  class ApiResult 
    {
        public ApiResult(string title, bool success, IEnumerable<string> notifications = null)
        {
            Title = title;
            Success = success;
            Notifications = notifications;
        }

        public string Title { get; set; }
        public bool Success { get; set; }
        public IEnumerable<string> Notifications { get; set; }

    }
}
