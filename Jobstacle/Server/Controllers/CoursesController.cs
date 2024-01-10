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
	public class CourseControllersController : ControllerBase
	{
		//private readonly ApplicationDbContext _context;
		private readonly IUnitOfWork _unitofWork;

		public CourseControllersController(IUnitOfWork unitofWork)
		{
			_unitofWork = unitofWork;
		}

		// GET: api/CourseControllers
		[HttpGet]
		public async Task<IActionResult> GetCourseControllers()
		{
			var coursecontrollers = await _unitofWork.Courses.GetAll();
			return Ok(coursecontrollers);
		}

		// GET: api/CourseControllers/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetCourseController(int id)
		{
			var coursecontroller = await _unitofWork.Courses.Get(q => q.Id == id);

			if (coursecontroller == null)
			{
				return NotFound();
			}

			return Ok(coursecontroller);

		}

		// PUT: api/CourseControllers/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutCourseController(int id, Course coursecontroller)
		{
			if (id != coursecontroller.Id)
			{
				return BadRequest();
			}

			_unitofWork.Courses.Update(coursecontroller);

			try
			{
				await _unitofWork.Save(HttpContext);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!await CourseControllerExists(id))
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

		// POST: api/CourseControllers
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Course>> PostCourseController(Course coursecontroller)
		{
			await _unitofWork.Courses.Insert(coursecontroller);
			await _unitofWork.Save(HttpContext);

			return CreatedAtAction("GetCourseController", new { id = coursecontroller.Id }, coursecontroller);
		}

		// DELETE: api/CourseControllers/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteCourseController(int id)
		{
			var coursecontroller = await _unitofWork.Courses.Get(q => q.Id == id);
			if (coursecontroller == null)
			{
				return NotFound();
			}

			await _unitofWork.Courses.Delete(id);
			await _unitofWork.Save(HttpContext);

			return NoContent();
		}

		private async Task<bool> CourseControllerExists(int id)
		{
			var coursecontroller = await _unitofWork.Courses.Get(q => q.Id == id);
			return coursecontroller != null;
		}
	}
}
