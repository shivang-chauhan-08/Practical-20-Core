using ProductManagementAPI.Model.Context;
using ProductManagementAPI.Repository.Implementation;
using ProductManagementAPI.Repository.Interface;

namespace ProductManagementAPI.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    public IProductRepository Products { get; }
    private readonly ApplicationDBContext _context;

    public UnitOfWork(ApplicationDBContext context)
    {
        _context = context;
        Products = new ProductRepository(context);
    }

    public async Task<int> Save()
    {
        return await _context.SaveChangesAsync();
    }
}