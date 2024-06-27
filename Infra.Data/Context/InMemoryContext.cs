using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Context;

public class InMemoryContext : DbContext
{
    public InMemoryContext(DbContextOptions<InMemoryContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.OwnsOne(e => e.Name);
            entity.OwnsOne(e => e.Email);
        });

        base.OnModelCreating(modelBuilder);
    }
}
