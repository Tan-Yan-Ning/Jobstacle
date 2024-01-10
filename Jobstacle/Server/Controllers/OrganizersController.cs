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
	public class OrganizersController : ControllerBase
	{
		//private readonly ApplicationDbContext _context;
		private readonly IUnitOfWork _unitofWork;

		public OrganizersController(IUnitOfWork unitofWork)
		{
			_unitofWork = unitofWork;
		}

		// GET: api/Organizers
		[HttpGet]
		public async Task<IActionResult> GetOrganizers()
		{
			var organizers = await _unitofWork.Organizers.GetAll();
			return Ok(organizers);
		}

		// GET: api/Organizers/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetOrganizer(int id)
		{
			var organizer = await _unitofWork.Organizers.Get(q => q.Id == id);

			if (organizer == null)
			{
				return NotFound();
			}

			return Ok(organizer);

		}

		// PUT: api/Organizers/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutOrganizer(int id, Organizer organizer)
		{
			if (id != organizer.Id)
			{
				return BadRequest();
			}

			_unitofWork.Organizers.Update(organizer);

			try
			{
				await _unitofWork.Save(HttpContext);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!await OrganizerExists(id))
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

		// POST: api/Organizers
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Organizer>> PostOrganizer(Organizer organizer)
		{
			await _unitofWork.Organizers.Insert(organizer);
			await _unitofWork.Save(HttpContext);

			return CreatedAtAction("GetOrganizer", new { id = organizer.Id }, organizer);
		}

		// DELETE: api/Organizers/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteOrganizer(int id)
		{
			var organizer = await _unitofWork.Organizers.Get(q => q.Id == id);
			if (organizer == null)
			{
				return NotFound();
			}

			await _unitofWork.Organizers.Delete(id);
			await _unitofWork.Save(HttpContext);

			return NoContent();
		}

		private async Task<bool> OrganizerExists(int id)
		{
			var organizer = await _unitofWork.Organizers.Get(q => q.Id == id);
			return organizer != null;
		}
	}
}
