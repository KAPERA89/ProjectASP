using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyThirdTest.Models
{
    [Table("Product", Schema = "Project")]
    public class Product
	{
        [Key]
        [Display(Name = "Product ID")]
        public int ProductID { get; set; }

        [Display(Name = "Product Name")]
        [Column(TypeName = "varchar(30)")]
        public string ProductName { get; set; } = string.Empty;

        [Display(Name = "Product Image")]
        [Column(TypeName = "varchar(300)")]
        public string? ProductImg { get; set; }

        [Display(Name = "Product price")]
        [Column(TypeName = "decimal(12,2)")]
        public decimal prix { get; set; }
    }
}

