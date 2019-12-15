using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthDatabase.Entities;
using AutoMapper;
using DB_Model_EFCore.Controllers;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication_Library.Models;
using WebApplication_Library.Services;
using WebApplication_Library.ViewModels;
using Microsoft.AspNetCore.Identity;
using AuthDatabase.Entities;


namespace WebApplication_Library.Controllers
{
	public class ItemController : Controller
	{
		private readonly IAntiforgery _antiforgery;

		private readonly IBookService _bookService;
		private readonly UserManager<AppUser> _userManager;

		public ItemController(
	IBookService todoItemService,
	UserManager<AppUser> userManager)
		{
			_bookService = todoItemService;
			_userManager = userManager;
		}

		public async Task<IActionResult> Index()
        {
			var currentUser = await _userManager.GetUserAsync(User);
			if (currentUser == null)
			{
				return Challenge();
			}

			return View();
        }

		public IActionResult AddItem()
		{
			return View();
		}

		[HttpPost]
		public IActionResult AddItem(DB_Model_EFCore.Class.NewBook book)
		{
            Azure.CeateItem azure = new Azure.CeateItem();
            Task<string> url;
            string file;

            file = "c:\\temp\\m\\" + book.CoverName;
            url =azure.CeateNew(file);
            if (url.Result != null)
            {
                book.CoverName = url.Result;
                new BooksController().CreateNewBook(book);
            }

			return RedirectToAction(nameof(Statistics));
		}

		public IActionResult SearchItem()
		{
			return View();
		}

        [HttpGet]
        public IActionResult DetailsItem(int id)
		{
            DB_Model_EFCore.Class.Book book;
            List<DB_Model_EFCore.Class.Book> data = new DB_Model_EFCore.Controllers.BooksController().ListBooks();

            book =  (from DB_Model_EFCore.Class.Book item in data
                        where item.BookId == id
                        select item).FirstOrDefault();

            if (book != null)
            {
                BookDetailsVM item = new BookDetailsVM()
                {
                    BookName = book.BookName,
                    FirstName = book.FirstName,
                    LastName = book.LastName,
                    PublicationDate = book.PublicationDate,
                    CoverName = book.CoverName,
                    DataCarrierName = book.DataCarrierName,
                    BookId=book.BookId
                };

                DB_Model_EFCore.Class.BookRental rental;
                rental = new DB_Model_EFCore.Controllers.BooksRentalController().FindBookLastRental(book.BookId);

                if (rental != null)
                {
                    DB_Model_EFCore.Class.NewReader nReader = new DB_Model_EFCore.Class.NewReader();
                    DB_Model_EFCore.Controllers.ReaderController reader = new DB_Model_EFCore.Controllers.ReaderController();                   
                    nReader=reader.FindReader(rental.ReaderId.Value);

                    item.RentalId = rental.RentalId;
                    item.RentDateTime = rental.RentalDate.Value;
                    item.ReturnDateTime = rental.RentalDate.Value;
                    if (nReader != null)
                    {
                        item.RentalFirstName = nReader.FirstName;
                        item.RentalLastName = nReader.LastName;
                        item.RentalEmail = nReader.Email;
                    }
                }

                return View(item);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult DetailsItem()
        {
            return RedirectToAction(nameof(Statistics));
        }

		public IActionResult ChangeStatusItem()
		{
			List<DB_Model_EFCore.Class.Book> data = new DB_Model_EFCore.Controllers.BooksController().ListBooks();
			return View(data);
		}

		[Route("/Rental/CreateNewBookRental/{id}/{type}")]
		[HttpPost]
		public async Task<IActionResult> ChangeStatusItem(int bookId, string comment)
		{
			{
				var currentUser = await _userManager.GetUserAsync(User);
				DB_Model_EFCore.Class.NewBookRental item = new DB_Model_EFCore.Class.NewBookRental();
				item.BookId = bookId;
				item.Comment = comment;
				item.ReaderId = Convert.ToInt16(currentUser.Id);
				new BooksRentalController().CreateNewBookRental(item,currentUser.FirstName,currentUser.LastName,currentUser.Email);
				return RedirectToAction(nameof(Statistics));
			}

		}

        //[Route("/PublicLibraryBook/ListBooks/{id}")]
        [HttpGet]
        public IActionResult RentItem(int id)
        {
            DB_Model_EFCore.Class.Book book;
            List<DB_Model_EFCore.Class.Book> data = new DB_Model_EFCore.Controllers.BooksController().ListBooks();

            book = (from DB_Model_EFCore.Class.Book item in data
                    where item.BookId == id
                    select item).FirstOrDefault();

            if (book != null)
            {
                BookDetailsVM item = new BookDetailsVM()
                {
                    BookName = book.BookName,
                    FirstName = book.FirstName,
                    LastName = book.LastName,
                    PublicationDate = book.PublicationDate,
                    CoverName = book.CoverName,
                    DataCarrierName = book.DataCarrierName,
                    BookId = id
                };

                DB_Model_EFCore.Class.BookRental rental;
                rental = new DB_Model_EFCore.Controllers.BooksRentalController().FindBookLastRental(id);

                if (rental == null || rental.ReturnDate!=null && rental.ReturnDate >= rental.RentalDate)
                {
                    return View(item);
                }
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> RentItem(BookDetailsVM itemVM)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            DB_Model_EFCore.Class.NewBookRental item = new DB_Model_EFCore.Class.NewBookRental();
            item.BookId = itemVM.BookId;
            item.Comment = itemVM.Comment;
            new BooksRentalController().CreateNewBookRental(item,currentUser.FirstName,currentUser.LastName,currentUser.Email);
            return RedirectToAction(nameof(Statistics));
        }

        [Route("/PublicLibraryBook/Book/{id}")]
		public async Task<IActionResult> DeleteBook(int id)
		{
			await _bookService.DeleteSomeID(id);
			//new DB_Model_EFCore.Controllers.BooksController().DeletetBook(id);
			return RedirectToAction(nameof(Statistics));
		}


		[Route("/PublicLibraryBook/ListBooks")]
		public async Task<IActionResult> Statistics()
		{

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return RedirectToAction("Statistics");
            }

            ICollection<BookViewModel> currentBookItems = await _bookService.GetAll();
            var model = new ListBookViewModel()
            {
                Items = currentBookItems
            };
            return View(model);


            //List<DB_Model_EFCore.Class.Book> data = new DB_Model_EFCore.Controllers.BooksController().ListBooks();

            //if (data == null)
            //{
            //    return NotFound();
            //}
            //return View(data);

        }
    }
}