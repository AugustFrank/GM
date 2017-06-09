using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GM011.Models;

namespace GM11.Models
{
    public class GMContext : DbContext
    {
        public GMContext (DbContextOptions<GMContext> options)
            : base(options)
        {
        }

        public DbSet<GM011.Models.CarType> CarType { get; set; }

        public DbSet<GM011.Models.CarIndexData> Car { get; set; }

        public DbSet<GM011.Models.Service> Service { get; set; }

        public DbSet<GM011.Models.Costumer> Costumer { get; set; }

        public DbSet<GM011.Models.Order> Order { get; set; }
    }
}
