namespace API_mokymai.Models.Dto
{
    public class GetServiceResult
    {
        public GetServiceResult(int workCode)
        {
            WorkCode = workCode;
        }

        /// <summary>
        /// Serviso darbo kodas
        /// 55555, jei darbas baigtas
        /// </summary>
        public int WorkCode { get; set; }


    }
}