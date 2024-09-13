
namespace RestApi.Services;

public interface IGroupService{
    
    Task<GroupUserModel> GetGroupByIdAsync(string id, CancellationToken cancellationToken);
}

public class GroupUserModel
{
    public string Id { get; internal set; }
    public string Name { get; internal set; }
    public DateTime CreationDate { get; internal set; }
}