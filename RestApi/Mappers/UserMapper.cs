using RestApi.Dtos;
using RestApi.Infrasctructure.Soap.SoapContracts;
using RestApi.Models;



namespace RestApi.Mappers;

public static class UserMapper{
    public static UserModel ToDomain (this UserResponseDto user) {
        if (user is null) {
            return null;
        }

        return new UserModel {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            BirthDay = user.BirthDate,
            Email = user.Email
        };
    }

    public static UserResponse ToDto(this UserModel user)
    {
        if(user == null)
        {
            return null;
        }

        return new UserResponse
        {
            UserId = user.Id,
            Email = user.Email,
            FirstName = user.FirstName + " " + user.LastName,
            BirthDate = user.BirthDay
        };
    }

     public static List<UserResponse> ToDto(this IList<UserModel> users)
    {
        if(users == null)
        {
            return null;
        }

        return users.Select(user => user.ToDto()).ToList();
    }
}