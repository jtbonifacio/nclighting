using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SpinnersLab.Models;

namespace SpinnersLab.Models
{
    public class SpinnersContext : DbContext
    {
        public SpinnersContext(DbContextOptions<SpinnersContext> options) : base(options)
        {

        }
        public DbSet<Spinner> Spinners { get; set; }
        public DbSet<SpinnersLab.Models.Customer> Customer { get; set; }
        public DbSet<SpinnersLab.Models.Sale> Sale { get; set; }
        public DbSet<SpinnersLab.Models.Store> Store { get; set; }
    }
}
