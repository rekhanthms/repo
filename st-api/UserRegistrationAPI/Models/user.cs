using Microsoft.EntityFrameworkCore;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string? Email { get; set; } 
    public string Password { get; set; } = string.Empty;
    
    // for Make the Properties Nullable
    public DbSet<User>? Users { get; set; }

    // Error occured for null 

    // public string Username { get; set; }
    // public string Email { get; set; }
    // public string Password { get; set; }
}
