using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShopBridge.Data.Entities
{
    public class ItemDetails : BaseEntity
    {
        [StringLength(150)]
        [Required]
        public string Name { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
        [StringLength(250)]
        [Required]
        public string Description { get; set; }
        public int ItemsInStock { get; set; }
    }
}
