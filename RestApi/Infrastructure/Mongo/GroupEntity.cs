using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using RestApi.Models;

namespace RestApi.Infrastructure.Mongo;


public class GroupEntity{

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]

    public string Id {get; set;}
    public string Name {get; set;}
    public DateTime CreatedAt {get; set;}
    public Guid [] Users {get; set;}

    internal GroupModel ToModel()
    {
        throw new NotImplementedException();
    }
}