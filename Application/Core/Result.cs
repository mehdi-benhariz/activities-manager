namespace Application.Core
{
    public class Result<T>
    {
        public Result(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public T Value { get; set; }
        public string Error { get; set; }
        public static Result<T> SuccessResult(T value)=>new Result<T>(true, ""){Value=value};
        public static Result<T> FailureResult(string error)=> new Result<T>(false, error);
    }

}