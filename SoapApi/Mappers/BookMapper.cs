using SoapApi.Dtos;
using SoapApi.Infrastructure.Entities;
using SoapApi.Models;

namespace SoapApi.Mappers{



    public static class BookMapper
    {

        public static BookModel ToBookModel(this BookEntity book)
        {
            if (book is null){
                return null;
            }
            return new BookModel
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Publisher = book.Publisher,
                PublishedDate = book.PublishedDate
            };
        }

        public static BookResponseDto ToBookDto(this BookModel book)
        {
            return new BookResponseDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Publisher = book.Publisher,
                PublishedDate = book.PublishedDate
            };
        }

        public static BookEntity ToBookEntity (this BookModel book){
            return new BookEntity{
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Publisher = book.Publisher,
                PublishedDate = book.PublishedDate
            };
        }


    }
}