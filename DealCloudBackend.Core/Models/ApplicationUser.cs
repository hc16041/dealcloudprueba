// Core/Models/ApplicationUser.cs (Para Identidad)
using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser
{
    public string FullName { get; set; }
    public int FirmId { get; set; } // El usuario pertenece a una Firma
    public Firm Firm { get; set; }
}