using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL_SERVICES.Models
{
    [Table("Products", Schema = "dbo")]
    public class Product : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

       // [Required]
        [Display(Name = "Category")]
        public Category Category { get; set; }

        public int CategoryId { get; set; }

        [Required]
        [Display(Name = "ProductId")]
        public string ProductId { get; set; }

        [Required]
        [Display(Name = "ProductName")]
        public string ProductName { get; set; }

        [Required]
        [Display(Name = "ProductDescription")]
        public string ProductDescription { get; set; }
        [Required]
        [Display(Name = "ProductUrl")]
        public string ProductUrl { get; set; }

       // [Required]
        [Display(Name = "Merchant")]
        public Merchant Merchant { get; set; }

        public int MerchantId { get; set; }

        public string Size { get; set; }

        public string Weight { get; set; }

        public byte[] Image { get; set; }


    }
}
