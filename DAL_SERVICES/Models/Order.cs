using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL_SERVICES.Models
{
    [Table("Orders", Schema = "dbo")]
    public class Order : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string OrderId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        [Required]
        public decimal SumTotal { get; set; }

        public string SessionId { get; set; }

        public string DeliveryAddress { get; set; }


        public ICollection<OrderDetail> OrderDetail { get; set; }

    }
}
