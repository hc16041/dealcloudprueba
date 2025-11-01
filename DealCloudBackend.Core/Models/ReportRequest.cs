// Modelo simple para la solicitud de reporte
using System.Collections.Generic;

public class ReportRequest
{
    public string TemplateName { get; set; } // "Chambers", "IFLR"
    public List<int> DealIds { get; set; } // [10, 45, 123]
}