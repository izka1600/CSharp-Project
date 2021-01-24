using DB_Model_EFCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DB_Model_EFCore.Controllers
{
    public class BookCoversController
    {
        PublicLibraryContext context = new PublicLibraryContext();
        public int CreateNewBookCovers(string name)
        {
            var newCover = new BookCovers
            {
                Name = name
            };

            context.BookCovers.Add(newCover);
            context.SaveChanges();
            int newId = newCover.CoverId;
            return newId;
        }
        public List<BookCovers> ListBookCovers()
        {
            return context.BookCovers.Where(r => r.DeleteDate == null).ToList();
        }
        public BookCovers FindBookCovers(int id)
        {
            return context.BookCovers.Find(id);
        }
        public void UpdateBookCovers(int Id, string name)
        {
            var upd = context.BookCovers.Find(Id);
            upd.Name = name;
            upd.EditDate = DateTime.Now;
            context.SaveChanges();
        }
        public void DeleteBookCovers(int Id)
        {
            var upd = context.BookCovers.Find(Id);
            upd.DeleteDate = DateTime.Now;
            context.SaveChanges();
        }
    }
}
