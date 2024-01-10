using Jobstacle.Server.Data;
using Jobstacle.Server.Models;
using Jobstacle.Shared.Domain;
using Jobstacle.Server.Repository;
using Jobstacle.Server.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Jobstacle.Server.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext _context;
		private IGenericRepository<Company> _companies;
		private IGenericRepository<Course> _courses;
		private IGenericRepository<CourseRegistration> _courseregistrations;
		private IGenericRepository<JobApplication> _jobapplications;
		private IGenericRepository<JobSeeker> _jobseekers;
		private IGenericRepository<Staff> _staffs;
		private IGenericRepository<Organizer> _organizers;
		private IGenericRepository<Job> _jobs;

		private UserManager<ApplicationUser> _userManager;

		public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
		{
			_context = context;
			_userManager = userManager;
		}

		public IGenericRepository<Company> Companies
			=> _companies ??= new GenericRepository<Company>(_context);
		public IGenericRepository<Course> Courses
			=> _courses ??= new GenericRepository<Course>(_context);
		public IGenericRepository<CourseRegistration> CourseRegistrations
			=> _courseregistrations ??= new GenericRepository<CourseRegistration>(_context);
		public IGenericRepository<Job> Jobs
			=> _jobs ??= new GenericRepository<Job>(_context);
		public IGenericRepository<JobApplication> JobApplications
			=> _jobapplications ??= new GenericRepository<JobApplication>(_context);
		public IGenericRepository<JobSeeker> JobSeekers
            => _jobseekers ??= new GenericRepository<JobSeeker>(_context);
        public IGenericRepository<Organizer> Organizers
            => _organizers ??= new GenericRepository<Organizer>(_context);
        public IGenericRepository<Staff> Staffs
            => _staffs ??= new GenericRepository<Staff>(_context);


        public void Dispose()
		{
			_context.Dispose();
			GC.SuppressFinalize(this);
		}

		public async Task Save(HttpContext httpContext)
		{
			//To be implemented
			string user = "System";

			var entries = _context.ChangeTracker.Entries()
				.Where(q => q.State == EntityState.Modified ||
					q.State == EntityState.Added);

			foreach (var entry in entries)
			{
				((BaseDomainModel)entry.Entity).DateUpdated = DateTime.Now;
				((BaseDomainModel)entry.Entity).UpdatedBy = user;
				if (entry.State == EntityState.Added)
				{
					((BaseDomainModel)entry.Entity).DateCreated = DateTime.Now;
					((BaseDomainModel)entry.Entity).CreatedBy = user;
				}
			}

			await _context.SaveChangesAsync();
		}
	}
}