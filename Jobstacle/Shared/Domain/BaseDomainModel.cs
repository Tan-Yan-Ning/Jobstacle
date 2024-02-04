using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobstacle.Shared.Domain
{
    public abstract class BaseDomainModel
    {
        public int Id { get; set; } 
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; } 
        public string? CreatedBy { get; set; } 
        public string? UpdatedBy { get;set; }
    }

    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime = Convert.ToDateTime(value);

            // Ensure the date is from today onwards
            return dateTime.Date >= DateTime.Now.Date;
        }
    }

   

}
