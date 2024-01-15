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
	public class CourseRegistrationsController : ControllerBase
	{
		//private readonly ApplicationDbContext _context;
		private readonly IUnitOfWork _unitofWork;

		public CourseRegistrationsController(IUnitOfWork unitofWork)
		{
			_unitofWork = unitofWork;
		}

		// GET: api/CourseRegistrations
		[HttpGet]
		public async Task<IActionResult> GetCourseRegistrations()
		{
			var courseregistrations = await _unitofWork.CourseRegistrations.GetAll(includes: q => q.Include(x => x.JobSeeker).Include(x => x.Course));
			return Ok(courseregistrations);
		}

		// GET: api/CourseRegistrations/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetCourseRegistration(int id)
		{
			var courseregistration = await _unitofWork.CourseRegistrations.Get(q => q.Id == id);

			if (courseregistration == null)
			{
				return NotFound();
			}

			return Ok(courseregistration);

		}

		// PUT: api/CourseRegistrations/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutCourseRegistration(int id, CourseRegistration courseregistration)
		{
			if (id != courseregistration.Id)
			{
				return BadRequest();
			}

			_unitofWork.CourseRegistrations.Update(courseregistration);

			try
			{
				await _unitofWork.Save(HttpContext);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!await CourseRegistrationExists(id))
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

		// POST: api/CourseRegistrations
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<CourseRegistration>> PostCourseRegistration(CourseRegistration courseregistration)
		{
			await _unitofWork.CourseRegistrations.Insert(courseregistration);
			await _unitofWork.Save(HttpContext);

			return CreatedAtAction("GetCourseRegistration", new { id = courseregistration.Id }, courseregistration);
		}

		// DELETE: api/CourseRegistrations/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteCourseRegistration(int id)
		{
			var courseregistration = await _unitofWork.CourseRegistrations.Get(q => q.Id == id);
			if (courseregistration == null)
			{
				return NotFound();
			}

			await _unitofWork.CourseRegistrations.Delete(id);
			await _unitofWork.Save(HttpContext);

			return NoContent();
		}

		private async Task<bool> CourseRegistrationExists(int id)
		{
			var courseregistration = await _unitofWork.CourseRegistrations.Get(q => q.Id == id);
			return courseregistration != null;
		}
	}
}
