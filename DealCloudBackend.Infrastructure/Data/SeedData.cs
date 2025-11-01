using DealCloudBackend.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DealCloudBackend.Infrastructure.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // --- Sembrar Roles ---
            string[] roleNames = { "Admin", "User", "Manager" };
            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    // Crear los roles
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // --- Sembrar Firma (Tenant) de Prueba ---
            // Necesitamos al menos una firma para asignar al admin
            var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
            if (!dbContext.Firms.Any())
            {
                var initialFirm = new Firm { Name = "Bufete Principal (Arias)" };
                dbContext.Firms.Add(initialFirm);
                await dbContext.SaveChangesAsync(); // Guardamos para obtener el ID
            }

            var defaultFirm = dbContext.Firms.First();

            // --- Sembrar Usuario Admin ---
            var adminUser = await userManager.FindByEmailAsync("admin@dealcloud.com");
            if (adminUser == null)
            {
                var newAdmin = new ApplicationUser
                {
                    UserName = "admin@dealcloud.com",
                    Email = "admin@dealcloud.com",
                    FullName = "Administrador del Sistema",
                    EmailConfirmed = true,
                    FirmId = defaultFirm.Id // Asignamos la firma inicial
                };

                var result = await userManager.CreateAsync(newAdmin, "Admin123!");
                if (result.Succeeded)
                {
                    // Asignar el rol "Admin"
                    await userManager.AddToRoleAsync(newAdmin, "Admin");
                }
            }
        }
    }
}