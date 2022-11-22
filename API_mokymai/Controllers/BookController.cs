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
            return ;
        }

        [HttpGet("{id:int}")]
        public ActionResult Get(int id)
        {
            return;
        }

        [HttpGet("{req:FilterBookRequest}")]
        public ActionResult<List<GetBookDto>> Get(FilterBookRequest req)
        {
            return;
        }

        [HttpPost("{req:CreateBookDto}")]
        public ActionResult<CreateBookDto> Post(CreateBookDto req)
        {
            return;
        }

        [HttpPut("{req:UpdateBookDto}")]
        public ActionResult<UpdateBookDto> Put(UpdateBookDto req)
        {
            return;
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            return;
        }






    }
}
