using SoapApi.Models;

namespace SoapApi.Repositories;


    public interface IBookRepository
    {
        public Task <BookModel> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        public Task <IList<BookModel>> GetAllAsync(CancellationToken cancellationToken);
        public Task DeleteByIdAsync (BookModel book, CancellationToken cancellationToken);

    }