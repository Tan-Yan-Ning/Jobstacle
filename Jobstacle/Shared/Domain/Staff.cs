﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Jobstacle.Shared.Domain
{
    public class Staff : BaseDomainModel
    {
        public byte[]? StaffPic { get; set; }
        [Required(ErrorMessage = "Name is required")]
		public string? Name { get; set; }

		[Required]
		[DataType(DataType.EmailAddress, ErrorMessage = "Email Address is not a valid email")]
		[EmailAddress]
		public string? Email { get; set; }

		[Required(ErrorMessage = "Department is required")]
		public string? Department { get; set; }

		[Required(ErrorMessage = "Position is required")]
		public string? Position { get; set; }

		[Required]
		[DataType(DataType.PhoneNumber)]
		[RegularExpression(@"(6|8|9)\d{7}", ErrorMessage = "Contact Number is not a valid phone number")]
		public string? ContactNumber { get; set; }
        public virtual List<Job>? Jobs { get; set; }
    }
}
