using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ProductManagementAPI.Model.Context;
using ProductManagementAPI.Repository.Interface;

namespace ProductManagementAPI.Repository.Implementation;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly ApplicationDBContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(ApplicationDBContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        var entities = await _dbSet.ToListAsync();

        return entities;
    }

    public async Task<T> GetById(int id)
    {
        var entity = await _dbSet.FindAsync(id);

        if (entity == null)
        {
            throw new Exception("Entity Doesn't Exists");
        }

        return entity;
    }

    public async Task Create(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public Task Update(T entity)
    {
        _dbSet.Update(entity);
        return Task.CompletedTask;
    }

    public async Task Delete(int id)
    {
        var entity = await GetById(id);
        _dbSet.Remove(entity);
    }
}