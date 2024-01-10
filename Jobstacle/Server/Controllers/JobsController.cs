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
	public class JobsController : ControllerBase
	{
		//private readonly ApplicationDbContext _context;
		private readonly IUnitOfWork _unitofWork;

		public JobsController(IUnitOfWork unitofWork)
		{
			_unitofWork = unitofWork;
		}

		// GET: api/Jobs
		[HttpGet]
		public async Task<IActionResult> GetJobs()
		{
			var jobs = await _unitofWork.Jobs.GetAll();
			return Ok(jobs);
		}

		// GET: api/Jobs/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetJob(int id)
		{
			var job = await _unitofWork.Jobs.Get(q => q.Id == id);

			if (job == null)
			{
				return NotFound();
			}

			return Ok(job);

		}

		// PUT: api/Jobs/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutJob(int id, Job job)
		{
			if (id != job.Id)
			{
				return BadRequest();
			}

			_unitofWork.Jobs.Update(job);

			try
			{
				await _unitofWork.Save(HttpContext);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!await JobExists(id))
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

		// POST: api/Jobs
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Job>> PostJob(Job job)
		{
			await _unitofWork.Jobs.Insert(job);
			await _unitofWork.Save(HttpContext);

			return CreatedAtAction("GetJob", new { id = job.Id }, job);
		}

		// DELETE: api/Jobs/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteJob(int id)
		{
			var job = await _unitofWork.Jobs.Get(q => q.Id == id);
			if (job == null)
			{
				return NotFound();
			}

			await _unitofWork.Jobs.Delete(id);
			await _unitofWork.Save(HttpContext);

			return NoContent();
		}

		private async Task<bool> JobExists(int id)
		{
			var job = await _unitofWork.Jobs.Get(q => q.Id == id);
			return job != null;
		}
	}
}
