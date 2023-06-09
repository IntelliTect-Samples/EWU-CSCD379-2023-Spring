namespace Wordle.Api.Models
{
    /// <summary>
    /// Response to send back to the client when we need error messages
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Response<T> where T : class
    {
        public Response(T data)
        {
            Data = data;
            WasSuccessful = true;
            Message = null;
        }
        public Response(string message)
        {
            Data = null;
            WasSuccessful = false;
            Message = message;
                
        }

        public T? Data { get; set; }
        public bool WasSuccessful { get; set; }
        public string? Message { get; set; }
    }
}
