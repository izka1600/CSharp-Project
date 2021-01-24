using DB_Model_EFCore.Class;
using DB_Model_EFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DB_Model_EFCore.Controllers
{
    public class BooksRentalController
    {
        PublicLibraryContext context = new PublicLibraryContext();

        public int CreateNewBookRental(NewBookRental item,string rentalFirstName,string rentalLastName,string rentalEmail)
        {
            ReaderController reader = new ReaderController();
            int readerId;

            readerId = reader.FindReaderIdByEmail(rentalEmail);
            if(readerId==0)
            {
                NewReader nReader = new NewReader();

                nReader.FirstName = rentalFirstName;
                nReader.LastName = rentalLastName;
                nReader.Email = rentalEmail;

                readerId = reader.CreateNewReader(nReader);
            }

            var newRental = new BooksRental
            {
                ReaderId = readerId,
                BookId = item.BookId,
                Comment = item.Comment
            };

            context.BooksRental.Add(newRental);
            context.SaveChanges();
            int newId = newRental.RentalId;
            return newId;
        }
        public List<BookRental> ListAllBooks()
        {
            var allBookRental = (
                                from b in context.BooksRental.Where(r => r.DeleteDate == null)
                                select new BookRental
                                {
                                    RentalId = b.RentalId,
                                    ReaderId = b.ReaderId,
                                    BookId = b.BookId,
                                    Comment = b.Comment,
                                    RentalDate = b.RentalDate,
                                    ReturnDate = b.ReturnDate,

                                }).ToList();
            return allBookRental;
        }
        public List<BookRental> ListAllFreeBooks()
        {
            var bookRental = (
                    from b in context.BooksRental.Where(r => r.RentalDate == null && r.Comment == null && r.DeleteDate == null)
                    select new BookRental
                    {
                        RentalId = b.RentalId,
                        ReaderId = b.ReaderId,
                        BookId = b.BookId,
                        Comment = b.Comment,
                        RentalDate = b.RentalDate,
                        ReturnDate = b.ReturnDate,

                    }).ToList();
            return bookRental;
        }
        public BookRental FindBookRental(int id)
        {
            var bookRental = (from r in context.BooksRental
                              where r.DeleteDate == null && r.RentalId == id
                              select new BookRental
                              {
                                  RentalId = r.RentalId,
                                  ReaderId = r.ReaderId,
                                  BookId = r.BookId,
                                  Comment = r.Comment,
                                  RentalDate = r.RentalDate,
                                  ReturnDate = r.ReturnDate
                              }).FirstOrDefault();
            return bookRental;
        }

        public BookRental FindBookLastRental(int bookId)
        {
            var bookRental = (from r in context.BooksRental
                              where r.DeleteDate == null && r.BookId==bookId && (r.ReturnDate==null || r.ReturnDate<r.ReturnDate)
                              select new BookRental
                              {
                                  RentalId = r.RentalId,
                                  ReaderId = r.ReaderId,
                                  BookId = r.BookId,
                                  Comment = r.Comment,
                                  RentalDate = r.RentalDate,
                                  ReturnDate = r.ReturnDate
                              }).FirstOrDefault();
            return bookRental;
        }
        public void ReturnBook(int rentalId, string comment)
        {
            var upd = context.BooksRental.Find(rentalId);
            upd.Comment = comment;
            upd.ReturnDate = DateTime.Now;
            upd.EditDate = DateTime.Now;
            context.SaveChanges();
        }
        public void DeleteBookRental(int rentalId)
        {
            var upd = context.BooksRental.Find(rentalId);
            upd.DeleteDate = DateTime.Now;
            context.SaveChanges();
        }
    }
}
