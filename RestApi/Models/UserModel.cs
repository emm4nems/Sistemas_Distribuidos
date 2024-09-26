namespace RestApi.Models;

public class UserModel {
    public Guid Id {get; set; }
    public String FirstName {get; set; } = null;
    public String LastName{get; set; }  = null;
    public string Email {get; set; }  = null;
    public DateTime BirthDay {get; set; }
}