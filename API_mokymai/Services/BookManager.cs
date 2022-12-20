using API_mokymai.Data;
using API_mokymai.Models;
using API_mokymai.Models.Dto;
using API_mokymai.Services.IServices;

namespace API_mokymai.Services
{
    public class BookManager : IBookManager
    {
        //{
        //    public BookManager(IBookSet context, IBookWrapper wrapper)

        //    {
        //        _context = context;
        //        _wrapper = wrapper;
        //    }

        //    private readonly IBookSet _context;
        //    private readonly IBookWrapper _wrapper;

        //    public List<GetBookDto> Get()
        //    {
        //        //var sarasas = _context.Books;
        //        //var dto = sarasas.Select(s => _wrapper.Bind(s)).ToList();
        //        //return dto;
        //        return _context.Books.Select(s => _wrapper.Bind(s)).ToList();
        //    }

        //    public GetBookDto Get(int id)
        //    {
        //        //return (GetBookDto)_context.Books.Where(s => _wrapper.Bind(s).Id == id);
        //        //return _context.Books.FirstOrDefault(i => i.Id == id);
        //        return _wrapper.Bind(_context.Books.FirstOrDefault(i => i.Id == id));
        //    }

        //    public bool Exists(int id)
        //    {
        //        //return (GetBookDto)_context.Books.Where(s => _wrapper.Bind(s).Id == id);
        //        //return _context.Books.FirstOrDefault(i => i.Id == id);
        //        return _context.Books.Any(i => i.Id == id);
        //    }
        public GetBookDto GetAvailable(int id)
        {
            throw new NotImplementedException();
        }
    }
}
