using Jobstacle.Shared.Domain;
using Jobstacle.Server.IRepository;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jobstacle.Server.IRepository
{
	public interface IUnitOfWork : IDisposable
	{
		Task Save(HttpContext httpContext);
		IGenericRepository<Company> Companies { get; }
		IGenericRepository<Course> Courses { get; }
		IGenericRepository<CourseRegistration> CourseRegistrations { get; }
		IGenericRepository<JobApplication> JobApplications { get; }
		IGenericRepository<JobSeeker> JobSeekers { get; }
		IGenericRepository<Staff> Staffs { get; }
		IGenericRepository<Organizer> Organizers { get; }
		IGenericRepository<Job> Jobs { get; }
	}
}