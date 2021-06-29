using GloboTicket.TicketManagement.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Domain.Contracts.Persistence
{
  public interface IEventRepository : IAsyncRepository<Event>
  {
    Task<bool> ExistEventNameAndDate(string name, DateTime date);
  }
}