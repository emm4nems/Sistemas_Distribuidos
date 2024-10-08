using RestApi.Dtos;
using RestApi.Services;
namespace RestApi.Mappers;

public static class GroupMapper{

    public static GroupResponse ToDto(this GroupUserModel group){
        return new GroupResponse{
            Id = group.Id,
            Name = group.Name,
            CreationDate = group.CreationDate
        };
    }

    public static GroupModel ToModel(this GroupEntity group){
        if (group is null)
        {
            return null;
        }

        return new GroupModel{
            Id = group.Id,
            Name = group.name,
            Users = group.Users,
            CreationDate = group.CreateAt
        };
    }

}