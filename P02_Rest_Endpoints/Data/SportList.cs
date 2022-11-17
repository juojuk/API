using P02_Rest_Endpoints.Models;
using P02_Rest_Endpoints.Models.Dto;

namespace P02_Rest_Endpoints.Data
{
    public static class SportList
    {
        public static List<SportDTO> sportList = new List<SportDTO>()
        {
            new SportDTO(1, "Basketball"),
            new SportDTO(2, "Football"),
            new SportDTO(3, "Chess"),
            new SportDTO(4, "Durts"),
            new SportDTO(5, "Snoocer"),
            new SportDTO(6, "HandBall"),
        };
    }
}
