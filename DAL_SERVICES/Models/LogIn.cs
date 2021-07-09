using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL_SERVICES.Models
{
    [Table("LogIns", Schema = "dbo")]
    public class LogIn
    {
        [Key]      
        public int Id { get; set; }

        public DateTime LastModified { get; set; } = DateTime.Now;

        public string Action { get; set; }

    }
}
