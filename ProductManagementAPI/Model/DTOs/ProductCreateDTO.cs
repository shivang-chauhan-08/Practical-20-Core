using System.ComponentModel.DataAnnotations;

namespace ProductManagementAPI.Model.DTOs;

public class ProductCreateDTO
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    public string Brand { get; set; }
    [Required]
    public float Price { get; set; }
    public int Quantity { get; set; }
}