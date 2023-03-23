using Microsoft.EntityFrameworkCore;
using MusalaSoftDrones.Api.DomainEntities;
using System.Collections.Generic;

namespace MusalaSoftDrones.Api.Data
{
    public class MusalaSoftAppApiContext : DbContext
    {
        public MusalaSoftAppApiContext(DbContextOptions<MusalaSoftAppApiContext> options)
            : base(options)
        {
        }

        public DbSet<Medication> Medication { get; set; } = default!;

        public DbSet<Drone>? Drone { get; set; }
    }
}
