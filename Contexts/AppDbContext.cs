using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PocAuth.Contexts;

public class AppDbContext : IdentityDbContext
{
    private readonly IConfiguration _configuration;
    
    public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={_configuration.GetConnectionString("DefaultConnection")}");
}