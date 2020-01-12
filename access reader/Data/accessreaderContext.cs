using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace accessreader.Models
{
    public class accessreaderContext : DbContext
    {
        public accessreaderContext (DbContextOptions<accessreaderContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<accessreader.Models.UserClass> UserClass { get; set; }
    }
}
