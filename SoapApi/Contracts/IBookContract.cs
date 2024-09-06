using System.ServiceModel;
using SoapApi.Dtos;

namespace SoapApi.Contracts;

[ServiceContract]
public interface IBookContract
{

    [OperationContract]
    public Task<BookResponseDto> GetBookById(Guid bookId, CancellationToken cancellationToken);

    [OperationContract]
    public Task <IList<BookResponseDto>> GetAll(CancellationToken cancellationToken);

    [OperationContract]
    public Task<bool> DeleteBookById (Guid bookId, CancellationToken cancellationToken);
}

