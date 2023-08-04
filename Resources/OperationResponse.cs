namespace CartService.Resources
{
    public class OperationResponse<T> : OperationResponse
    {
        public ErrorCodes ErrorCode { get; set; }
        public T Data { get; set; }

        public OperationResponse(T data)
        {
            Data = data;
        }
        public OperationResponse(ErrorCodes errorCode)
        {
            ErrorCode = errorCode;
        }
    }

    public abstract class OperationResponse
    {
        public enum ErrorCodes
        {
            NoError = 0,
            Cart_NotFound = 100,
            CartItem_NotFound = 200,
        }
    }
}