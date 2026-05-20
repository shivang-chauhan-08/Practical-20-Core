using System.ComponentModel.DataAnnotations;

namespace ProductManagementAPI.Model.Entities;

public class Product : BaseEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    public string Brand { get; set; }
    [Required]
    public float Price { get; set; }
    public int Quantity { get; set; }
}