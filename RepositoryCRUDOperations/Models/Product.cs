using System.ComponentModel.DataAnnotations;

namespace RepositoryCRUDOperations.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Product Name is required.")]
        public string? ProductName { get; set; }
        [Display(Name = "Price")]
        [Required(ErrorMessage = "Price is required.")]
        public double Price { get; set; }
        [Display(Name = "Quantity")]
        [Required(ErrorMessage = "Quantity is required.")]
        public int Quantity { get; set; }
    }
}
