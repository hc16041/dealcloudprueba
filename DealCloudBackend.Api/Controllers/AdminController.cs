// Api/Controllers/AdminController.cs
using DealCloudBackend.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

[Authorize(Roles = "Admin")] // �Solo los administradores pueden usar este controlador!
[ApiController]
[Route("api/[controller]")]
public class AdminController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AdminController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    // GET: api/admin/users
    [HttpGet("users")]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _userManager.Users.ToListAsync();
        // Deber�as mapear esto a un DTO para no exponer toda la info del usuario
        return Ok(users);
    }

    // POST: api/admin/users
    [HttpPost("users")]
    public async Task<IActionResult> CreateUser([FromBody] UserCreateDto dto)
    {
        // L�gica para crear un nuevo ApplicationUser
        var user = new ApplicationUser
        {
            UserName = dto.Email!,
            Email = dto.Email!,
            FullName = dto.FullName!,
            FirmId = dto.FirmId // Asignar la firma
        };
        var result = await _userManager.CreateAsync(user, dto.Password!);

        if (!result.Succeeded) return BadRequest(result.Errors);

        return Ok(user.Id);
    }

    // POST: api/admin/assignrole
    [HttpPost("assignrole")]
    public async Task<IActionResult> AssignRole([FromBody] RoleAssignDto dto)
    {
        var user = await _userManager.FindByIdAsync(dto.UserId!);
        if (user == null) return NotFound("User not found");

        var roleExists = await _roleManager.RoleExistsAsync(dto.RoleName!);
        if (!roleExists) return BadRequest("Role not found");

        var result = await _userManager.AddToRoleAsync(user, dto.RoleName!);
        if (!result.Succeeded) return BadRequest(result.Errors);

        return Ok("Role assigned");
    }
}

// Modelos DTO de ejemplo para el AdminController
public class UserCreateDto
{
    public string? Email { get; set; }
    public string? FullName { get; set; }
    public string? Password { get; set; }
    public int FirmId { get; set; }
}

public class RoleAssignDto
{
    public string? UserId { get; set; }
    public string? RoleName { get; set; }
}