using GloboTicket.TicketManagement.Domain.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Persistence.Repositories
{
  public class BaseRepository<T> : IAsyncRepository<T> where T : class
  {
    private readonly DbContext _dbContext;
    protected readonly DbSet<T> _dbSet;

    public BaseRepository(DbContext dbContext)
    {
      _dbContext = dbContext;
      _dbSet = _dbContext.Set<T>();
    }

    public async Task DisposeAsync()
    {
      await _dbContext.DisposeAsync();
      GC.SuppressFinalize(this);
    }

    public async Task<T> AddAsync(T entity)
    {
      await _dbSet.AddAsync(entity);
      await _dbContext.SaveChangesAsync();

      return entity;
    }

    public async Task DeleteAsync(T entity)
    {
      _dbSet.Remove(entity);
      await _dbContext.SaveChangesAsync();
    }

    public virtual async Task<T> GetByIdAsync(Guid id)
    {
      return await _dbSet.FindAsync(id);
    }

    public async Task<IReadOnlyList<T>> ListAllAsync()
    {
      return await _dbSet.ToListAsync();
    }

    public async Task UpdateAsync(T entity)
    {
      _dbContext.Entry(entity).State = EntityState.Modified;
      await _dbContext.SaveChangesAsync();
    }
  }
}