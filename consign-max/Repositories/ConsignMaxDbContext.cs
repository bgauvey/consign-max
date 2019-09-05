using consign_max.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace consign_max.Repositories
{
    public class ConsignMaxDbContext : DbContext
    {
        public ConsignMaxDbContext(DbContextOptions<ConsignMaxDbContext> options) : base(options) { }

        public DbSet<Consignor> Consignors { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<State> States { get; set; }

    }
}
