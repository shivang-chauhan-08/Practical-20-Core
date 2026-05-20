using ProductManagementAPI.Model.Context;
using ProductManagementAPI.Model.Entities;
using ProductManagementAPI.Repository.Interface;

namespace ProductManagementAPI.Repository.Implementation;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(ApplicationDBContext context) : base(context) {}
}