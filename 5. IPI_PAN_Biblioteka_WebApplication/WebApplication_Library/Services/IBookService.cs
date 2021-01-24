using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_Library.Models;

namespace WebApplication_Library.Services
{
	public interface IBookService
	{
		Task<System.Collections.Generic.ICollection<BookViewModel>> GetAll();
		Task<NewBookViewModel> GetSomeID(int id);

		Task DeleteSomeID(int id);

		Task<int> CreateNewBook(NewBookViewModel book);
		Task<int> CreateNewBookRental(NewBookRentalViewModel book);
		Task<System.Collections.Generic.ICollection<BookRentaViewModel>> ListBookRentals();
		Task<BookRentaViewModel> GetBookRentalID(int id);
		Task DeleteBookRentalID(int id);
		Task<int> CreateNewReader(NewBookRentalViewModel book);
		Task<System.Collections.Generic.ICollection<ReaderViewModel>> ListReaders();
		Task<NewReaderViewModel> GetReaderID(int id);
		Task DeleteReaderID(int id);
	}
}
