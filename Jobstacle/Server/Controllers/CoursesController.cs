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
	public class CoursesController : ControllerBase
	{
		//private readonly ApplicationDbContext _context;
		private readonly IUnitOfWork _unitofWork;

		public CoursesController(IUnitOfWork unitofWork)
		{
			_unitofWork = unitofWork;
		}

		// GET: api/Courses
		[HttpGet]
		public async Task<IActionResult> GetCourses()
		{
			var courses = await _unitofWork.Courses.GetAll(includes: q => q.Include(x => x.Organizer).Include(x => x.Staff));
			return Ok(courses);
		}

		// GET: api/Courses/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetCourse(int id)
		{
			var course = await _unitofWork.Courses.Get(q => q.Id == id);

			if (course == null)
			{
				return NotFound();
			}

			return Ok(course);

		}

		// PUT: api/Courses/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutCourse(int id, Course course)
		{
			if (id != course.Id)
			{
				return BadRequest();
			}

			_unitofWork.Courses.Update(course);

			try
			{
				await _unitofWork.Save(HttpContext);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!await CourseExists(id))
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

		// POST: api/Courses
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Course>> PostCourse(Course course)
		{
			await _unitofWork.Courses.Insert(course);
			await _unitofWork.Save(HttpContext);

			return CreatedAtAction("GetCourse", new { id = course.Id }, course);
		}

		// DELETE: api/Courses/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteCourse(int id)
		{
			var course = await _unitofWork.Courses.Get(q => q.Id == id);
			if (course == null)
			{
				return NotFound();
			}

			await _unitofWork.Courses.Delete(id);
			await _unitofWork.Save(HttpContext);

			return NoContent();
		}

		private async Task<bool> CourseExists(int id)
		{
			var course = await _unitofWork.Courses.Get(q => q.Id == id);
			return course != null;
		}
	}
}
