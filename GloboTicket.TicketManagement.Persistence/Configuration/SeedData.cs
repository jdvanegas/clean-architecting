using GloboTicket.TicketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace GloboTicket.TicketManagement.Persistence.Configuration
{
  public static class SeedData
  {
    private static readonly Guid CONCERT_GUID = Guid.Parse("4681b8ce-32c0-43b6-a3ca-79135296f7d1");
    private static readonly Guid MUSICAL_GUID = Guid.Parse("4fa4e610-1649-409f-b972-eef1ce06adce");
    private static readonly Guid PLAY_GUID = Guid.Parse("d2749175-dd10-4118-8c2d-b6f7664af898");
    private static readonly Guid CONFERENCE_GUID = Guid.Parse("6ed5bd6d-28ef-4d83-813b-e1c3a914ea5b");

    public static void HasCategoriesData(this ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Category>().HasData(
        new Category
        {
          Id = CONCERT_GUID,
          Name = "Concerts"
        },
        new Category
        {
          Id = MUSICAL_GUID,
          Name = "Musicals"
        },
        new Category
        {
          Id = PLAY_GUID,
          Name = "Plays"
        },
        new Category
        {
          Id = CONFERENCE_GUID,
          Name = "Conferences"
        }
      );
    }

    public static void HasEventsData(this ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Event>().HasData(
        new Event
        {
          Id = Guid.NewGuid(),
          Name = "John Egbert Live",
          Price = 65,
          Artist = "John Egbert",
          Date = DateTime.Now.AddMonths(6),
          Description = "Join John for his farwell tour across 15 continents.",
          CategoryId = CONCERT_GUID,
          ImageUrl = "https://steamcdn-a.akamaihd.net/steamcommunity/public/images/avatars/64/64f9929bd65fe9ef897a5ad16ff472f04e5e9925"
        }
      );
    }
  }
}