using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Jobstacle.Server.Data;
using Jobstacle.Shared.Domain;
using Jobstacle.Server.Repository;
using Jobstacle.Server.IRepository;

namespace Jobstacle.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class JobApplicationsController : ControllerBase
	{
		//private readonly ApplicationDbContext _context;
		private readonly IUnitOfWork _unitofWork;

		public JobApplicationsController(IUnitOfWork unitofWork)
		{
			_unitofWork = unitofWork;
		}

		// GET: api/JobApplications
		[HttpGet]
		public async Task<IActionResult> GetJobApplications()
		{
			var jobapplications = await _unitofWork.JobApplications.GetAll(includes: q => q.Include(x => x.Job).Include(x => x.JobSeeker));
			return Ok(jobapplications);
		}

		// GET: api/JobApplications/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetJobApplication(int id)
		{
			var jobapplication = await _unitofWork.JobApplications.Get(q => q.Id == id);

			if (jobapplication == null)
			{
				return NotFound();
			}

			return Ok(jobapplication);

		}

		// PUT: api/JobApplications/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutJobApplication(int id, JobApplication jobapplication)
		{
			if (id != jobapplication.Id)
			{
				return BadRequest();
			}

			_unitofWork.JobApplications.Update(jobapplication);

			try
			{
				await _unitofWork.Save(HttpContext);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!await JobApplicationExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/JobApplications
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<JobApplication>> PostJobApplication(JobApplication jobapplication)
		{
			await _unitofWork.JobApplications.Insert(jobapplication);
			await _unitofWork.Save(HttpContext);

			return CreatedAtAction("GetJobApplication", new { id = jobapplication.Id }, jobapplication);
		}

		// DELETE: api/JobApplications/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteJobApplication(int id)
		{
			var jobapplication = await _unitofWork.JobApplications.Get(q => q.Id == id);
			if (jobapplication == null)
			{
				return NotFound();
			}

			await _unitofWork.JobApplications.Delete(id);
			await _unitofWork.Save(HttpContext);

			return NoContent();
		}

		private async Task<bool> JobApplicationExists(int id)
		{
			var jobapplication = await _unitofWork.JobApplications.Get(q => q.Id == id);
			return jobapplication != null;
		}
	}
}
