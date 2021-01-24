using DB_Model_EFCore.Class;
using DB_Model_EFCore.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PublicLibraryBook : ControllerBase
    {
        //list all books
        [Route("ListBooks")]
        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            var data = new BooksController().ListBooks();

            if (data == null)
            {
                return NotFound();
            }
            return data;
        }
        //get specific book 
        [HttpGet("Book/{id}")]
        public ActionResult<NewBook> Get(int id)
        {
            var data = new BooksController().FindBooks(id);

            if (data == null)
            {
                return NotFound();
            }
            return data;
        }
        // create new book
        [Route("Books/CreateNewBook")]
        [HttpPost]
        public int Post([FromBody] NewBook value)
        {
            return new BooksController().CreateNewBook(value);
        }

        // DELETE specific book 
        [HttpDelete("Book/{id}")]
        public void Delete(int id)
        {
            new BooksController().DeletetBook(id);
        }
    }
}
