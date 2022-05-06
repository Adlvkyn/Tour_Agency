#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TourFirm.Models;

namespace TourFirm.Data
{
    public class TourFirmContext : DbContext
    {
        public TourFirmContext (DbContextOptions<TourFirmContext> options)
            : base(options)
        {
        }

        public DbSet<TourFirm.Models.Tours> Tours { get; set; }

        public DbSet<TourFirm.Models.Customers> Customers { get; set; }

        public DbSet<TourFirm.Models.Agencies> Agencies { get; set; }
    }
}
