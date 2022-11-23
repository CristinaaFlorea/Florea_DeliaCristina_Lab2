using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Florea_DeliaCristina_Lab2.Models;

namespace Florea_DeliaCristina_Lab2.Data
{
    public class Florea_DeliaCristina_Lab2Context : DbContext
    {
        public Florea_DeliaCristina_Lab2Context (DbContextOptions<Florea_DeliaCristina_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Florea_DeliaCristina_Lab2.Models.Book> Book { get; set; } = default!;

        public DbSet<Florea_DeliaCristina_Lab2.Models.Publisher> Publisher { get; set; }

        public DbSet<Florea_DeliaCristina_Lab2.Models.Author> Author { get; set; }

        public DbSet<Florea_DeliaCristina_Lab2.Models.Category> Category { get; set; }

        public DbSet<Florea_DeliaCristina_Lab2.Models.Member> Member { get; set; }

        public DbSet<Florea_DeliaCristina_Lab2.Models.Borrowing> Borrowing { get; set; }
    }
}
