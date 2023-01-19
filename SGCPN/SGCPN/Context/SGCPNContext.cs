using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SGCPN.Models;

    public class SGCPNContext : DbContext
    {
        public SGCPNContext (DbContextOptions<SGCPNContext> options):base(options)
        {}

        public DbSet<Institution> Institution { get; set; }
        public DbSet<Patron> Patron { get; set; }
    }
