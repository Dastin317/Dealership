namespace DealershipManager.Models
{
    public class Result
    {
        public bool IsSucces { get; }

        public string ErrorMessage { get; set; }

        private Result(bool isSucces, string? errorMessage)
        {
            IsSucces = isSucces;
            ErrorMessage = errorMessage;
        }

        public static Result Success()
        {
            return new Result
            {


                ErrorMessage = null
            };
        }

        private static Result Fail(string errorMessage)
        {
            return new Result(false, errorMessage);
        }
    }
}
