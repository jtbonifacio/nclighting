using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NCLBackend.Models;

namespace NCLBackend.Models
{
    public class NCLBackendContext : DbContext
    {
        public NCLBackendContext(DbContextOptions<NCLBackendContext> options) : base(options)
        {
            
        }
        public DbSet<NCLBackend.Models.Users> Users { get; set; }
        public DbSet<NCLBackend.Models.Daily> Daily { get; set; }
        public DbSet<NCLBackend.Models.Weekly> Weekly { get; set; }
        public DbSet<NCLBackend.Models.Monthly> Monthly { get; set; }
        public DbSet<NCLBackend.Models.Quarterly> Quarterly { get; set; }
        public DbSet<NCLBackend.Models.Yearly> Yearly { get; set; }
        public DbSet<NCLBackend.Models.Quotas> Quota { get; set; }
        public DbSet<NCLBackend.Models.Inventory> Inventory { get; set; }
        }
}
