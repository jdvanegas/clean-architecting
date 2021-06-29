using GloboTicket.TicketManagement.Domain.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Persistence.Repositories
{
  public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
  {
    public CategoryRepository(DbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<Category>> GetCategoriesWithEvents(bool includeHystory)
    {
      var allCategories = await _dbSet
        .Include(c => c.Events.Where(e => e.Date > DateTime.Today || includeHystory))
        .ToListAsync();

      return allCategories;
    }
  }
}