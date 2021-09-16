using Microsoft.EntityFrameworkCore;
using SI_Web_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SI_Web_API.Data
{
    public class SIDataContext : DbContext
    {
        public SIDataContext(DbContextOptions<SIDataContext> options) : base(options)
        {

        }

        public DbSet<SimpleInterest> SimpleInterests { get; set; }
    }
}
