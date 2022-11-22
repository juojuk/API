using API_mokymai.Data;
using API_mokymai.Models;
using API_mokymai.Models.Dto;
using API_mokymai.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_mokymai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookManager _bookManager;

        public BookController(IBookManager bookManager)
        {
            _bookManager = bookManager;
        }

        [HttpGet]
        public ActionResult<List<GetBookDto>> Get()
        {
            return Ok(_bookManager.Get());
        }

        [HttpGet("{id}")]
        public ActionResult<GetBookDto> Get(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("filter")]
        public ActionResult<List<GetBookDto>> Filter([FromQuery]FilterBookRequest req)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult Post(CreateBookDto req)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public ActionResult Put(UpdateBookDto req)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return NoContent();
        }






    }
}
