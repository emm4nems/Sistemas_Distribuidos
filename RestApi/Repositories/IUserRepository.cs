namespace RestApi.Repositories;

using RespApi.Models;
using RestApi.Models;

public interface IUserRepository {
    Task<UserModel> GetByIdAsync (Guid userId, CancellationToken cancellationToken);
}