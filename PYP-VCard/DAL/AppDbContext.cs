using Microsoft.EntityFrameworkCore;
using PYP_VCard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PYP_VCard.DAL
{
    internal class AppDbContext:DbContext
    {
        public AppDbContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-8J9LQBU;Database=VCardDb;Trusted_Connection=True");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<VCard> VCards { get; set; }

    }
}
