using GloboTicket.TicketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GloboTicket.TicketManagement.Persistence.Configuration
{
  public class EventConfiguration : IEntityTypeConfiguration<Event>
  {
    public void Configure(EntityTypeBuilder<Event> builder)
    {
      builder.Property(e => e.Name).IsRequired().HasMaxLength(50);
      builder.Property(e => e.Price).HasColumnType("decimal(5, 2)");
    }
  }
}