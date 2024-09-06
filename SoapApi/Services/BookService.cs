using System.ServiceModel;
using Microsoft.AspNetCore.WebUtilities;
using SoapApi.Contracts;
using SoapApi.Dtos;
using SoapApi.Mappers;
using SoapApi.Repositories;

namespace SoapApi.Services;

public class BookService : IBookContract
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<IList<BookResponseDto>> GetAll(CancellationToken cancellationToken)
    {
        var books = await _bookRepository.GetAllAsync(cancellationToken);

        if(books is not null && books.Any()){
            return books.Select(book => book.ToBookDto()).ToList();
        }
        throw new FaultException(reason: "Books not found.");
    }

    public async Task<BookResponseDto> GetBookById(Guid bookId, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetByIdAsync(bookId, cancellationToken);

        if(book is not null){
            return book.ToBookDto();
        }

        throw new FaultException(reason: "Book not found");
    }

    public async Task<bool> DeleteBookById (Guid bookId, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetByIdAsync(bookId,  cancellationToken);

        if (book is null){
            throw new FaultException("Book not found");
        }

        await _bookRepository.DeleteByIdAsync(book, cancellationToken);
        return true;
    }





}