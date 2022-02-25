using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DhruviSoapSide.Models;

namespace DhruviSoapSide.Data
{
    public class DhruviSoapSideContext : DbContext
    {
        public DhruviSoapSideContext (DbContextOptions<DhruviSoapSideContext> options)
            : base(options)
        {
        }

        public DbSet<DhruviSoapSide.Models.Soaps> Soaps { get; set; }
    }
}
