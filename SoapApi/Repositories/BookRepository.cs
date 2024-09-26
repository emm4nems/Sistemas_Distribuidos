using System.CodeDom;
using Microsoft.EntityFrameworkCore;
using SoapApi.Contracts;
using SoapApi.Dtos;
using SoapApi.Infrastructure;
using SoapApi.Mappers;
using SoapApi.Models;

namespace SoapApi.Repositories{



    public class BookRepository : IBookRepository
    {
        private readonly RelationalDbContext _dbContext;

        public BookRepository (RelationalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task <BookModel> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var book = await _dbContext.Books.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
            return book.ToBookModel();
        }

        public async Task <IList<BookModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            var books = await _dbContext.Books.AsNoTracking().ToListAsync(cancellationToken);
            return books.Select(books => books.ToBookModel()).ToList();
        }

        public async Task DeleteByIdAsync (BookModel book, CancellationToken cancellationToken)
        {
            var bookEntity = book.ToBookEntity();

            _dbContext.Books.Remove(bookEntity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

    }
}