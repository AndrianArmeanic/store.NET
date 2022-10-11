using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace StoreApplication.Models
{
    [Index (nameof(ProductModel.Name), IsUnique = true)]
    public class ProductModel : ModelBase
    {
        [Required]
        public string Name { get; set; } = default!;

        public string? Description { get; set; }

        [Required, DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }
}
