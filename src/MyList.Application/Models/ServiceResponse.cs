namespace MyList.Application.Models
{
    public class ServiceResponse
    {
        public string Message { get; internal set; }
        public string Code { get; internal set; }
        public bool Success { get; private set; }
        public void SetOk() => Success = true;
    }
}