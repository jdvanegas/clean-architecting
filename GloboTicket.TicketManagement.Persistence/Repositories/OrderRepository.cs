using GloboTicket.TicketManagement.Domain.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Persistence.Repositories
{
  public class OrderRepository : BaseRepository<Order>, IOrderRepository
  {
    public OrderRepository(DbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<Order>> GetPagedOrdersForMonth(DateTime date, int page, int size)
    {
      return await _dbSet.Where(o => o.OrderPlaced.Month == date.Month && o.OrderPlaced.Year == date.Year)
        .Skip((page - 1) * size).Take(size).AsNoTracking().ToListAsync();
    }

    public async Task<int> GetTotalCountOfOrdersForMonth(DateTime date)
    {
      return await _dbSet.CountAsync(o => o.OrderPlaced.Month == date.Month && o.OrderPlaced.Year == date.Year);
    }
  }
}