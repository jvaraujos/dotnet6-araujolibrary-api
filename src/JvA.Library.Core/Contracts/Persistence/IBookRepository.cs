using JvA.Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JvA.Library.Application.Contracts.Persistence
{
    public interface IBookRepository : IAsyncRepository<Book>
    {
        Task<IReadOnlyList<Book>> GetAllBooksPagedResponseByAvaliableAsync(int page, int size, bool avaliable);
        Task<bool> BorrowBookAvaliableToStudentEmail(Guid id, string studentEmail);
        Task<bool> IsBookUnique(string title,string author);
    }
}
