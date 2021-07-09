using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL_SERVICES.Models
{
    [Table("OrderDetails", Schema = "dbo")]
    public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        public Product Product {get; set;}

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }

        //public decimal Discount { get; set; }

        [Required]
        public long OrderId { get; set; }
        public Order Order { get; set; }

    }
}
