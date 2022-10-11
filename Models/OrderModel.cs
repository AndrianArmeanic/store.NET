using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace StoreApplication.Models
{
    public sealed class OrderModel : ModelBase
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid ProductId { get; set; }
        
        [JsonIgnore, ForeignKey ("UserId")]
        public UserModel? User { get; set; }
        
        [JsonIgnore, ForeignKey ("ProductId")]
        public ProductModel? Product { get; set; }
    }
}
