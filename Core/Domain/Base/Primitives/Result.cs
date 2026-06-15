
using ECommerce.Core.Domain.POCOs;

namespace ECommerce.Core.Domain.Primitives
{
    public class Result<T>
    {
        public T? Value { get; private set; }

        public bool IsSuccess { get; private set; }

        public Error? Error { get; private set; }

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

    public class Result
    {
        public bool IsSuccess { get; private set; }
        public Error? Error { get; private set; }
        public static Result Success() => new Result(true);
        public static Result Failure(Error error) => new Result(false, error);

        private Result(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }

        private Result(bool isSuccess, Error error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }
    }
}
