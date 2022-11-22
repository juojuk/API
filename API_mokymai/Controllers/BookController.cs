using API_mokymai.Data;
using API_mokymai.Models;
using API_mokymai.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_mokymai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        //private readonly IBookSet _books;

        //public BookController(IBookSet books)
        //{
        //    _books = books;
        //}

        [HttpGet]
        public ActionResult<List<GetBookDto>> Get()
        {
            return new List<GetBookDto>();
        }

        [HttpGet("{id:int}")]
        public ActionResult<GetBookDto> Get(int id)
        {
            return new GetBookDto();
        }

        [HttpGet("filter")]
        public ActionResult<List<FilterBookRequest>> Filter([FromQuery]FilterBookRequest req)
        {
            return new List<FilterBookRequest>();
        }

        [HttpPost]
        public ActionResult<CreateBookDto> Post(CreateBookDto req)
        {
            return new CreateBookDto();
        }

        [HttpPut("{id:int}")]
        public ActionResult<UpdateBookDto> Put(int id, UpdateBookDto req)
        {
            return new UpdateBookDto();
        }

        [HttpDelete("{id:int}")]
        public ActionResult<int> Delete(int id)
        {
            return id;
        }






    }
}
