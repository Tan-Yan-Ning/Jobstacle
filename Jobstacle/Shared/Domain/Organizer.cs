using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobstacle.Shared.Domain
{
    public class Organizer : BaseDomainModel
    {
		[Required(ErrorMessage = "Name is required")]
		public string? Name { get; set; }

		[Required]
		[DataType(DataType.PhoneNumber)]
		[RegularExpression(@"(6|8|9)\d{7}", ErrorMessage = "Contact Number is not a valid phone number")]
		public string? ContactNumber { get; set; }

		[Required]
		[DataType(DataType.EmailAddress, ErrorMessage = "Email Address is not a valid email")]
		[EmailAddress]
		public string? Email { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string? Description { get; set; }

        public virtual List<Course>? Courses { get; set; }
    }
}
