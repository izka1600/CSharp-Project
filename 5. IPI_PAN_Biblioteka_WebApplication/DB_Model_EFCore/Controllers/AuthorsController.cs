using DB_Model_EFCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DB_Model_EFCore.Controllers
{
    public class AuthorsController
    {
        PublicLibraryContext context = new PublicLibraryContext();
        public int CreateNewAuthor(string firstName, string lastName)
        {
            var newAuthor = new Authors
            {
                FirstName= firstName,
                LastName = lastName
            };

            context.Authors.Add(newAuthor);
            context.SaveChanges();
            int newId = newAuthor.AuthorId;
            return newId;
        }
        public List<Authors> ListAuthors()
        {
            return context.Authors.Where(r => r.DeleteDate == null).ToList();
        }
        public Authors FindAuthor(int id)
        {
            return context.Authors.Find(id);
        }
        public void UpdateAuthor(int Id, string firstName, string lastName)
        {
            var upd = context.Authors.Find(Id);
            upd.FirstName = firstName;
            upd.LastName = lastName;
            upd.EditDate = DateTime.Now;
            context.SaveChanges();
        }
        public void DeleteAuthor(int Id)
        {
            var upd = context.Authors.Find(Id);
            upd.DeleteDate = DateTime.Now;
            context.SaveChanges();
        }
    }
}
