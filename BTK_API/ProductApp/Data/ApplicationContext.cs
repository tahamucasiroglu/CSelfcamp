using ProductApp.Models;

namespace ProductApp.Data
{
    static public class ApplicationContext
    {
        static public List<Book> Books { get; set; }

        static ApplicationContext()
        {
            Books = new List<Book>() 
            {
                new Book(){ Id = 1, Title = "Karagöz ve Hacivat", Price = 75},
                new Book(){ Id = 2, Title = "ökkeş otoparkta", Price = 150},
                new Book(){ Id = 3, Title = "munun gizemi", Price = 50},
                new Book(){ Id = 4, Title = "kızıl ejder", Price = 35},
                new Book(){ Id = 5, Title = "sefiller", Price = 105},
            };
        }
    }
}
