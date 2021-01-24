using DB_Model_EFCore.Class;
using DB_Model_EFCore.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PublicLibraryBookRental : ControllerBase
    {
        // create new rental
        //[Route("Rental/CreateNewBookRental")]
        //[HttpPost]
        //public int Post([FromBody] NewBookRental value)
        //{
        //    return new BooksRentalController().CreateNewBookRental(value);
        //}
        //list all books for rent
        [Route("ListAllBooksRental")]
        [HttpGet]
        public ActionResult<IEnumerable<BookRental>> Get()
        {
            var data = new BooksRentalController().ListAllBooks();

            if (data == null)
            {
                return NotFound();
            }
            return data;
        }
        //get specific book for rent
        [HttpGet("Rental/BooksRental/{id}")]
        public ActionResult<BookRental> Get(int id)
        {
            var data = new BooksRentalController().FindBookRental(id);

            if (data == null)
            {
                return NotFound();
            }
            return data;
        }
        // DELETE specific Reader 
        [HttpDelete("Rental/BooksRental/{id}")]
        public void Delete(int id)
        {
            new BooksRentalController().DeleteBookRental(id);
        }
    }
}
