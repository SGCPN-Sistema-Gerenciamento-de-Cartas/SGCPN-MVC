using Microsoft.EntityFrameworkCore;
using SGCPN.Models;

namespace SGCPN.Contexts;

public class SGCPNContext: DbContext
{
    public SGCPNContext() {}
    
    public SGCPNContext(DbContextOptions<SGCPNContext> options) : base(options)
    {
        // sends option to Dbcontext
    }

    //DB configuration
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source = DESKTOP-GKESQAS; initial catalog = SGCPN; Integrated Security = true; TrustServerCertificate=True");
        }
    }
    
    // entity that will be used
    public DbSet<Institution> Institution { get; set; }
    public DbSet<Patron> Patron { get; set; }
}