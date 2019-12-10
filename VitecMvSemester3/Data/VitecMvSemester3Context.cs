using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace VitecMvSemester3.Models
{
    public class VitecMvSemester3Context : DbContext
    {
        public VitecMvSemester3Context (DbContextOptions<VitecMvSemester3Context> options)
            : base(options)
        {
        }

        public DbSet<VitecMvSemester3.Models.Produkt> Produkt { get; set; }
    }
}
