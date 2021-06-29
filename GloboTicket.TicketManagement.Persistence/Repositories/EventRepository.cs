using GloboTicket.TicketManagement.Domain.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Persistence.Repositories
{
  public class EventRepository : BaseRepository<Event>, IEventRepository
  {
    public EventRepository(DbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> ExistEventNameAndDate(string name, DateTime eventDate)
    {
      var matches = await _dbSet.AnyAsync(e => e.Name.Equals(name) && e.Date.Date.Equals(eventDate.Date));
      return matches;
    }
  }
}