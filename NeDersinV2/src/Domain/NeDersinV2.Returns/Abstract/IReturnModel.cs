
namespace NeDersinV2.Returns.Abstract
{
    public interface IReturnModel<T>
    {
        public bool Status { get; init; }
        public string? Message { get; init; }
        public T? Data { get; init; }
        public Exception? Exception { get; init; }

    }
}
