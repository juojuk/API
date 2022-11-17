using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P02_Rest_Endpoints.Data;
using P02_Rest_Endpoints.Models;

namespace P02_Rest_Endpoints.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportController : ControllerBase
    {
        [HttpGet("sports")]
        public IEnumerable<SportDTO> GetAllSports()
        {
            var sports = SportList.sportList;

            return sports;
        }

        [HttpPost]
        public SportDTO? CreateSport(SportDTO sportDTO)
        {
            //Auto increment
            int getLastSportId = SportList.sportList// .Max(f => f.id)
                .OrderByDescending(f => f.Id)
                .First().Id;

            sportDTO.Id = getLastSportId + 1;

            SportList.sportList.Add(sportDTO);

            return sportDTO;
        }

        [HttpDelete("sports/delete/{id:int}")]
        public void DeleteSport(int id)
        {
            var sport = SportList.sportList.FirstOrDefault(f => f.Id == id);

            SportList.sportList.Remove(sport);
        }

        [HttpPut("sports/update/{id:int}")]
        public void UpdateSport(int id, SportDTO sportDTO)
        {
            var sport = SportList.sportList.FirstOrDefault(f => f.Id == id);

            sport.Name = sportDTO.Name;
        }


    }
}
