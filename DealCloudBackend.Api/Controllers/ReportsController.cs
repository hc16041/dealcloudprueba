// Api/Controllers/ReportsController.cs (El m�s importante)
using DealCloudBackend.Infrastructure.Data; // Para ApplicationDbContext
using DealCloudBackend.Core; // Para tus Modelos (Lawyer, Client, etc.)
using Microsoft.AspNetCore.Mvc; // Para [ApiController], ControllerBase, [Route]
using Microsoft.AspNetCore.Authorization; // Para [Authorize]
using Microsoft.EntityFrameworkCore; // Para .ToListAsync(), .FindAsync()
using DealCloudBackend.Application.Dtos; // Para tus DTOs (si los usas aqu�)
using AutoMapper; // Si est�s usando AutoMapper aqu�
using System.Threading.Tasks; // Para async/await
using System.Collections.Generic; // Para List<>
using System.Linq; // Para .Where()

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ReportsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ReportsController(ApplicationDbContext context)
    {
        _context = context;
    }
    // GET: api/reports/templates
    [HttpGet("templates")]
    public IActionResult GetReportTemplates()
    {
        // Devuelve la lista de formatos (Chambers, IFLR, etc.)
        var templates = new[] { "Chambers", "IFLR", "Legal500_Excel" };
        return Ok(templates);
    }

    // POST: api/reports/generate/word
    [HttpPost("generate/word")]
    public IActionResult GenerateWordReport([FromBody] ReportRequest request)
    {
        // 1. Obtener los datos de los casos (Deals) de la BD
        // var dealsData = await _context.Deals
        //     .Include(d => d.Client)
        //     .Include(d => d.Team)
        //     .Where(d => request.DealIds.Contains(d.Id))
        //     .ToListAsync();

        // 2. L�gica para generar el Word (Usando OpenXML o una librer�a similar)
        // Esta es la "magia" que reemplaza el "copiar y pegar"
        // byte[] fileBytes = await _wordGeneratorService.CreateReport(request.TemplateName, dealsData);

        // 3. Devolver el archivo
        // string contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
        // string fileName = $"{request.TemplateName}_Report.docx";

        // return File(fileBytes, contentType, fileName);

        // Placeholder
        return Ok(new { message = "Word report generated for deals", request.DealIds, request.TemplateName });
    }

    // POST: api/reports/generate/excel
    [HttpPost("generate/excel")]
    public IActionResult GenerateExcelReport([FromBody] ReportRequest request)
    {
        // 1. Obtener los datos...

        // 2. L�gica para generar Excel (Usando ClosedXML o NPOI)

        // 3. Devolver el archivo
        // string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        // string fileName = $"{request.TemplateName}_Report.xlsx";

        // Placeholder
        return Ok(new { message = "Excel report generated for deals", request.DealIds, request.TemplateName });
    }
}