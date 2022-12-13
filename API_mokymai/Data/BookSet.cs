using API_mokymai.Models;

namespace API_mokymai.Data
{
    public static class BookSet
    {
        private static List<Book> bookList = new List<Book>()
        {
            new Book(1, "Orange", "Spainito", ECoverType.Electronic, 1900, 5),
            new Book(2, "Apple", "Spainito", ECoverType.Electronic, 1910, 5),
            new Book(3, "Banana", "Africana", ECoverType.Electronic, 1920, 5),
            new Book(4, "Grapes", "Italiano", ECoverType.Electronic, 1930, 5),
            new Book(5, "Sausages", "Germaner", ECoverType.Electronic, 1940, 5),
            new Book(6, "Potatoes", "Belaruska", ECoverType.Electronic, 1950, 5),
            new Book(7, "Tomato", "Belaruska", ECoverType.Electronic, 1960, 5),
            new Book(8, "Morkos", "Lithuanis", ECoverType.Electronic, 1970, 5),
            new Book(9, "Onions", "Lithuanis", ECoverType.Electronic, 1980, 5),
            new Book(10, "Aguonos", "Lithuanis", ECoverType.Electronic, 1990, 5),
        };

        public static List<Book> Books { get { return bookList; } set { bookList = value; } }
    }
}
