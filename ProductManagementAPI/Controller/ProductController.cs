using Microsoft.AspNetCore.Mvc;
using ProductManagementAPI.Model.Entities;
using ProductManagementAPI.UnitOfWork;

namespace ProductManagementAPI.Controller;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IUnitOfWork _uow;

    public ProductController(IUnitOfWork uow)
    {
        _uow = uow;
    }

    [HttpGet]
    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        return await _uow.Products.GetAll();
    }

    [HttpGet("id")]
    public async Task<Product> GetProductById(int id)
    {
        return await _uow.Products.GetById(id);
    }

    [HttpPost]
    public async Task CreateProduct(Product product)
    {
        await _uow.Products.Create(product);
        await _uow.Save();
    }

    [HttpPut]
    public async Task UpdateProduct(Product product)
    {
        await _uow.Products.Update(product);
        await _uow.Save();
    }

    [HttpDelete]
    public async Task DeleteProduct(int id)
    {
        await _uow.Products.Delete(id);
        await _uow.Save();
    }
    
    [HttpGet("exception")]
    public Task<IActionResult> TestException()
    {
        throw new Exception("Test Exception");
    }
}