using DB_Model_EFCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DB_Model_EFCore.Class;

namespace DB_Model_EFCore.Controllers
{
    public class ReaderController
    {
        PublicLibraryContext context = new PublicLibraryContext();

        public int CreateNewReader(NewReader item)
        {
            var newReader = new Readers
            {
                FirstName = item.FirstName,
                LastName = item.LastName,
                Email = item.Email,
                AccessRights = item.AccessRights
            };

            context.Readers.Add(newReader);
            context.SaveChanges();
            int newId = newReader.ReaderId;
            return newId;
        }
        public List<Reader> ListReaders()
        {
            var listReaders = (from r in context.Readers
                               where r.DeleteDate == null
                               select new Reader
                               {
                                   ReaderId = r.ReaderId,
                                   FirstName = r.FirstName,
                                   LastName = r.LastName,
                                   Email = r.Email,
                                   AccessRights = r.AccessRights
                               }).ToList();

            return listReaders;
        }
        public NewReader FindReader(int id)
        {
            var reader = (from r in context.Readers
                               where r.DeleteDate == null && r.ReaderId == id
                               select new NewReader
                               {
                                   FirstName = r.FirstName,
                                   LastName = r.LastName,
                                   Email = r.Email,
                                   AccessRights = r.AccessRights
                               }).FirstOrDefault();

            return reader;
        }

        public int FindReaderIdByEmail(string email)
        {
            var reader = (from r in context.Readers
                          where r.DeleteDate == null && r.Email == email
                          select r).FirstOrDefault();
            if (reader != null)
                return reader.ReaderId;
            else
                return 0;
        }

        public void UpdateReader(Reader item)
        {
            var upd = context.Readers.Find(item.ReaderId);
            upd.FirstName = item.FirstName;
            upd.LastName = item.LastName;
            upd.Email = item.Email;
            upd.AccessRights = item.AccessRights;
            upd.EditDate = DateTime.Now;
            context.SaveChanges();
        }
        public void DeleteReader(int Id)
        {
            var upd = context.Readers.Find(Id);
            upd.DeleteDate = DateTime.Now;
            context.SaveChanges();
        }
    }
}
