using System;
using System.ComponentModel.DataAnnotations;

namespace StoreApplication.Models
{
    public class ModelBase
    {
        public Guid Id { get; init; } = Guid.NewGuid ();

        [Required, DataType(DataType.DateTime)]
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
    }
}
