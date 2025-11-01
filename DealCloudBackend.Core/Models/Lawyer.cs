// Core/Models/Lawyer.cs
using System.Collections.Generic;

public class Lawyer
{
    public int Id { get; set; }
    public int FirmId { get; set; } // A qué firma pertenece
    public Firm Firm { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public int? PositionId { get; set; }
    public Position Position { get; set; }
    public int? CountryId { get; set; }
    public Country Country { get; set; }
    public int ExperienceYears { get; set; }
    public string ProfileBio { get; set; }

    // Relaciones (Muchos a Muchos)
    public ICollection<PracticeArea> PracticeAreas { get; set; } = new List<PracticeArea>();
    public ICollection<Industry> Industries { get; set; } = new List<Industry>();
    public ICollection<Client> Clients { get; set; } = new List<Client>();
    public ICollection<Deal> DealsAsTeamMember { get; set; } = new List<Deal>();
    public ICollection<Reference> References { get; set; } = new List<Reference>();
}