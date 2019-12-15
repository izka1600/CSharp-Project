using DB_Model_EFCore.Class;
using DB_Model_EFCore.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PublicLibraryReader : ControllerBase
    {
        // create new reader
        [Route("Reader/CreateNewReader")]
        [HttpPost]
        public int Post([FromBody] NewReader value)
        {
            return new ReaderController().CreateNewReader(value);
        }
        //list all Readers
        [Route("ListReaders")]
        [HttpGet]
        public ActionResult<IEnumerable<Reader>> Get()
        {
            var data = new ReaderController().ListReaders();

            if (data == null)
            {
                return NotFound();
            }
            return data;
        }
        //get specific Reader 
        [HttpGet("Reader/{id}")]
        public ActionResult<NewReader> Get(int id)
        {
            var data = new ReaderController().FindReader(id);

            if (data == null)
            {
                return NotFound();
            }
            return data;
        }
        // DELETE specific Reader 
        [HttpDelete("Reader/{id}")]
        public void Delete(int id)
        {
            new ReaderController().DeleteReader(id);
        }
    }
}