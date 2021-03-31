using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestManagerV2.Models;

namespace TestManagerV2.Data
{
    public class TestManagerV2Context : DbContext
    {
        public TestManagerV2Context()
        {
            
        }
        public TestManagerV2Context (DbContextOptions<TestManagerV2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<TestManagerV2.Models.Test> Test { get; set; }
    }
}
