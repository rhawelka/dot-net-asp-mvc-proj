using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace dot_net_academy_asp_mvc.Models.Entity
{
    public class MarkersDb : DbContext
    {
        public MarkersDb(DbContextOptions<MarkersDb> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Marker> Markers { get; set; }
    }
}
