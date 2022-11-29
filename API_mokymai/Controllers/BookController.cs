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

        /// <summary>
        /// Fetches all registered books in the DB
        /// </summary>
        /// <returns>All books in DB</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetBookDto>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<GetBookDto>> Get()
        {
            return Ok(_bookManager.Get());
        }

        /// <summary>
        /// Fetch registered book with a specified ID from DB
        /// </summary>
        /// <param name="id">Requested book ID</param>
        /// <returns>Book with specified ID</returns>
        /// <response code="400">Customer bad request description</response>
        /// <remarks></remarks>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetBookDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<GetBookDto> Get(int id)
        {
            return Ok(_bookManager.Get(id));
        }

        /// <summary>
        /// Fetches filtered books in the DB
        /// </summary>
        /// <returns>Filtered books in DB</returns>

        [HttpGet("filter")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetBookDto>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<GetBookDto>> Filter([FromQuery]FilterBookRequest req)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(GetBookDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Post(CreateBookDto req)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Put(UpdateBookDto req)
        {
            throw new NotImplementedException();
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Delete(int id)
        {
            return NoContent();
        }






    }
}
