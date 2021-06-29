using GloboTicket.TicketManagement.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Domain.Contracts.Persistence
{
  public interface ICategoryRepository : IAsyncRepository<Category>
  {
    Task<IEnumerable<Category>> GetCategoriesWithEvents(bool includeHystory);
  }
}