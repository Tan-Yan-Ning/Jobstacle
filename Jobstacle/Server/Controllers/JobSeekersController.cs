using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Jobstacle.Server.Data;
using Jobstacle.Shared.Domain;
using Jobstacle.Server.IRepository;
using Jobstacle.Server.Repository;


namespace Jobstacle.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class JobSeekersController : ControllerBase
	{
		//private readonly ApplicationDbContext _context;
		private readonly IUnitOfWork _unitofWork;

		public JobSeekersController(IUnitOfWork unitofWork)
		{
			_unitofWork = unitofWork;
		}

		// GET: api/JobSeekers
		[HttpGet]
		public async Task<IActionResult> GetJobSeekers()
		{
			var jobseekers = await _unitofWork.JobSeekers.GetAll();
			return Ok(jobseekers);
		}

		// GET: api/JobSeekers/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetJobSeeker(int id)
		{
			var jobseeker = await _unitofWork.JobSeekers.Get(q => q.Id == id);

			if (jobseeker == null)
			{
				return NotFound();
			}

			return Ok(jobseeker);

		}

		// PUT: api/JobSeekers/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutJobSeeker(int id, JobSeeker jobseeker)
		{
			if (id != jobseeker.Id)
			{
				return BadRequest();
			}

			_unitofWork.JobSeekers.Update(jobseeker);

			try
			{
				await _unitofWork.Save(HttpContext);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!await JobSeekerExists(id))
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

		// POST: api/JobSeekers
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<JobSeeker>> PostJobSeeker(JobSeeker jobseeker)
		{
			await _unitofWork.JobSeekers.Insert(jobseeker);
			await _unitofWork.Save(HttpContext);

			return CreatedAtAction("GetJobSeeker", new { id = jobseeker.Id }, jobseeker);
		}

		// DELETE: api/JobSeekers/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteJobSeeker(int id)
		{
			var jobseeker = await _unitofWork.JobSeekers.Get(q => q.Id == id);
			if (jobseeker == null)
			{
				return NotFound();
			}

			await _unitofWork.JobSeekers.Delete(id);
			await _unitofWork.Save(HttpContext);

			return NoContent();
		}

		private async Task<bool> JobSeekerExists(int id)
		{
			var jobseeker = await _unitofWork.JobSeekers.Get(q => q.Id == id);
			return jobseeker != null;
		}
	}
}
