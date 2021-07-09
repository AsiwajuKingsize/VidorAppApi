using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL_SERVICES.Models
{
    [Table("Customers", Schema = "dbo")]
    public class Customer : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "CustomerId")]
        public string CustomerId { get; set; }

        [Required]
        [Display(Name = "CustomerName")]
        public string CustomerName { get; set; }

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

        //[Required]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
