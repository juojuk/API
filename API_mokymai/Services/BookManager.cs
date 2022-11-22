using API_mokymai.Data;
using API_mokymai.Models;
using API_mokymai.Models.Dto;

namespace API_mokymai.Services
{
    public class BookManager: IBookManager
    {
        public BookManager(IBookSet context, IBookWrapper wrapper)
        {
            _context = context;
            _wrapper = wrapper;
        }

        private readonly IBookSet _context;
        private readonly IBookWrapper _wrapper;

        public List<GetBookDto> Get()
        {
            var sarasas = _context.Books;
            var dto = sarasas.Select(s => _wrapper.Bind(s)).ToList();
            return dto;
        }



    }
}
