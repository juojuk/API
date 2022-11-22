namespace API_mokymai.Models.Dto
{
    public class GetBookDto
    {
        public GetBookDto()
        {
        }

        public GetBookDto(int id, string pavadinimasIrAutorius, int leidybosMetai)
        {
            Id = id;
            PavadinimasIrAutorius = pavadinimasIrAutorius;
            LeidybosMetai = leidybosMetai;
        }

        public int Id { get; set; }
        public string PavadinimasIrAutorius { get; set; }
        public int LeidybosMetai { get; set; }
    }
}
