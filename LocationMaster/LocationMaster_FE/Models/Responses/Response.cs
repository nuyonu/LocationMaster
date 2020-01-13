namespace LocationMaster_FE.Models.Responses
{
    public class Response<T> : BaseResponse where T : class
    {
        public Response(bool success, string message, T data) : base(success, message)
        {
            this.data = data;
        }

        public Response(T data) : this(true, string.Empty, data)
        {
        }

        public Response(string message) : this(false, message, null)
        {
        }

        public T data { get;  set; }

        public Response()
        {
        }
    }
}