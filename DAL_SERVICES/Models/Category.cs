using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL_SERVICES.Models
{
    [Table("Categories", Schema = "dbo")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //[Required]
        [Display(Name = "CategoryId")]
        public string CategoryId { get; set; }

        [Required]
        [Display(Name = "CategoryName")]
        public string CategoryName { get; set; }
    }
}
