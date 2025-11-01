// Core/Models/ProBono.cs
public class ProBono
{
    public int Id { get; set; }
    public int FirmId { get; set; }
    public Firm Firm { get; set; }
    public string ReferenceNumber { get; set; }
    public string CaseName { get; set; }
    public string ClientDescription { get; set; } // "Cliente" es anónimo o diferente
    public string CaseDescription { get; set; }
    // ... otros campos específicos de ProBono
}