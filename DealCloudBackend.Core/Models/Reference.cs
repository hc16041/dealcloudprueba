// Core/Models/Reference.cs (Referer)
public class Reference
{
    public int Id { get; set; }
    public int FirmId { get; set; }
    public Firm Firm { get; set; }

    public int LawyerId { get; set; } // Referencia PARA este abogado
    public Lawyer Lawyer { get; set; }

    public string ClientContactName { get; set; }
    public string ClientContactEmail { get; set; }
    public string ClientContactPosition { get; set; }
    public string ClientCompany { get; set; } // Nombre de la empresa del cliente
}