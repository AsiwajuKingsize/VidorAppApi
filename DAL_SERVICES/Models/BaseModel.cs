using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_SERVICES.Models
{
    public class BaseModel
    {
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public DateTime LastModified { get; set; } = DateTime.Now;
    }
}
