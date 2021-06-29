using GloboTicket.TicketManagement.Domain.Entities;

namespace GloboTicket.TicketManagement.Domain.Contracts.Persistence
{
  public interface IOrderRepository : IAsyncRepository<Order>
  {
  }
}