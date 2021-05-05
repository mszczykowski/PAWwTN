using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PS3.Forms;

namespace PS3.Data
{
    public class SearchContext : DbContext
    {
        public SearchContext(DbContextOptions options) : base(options) { }
        public DbSet<Search> Search { get; set; }
    }
}
