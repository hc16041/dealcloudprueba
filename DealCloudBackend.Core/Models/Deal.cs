// Core/Models/Deal.cs (Caso)
using System.Collections.Generic;

public class Deal
{
    public int Id { get; set; }
    public int FirmId { get; set; }
    public Firm Firm { get; set; }

    public string ReferenceNumber { get; set; } // El ID del caso
    public string DealName { get; set; }
    public bool IsConfidential { get; set; }
    public string Description { get; set; }
    public string OtherFirmsInvolved { get; set; }
    public string Notes { get; set; }

    // Relaciones (Uno a Muchos)
    public int ClientId { get; set; }
    public Client Client { get; set; }

    public int PracticeAreaId { get; set; }
    public PracticeArea PracticeArea { get; set; }

    // Relaciones (Muchos a Muchos)
    public ICollection<Lawyer> Team { get; set; } = new List<Lawyer>();
}