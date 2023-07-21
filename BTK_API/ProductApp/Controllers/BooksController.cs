using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Data;

namespace ProductApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {


        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = ApplicationContext.Books;
            return Ok(books);
        }

        [HttpGet]
        public IActionResult GetOne()
        {
            var books = ApplicationContext.Books;
            return Ok(books);
        }
    }
}
