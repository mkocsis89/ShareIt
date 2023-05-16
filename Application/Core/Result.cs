namespace Application.Core
{
    public sealed class Result<TEntity>
    {
        public bool IsSuccess { get; set; }
        public TEntity Value { get; set; }
        public string Error { get; set; }

        public static Result<TEntity> Success(TEntity value)
            => new() { IsSuccess = true, Value = value };

        public static Result<TEntity> Failure(string error)
            => new() { IsSuccess = false, Error = error };
    }
}
