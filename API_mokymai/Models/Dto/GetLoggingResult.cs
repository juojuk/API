namespace API_mokymai.Models.Dto
{
    public class GetLoggingResult
    {
        public GetLoggingResult(string message)
        {
            Message = message;
        }

        /// <summary>
        /// Išsaugota kazkokia zinute
        /// </summary>
        public string Message { get; set; }
    }
}
