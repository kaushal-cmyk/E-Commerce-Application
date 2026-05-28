
using ECommerce.Core.Domain.POCOs;

namespace ECommerce.Core.Domain.Primitives
{
    public record Result<T>
    {
        public T Value { get; private set; }

        public bool IsSuccess { get; private set; }

        public Error Error { get; private set; }

        public static Result<T> Success(T data) => new Result<T>(data);
        public static Result<T> Failure(Error error) => new Result<T>(error);


        private Result(T data)
        {
            Value = data;
            IsSuccess = true;
        }

        private Result(Error error)
        {
            IsSuccess = false;
            Error = error;
        }

    }
}
