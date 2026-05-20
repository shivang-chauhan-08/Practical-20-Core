using ProductManagementAPI.Repository.Interface;

namespace ProductManagementAPI.UnitOfWork;

public interface IUnitOfWork
{
    public IProductRepository Products { get; }

    Task<int> Save();
}