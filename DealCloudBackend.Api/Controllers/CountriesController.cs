// Api/Controllers/CountriesController.cs
using DealCloudBackend.Infrastructure.Data;
using DealCloudBackend.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class CountriesController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public CountriesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/countries (Público, ya que no es sensible al Tenant)
    [HttpGet]
    public async Task<IActionResult> GetCountries()
    {
        // Nota: Países NO tiene el filtro de Query global de FirmId.
        var countries = await _context.Countries.ToListAsync();
        return Ok(countries);
    }

    // POST: api/countries (Solo Administradores)
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> CreateCountry([FromBody] Country country)
    {
        _context.Countries.Add(country);
        await _context.SaveChangesAsync();
        return Ok(country);
    }
}