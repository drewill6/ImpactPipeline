using BC = BCrypt.Net.BCrypt;

namespace DataImpact.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? UserName { get; set; }

        //private string? _password; // Store hashed password privately
        public string? PasswordHash = BCrypt.Net.BCrypt.HashPassword("Pa$$w0rd");
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Role { get; set; } // Role can be a string or an enum, depending on your design
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public bool IsActive { get; set; } // Indicates if the user account is active
        public bool IsAdmin { get; set; } //Indicates whether a user has administrative privileges
        public DateTime LastLogin { get; set; }  // Records the timestamp of the user's last login
        public int CreatedById { get; set; }  // Records the ID of the user wo created this account
        public int UpdatedById { get; set; }  // Records the ID of the user who last updated this account
    }
}
