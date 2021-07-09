using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL_SERVICES.Models
{
    [Table("Merchants", Schema = "dbo")]
    public class Merchant : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "MerchantId")]
        public string MerchantId { get; set; }

        [Required]
        [Display(Name = "MerchantName")]
        public string MerchantName { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "PhoneNumber")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "AccountNumber")]
        public string AccountNumber { get; set; }

        [Required]
        [Display(Name = "BankName")]
        public string BankName { get; set; }
    }
}
