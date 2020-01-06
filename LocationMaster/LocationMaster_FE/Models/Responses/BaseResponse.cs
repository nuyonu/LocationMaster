namespace LocationMaster_FE.Models.Responses
{
    public abstract class BaseResponse
    {
        public bool Success { get;  set; }
        public string Message { get;  set; }


        protected BaseResponse()
        {
        }

        protected BaseResponse(BaseResponse response)
        {
            Success = response.Success;
            Message = response.Message;
        }
        public BaseResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}