using API_mokymai.Data;
using API_mokymai.Models;
using API_mokymai.Models.Dto;
using API_mokymai.Repository;
using API_mokymai.Repository.IRepository;
using API_mokymai.Services.IServices;

namespace API_mokymai.Services
{
    public class BookManager : IBookManager
    {
        public int GetActiveMeasureId(List<Measure> measures)
        {
            return measures.Last().Id;
        }

        public bool IsAvailableBook(Book book, List<Reservation> reservations)
        {
            return book.Quantity > reservations.Count(b => b.ReturnDateTime == null && b.BookId == book.Id) ? true : false;
        }

        public bool IsAvailableReservation(List<Measure> measures, List<Reservation> reservations)
        {
            var activeMeasure = measures.Last();
            return activeMeasure.MaxBooksOnHand > reservations.Count(b => b.ReturnDateTime == null) ? true : false;
        }



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
    }
}
