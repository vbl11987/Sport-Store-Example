using System.ComponentModel.DataAnnotations;

namespace SportsStore.Models
{
    public class Product
    {
       public int ProductID { get; set; }
       [Required(ErrorMessage = "Please enter a product name")]
       public string Name { get; set; }
       [Required(ErrorMessage = "Please enter a product description")]
       public string Description { get; set; }
       [Required(ErrorMessage = "Please enter the product price")]
       public decimal Price { get; set; }
       [Required(ErrorMessage = "Please enter a product category")]
       public string Category { get; set; }
    }
}