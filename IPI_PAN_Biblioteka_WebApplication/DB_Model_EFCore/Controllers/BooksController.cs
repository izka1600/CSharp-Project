using DB_Model_EFCore.Models;
using DB_Model_EFCore.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DB_Model_EFCore.Class;

namespace DB_Model_EFCore.Controllers
{
    public class BooksController
    {
        PublicLibraryContext context = new PublicLibraryContext();
        public int CreateNewBook(NewBook item)
        {
            var newBook = new Books
            {
                CoverId = new BookCoversController().CreateNewBookCovers(item.CoverName),
                AuthorsId = new AuthorsController().CreateNewAuthor(item.FirstName, item.LastName),
                DataCarrierId = new DataCarriersController().CreateNewDataCarrier(item.DataCarrierName),
                Name = item.BookName,
                PublicationDate = item.PublicationDate
            };

            context.Books.Add(newBook);
            context.SaveChanges();
            int newId = newBook.BookId;
            return newId;
        }
        public List<Book> ListBooks()
        {
            var bookListToSend = (
                                from
                                b in context.Books.Where(r => r.DeleteDate == null)
                                join
                                c in new BookCoversController().ListBookCovers() on b.CoverId equals c.CoverId
                                join
                                a in new AuthorsController().ListAuthors() on b.AuthorsId equals a.AuthorId
                                join
                                d in new DataCarriersController().ListDataCarriers() on b.DataCarrierId equals d.DataCarrierId
                                where
                                b.DeleteDate == null && c.DeleteDate == null && a.DeleteDate == null && d.DeleteDate == null
                                select new Book
                                {
                                    BookId = b.BookId,
                                    BookName = b.Name,
                                    FirstName = a.FirstName,
                                    LastName = a.LastName,
                                    PublicationDate = b.PublicationDate,
                                    CoverName = c.Name,
                                    DataCarrierName = d.Name
                                }).ToList();
            return bookListToSend;
        }
        public NewBook FindBooks(int id)
        {
            var book = (
                        from
                        b in context.Books.Where(r => r.DeleteDate == null && r.BookId == id)
                        join
                        c in new BookCoversController().ListBookCovers() on b.CoverId equals c.CoverId
                        join
                        a in new AuthorsController().ListAuthors() on b.AuthorsId equals a.AuthorId
                        join
                        d in new DataCarriersController().ListDataCarriers() on b.DataCarrierId equals d.DataCarrierId
                        where
                        b.DeleteDate == null && c.DeleteDate == null && a.DeleteDate == null && d.DeleteDate == null 
                        select new NewBook
                        {
                            BookName = b.Name,
                            FirstName = a.FirstName,
                            LastName = a.LastName,
                            PublicationDate = b.PublicationDate,
                            CoverName = c.Name,
                            DataCarrierName = d.Name
                        }).FirstOrDefault();
            return book;
        }
        public void DeletetBook(int Id)
        {
            var upd = context.Books.Find(Id);
            upd.DeleteDate = DateTime.Now;
            context.SaveChanges();

        }
    }
}
