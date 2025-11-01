// Core/Models/Firm.cs
using System.Collections.Generic;

public class Firm
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();
    public ICollection<Client> Clients { get; set; } = new List<Client>();
    public ICollection<Deal> Deals { get; set; } = new List<Deal>();
    // ...y así para todas las entidades principales
}