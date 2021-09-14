namespace YooKassa.Api.Models
{
    public class ResponseData<T>
    {
        public T Result { get; init; }
        public Error Error { get; init; }
    }
}
