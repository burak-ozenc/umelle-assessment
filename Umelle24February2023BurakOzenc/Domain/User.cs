namespace Umelle24February2023BurakOzenc.Domain;

public class User
{
    public Guid Id { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    
    
    
    private User(string email, string password)
    {
        Id = Guid.NewGuid();
        Email = email;
        Password = password;
    }

    public static User Create(string email, string password)
        => new User(email, password); 
    
    private User(){}
}
