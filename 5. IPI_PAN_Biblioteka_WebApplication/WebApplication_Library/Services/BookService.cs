	using AuthDatabase.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApplication_Library.Models;

namespace WebApplication_Library.Services
{
	public class BookService: IBookService
	{

		string url = "https://localhost:44382/";
		HttpClient httpClient = new HttpClient();

		private readonly IMapper _mapper;

		public BookService(IMapper mapper)
		{
			_mapper = mapper;
		}

		//wyświetlam wszystkie książki /PublicLibraryBook/ListBooks
		public async Task<System.Collections.Generic.ICollection<BookViewModel>> GetAll()
		{
			BookServiceHttpClient todoServiceClient = new BookServiceHttpClient(url, httpClient);
			ICollection<Book> dtoBooks = await todoServiceClient.GetAllAsync();

			ICollection<BookViewModel> returnValue = _mapper.Map<List<BookViewModel>>(dtoBooks);

			return returnValue;
		}

		// wyświetlam książkę o danym Id /PublicLibraryBook/Book/{id}
		public async Task<NewBookViewModel> GetSomeID(int id)
		{
			BookServiceHttpClient todoServiceClient = new BookServiceHttpClient(url, httpClient);
			NewBook dtoBook = await todoServiceClient.GetAsync(id);

			NewBookViewModel returnValue = _mapper.Map<NewBookViewModel>(dtoBook);

			return returnValue;
		}

		// kasuję książkę o danym Id /PublicLibraryBook/Book/{id}
		public async Task DeleteSomeID(int id)
		{
			BookServiceHttpClient todoServiceClient = new BookServiceHttpClient(url, httpClient);
			await todoServiceClient.DeleteAsync(id);
		}

		// tworzę nową książkę /PublicLibraryBook/Books/CreateNewBook
		public async Task<int> CreateNewBook(NewBookViewModel book)
		{
			BookServiceHttpClient todoServiceClient = new BookServiceHttpClient(url, httpClient);

			int returnValue = await todoServiceClient.PostAsync(_mapper.Map<NewBook>(book));

			return returnValue;
		}

		// tworzę nowe wypożyczenie /PublicLibraryBookRental/Rental/CreateNewBookRental
		public async Task<int> CreateNewBookRental(NewBookRentalViewModel book)
		{
			BookServiceHttpClient todoServiceClient = new BookServiceHttpClient(url, httpClient);

			int returnValue = await todoServiceClient.Post2Async(_mapper.Map<NewBookRental>(book));

			return returnValue;
		}


		// listuję wypożyczone książki /PublicLibraryBookRental/ListAllBooksRental
		public async Task<System.Collections.Generic.ICollection<BookRentaViewModel>> ListBookRentals()
		{
			BookServiceHttpClient todoServiceClient = new BookServiceHttpClient(url, httpClient);
			ICollection<BookRental> dtoBooks = await todoServiceClient.Get2Async();

			ICollection<BookRentaViewModel> returnValue = _mapper.Map<ICollection<BookRentaViewModel>>(dtoBooks);

			return returnValue.ToArray();
		}


		// wyświetlam wypożyczoną książkę o danym Id /PublicLibraryBookRental/Rental/BooksRental/{id}
		public async Task<BookRentaViewModel> GetBookRentalID(int id)
		{
			BookServiceHttpClient todoServiceClient = new BookServiceHttpClient(url, httpClient);
			BookRental dtoBook = await todoServiceClient.Get3Async(id);

			BookRentaViewModel returnValue = _mapper.Map<BookRentaViewModel>(dtoBook);

			return returnValue;
		}

		// kasuję książkę o danym Id  /PublicLibraryBookRental/Rental/BooksRental/{id}
		public async Task DeleteBookRentalID(int id)
		{
			BookServiceHttpClient todoServiceClient = new BookServiceHttpClient(url, httpClient);
			await todoServiceClient.Delete2Async(id);
		}

		// tworzę nowego czytelnika /PublicLibraryReader/Reader/CreateNewReader
		public async Task<int> CreateNewReader(NewBookRentalViewModel book)
		{
			BookServiceHttpClient todoServiceClient = new BookServiceHttpClient(url, httpClient);

			int returnValue = await todoServiceClient.Post3Async(_mapper.Map<NewReader>(book));

			return returnValue;
		}

		// listuję czytelników /PublicLibraryReader/ListReaders
		public async Task<System.Collections.Generic.ICollection<ReaderViewModel>> ListReaders()
		{
			BookServiceHttpClient todoServiceClient = new BookServiceHttpClient(url, httpClient);
			ICollection<Reader> dtoBooks = await todoServiceClient.Get4Async();

			ICollection<ReaderViewModel> returnValue = _mapper.Map<ICollection<ReaderViewModel>>(dtoBooks);

			return returnValue.ToArray();
		}

		// wyświetlam Readera o danym Id /PublicLibraryReader/Reader/{id}
		public async Task<NewReaderViewModel> GetReaderID(int id)
		{
			BookServiceHttpClient todoServiceClient = new BookServiceHttpClient(url, httpClient);
			NewReader dtoBook = await todoServiceClient.Get5Async(id);

			NewReaderViewModel returnValue = _mapper.Map<NewReaderViewModel>(dtoBook);

			return returnValue;
		}


		// kasuję Readera o danym Id /PublicLibraryReader/Reader/{id}
		public async Task DeleteReaderID(int id)
		{
			BookServiceHttpClient todoServiceClient = new BookServiceHttpClient(url, httpClient);
			await todoServiceClient.Delete3Async(id);
		}

	}
}
