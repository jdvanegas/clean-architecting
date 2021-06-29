using GloboTicket.TicketManagement.Domain.Common;
using GloboTicket.TicketManagement.Domain.Entities;
using GloboTicket.TicketManagement.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Persistence
{
  public class GloboTicketDbContext : DbContext
  {
    public GloboTicketDbContext(DbContextOptions<GloboTicketDbContext> options) : base(options)
    {
    }

    public DbSet<Event> Events { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfigurationsFromAssembly(typeof(GloboTicketDbContext).Assembly);

      modelBuilder.HasCategoriesData();
      modelBuilder.HasEventsData();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
      foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
      {
        switch (entry.State)
        {
          case EntityState.Modified:
            entry.Entity.CreatedDate = DateTime.Now;
            break;

          case EntityState.Added:
            entry.Entity.LastModifiedDate = DateTime.Now;
            break;
        }
      }

      return base.SaveChangesAsync(cancellationToken);
    }
  }
}