using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VitecAPI;

namespace VitecAPI.Models
{
    public class VitecAPIContext : DbContext
    {
        public VitecAPIContext (DbContextOptions<VitecAPIContext> options)
            : base(options)
        {
        }

        public DbSet<VitecAPI.Product> Product { get; set; }
    }
}
