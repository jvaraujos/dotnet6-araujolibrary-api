//using Neowrk.Library.Core.Entities;
//using Neowrk.Library.Repository.Repositories;
//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace Neowrk.Library.Service
//{
//    public class BookService : IBookService
//    {
//        private readonly string _connectionString;

//        public BookService()
//        {
//        }

//        public BookService(string connectionString)
//        {
//            this._connectionString = connectionString;
//        }

//        public async Task<List<Book>> GetAllBooks()
//        {
//            var bookRepository = new BookRepository(_connectionString);
//            return await bookRepository.GetAllBooks();
//        }

//        public async Task BorrowBook(Guid id, string studentEmail)
//        {
//            var bookRepository = new BookRepository(_connectionString);
//            await bookRepository.BorrowBook(id, studentEmail);
//        }
//    }
//}
