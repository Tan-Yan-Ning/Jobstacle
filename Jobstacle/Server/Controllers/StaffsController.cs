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
	public class StaffsController : ControllerBase
	{
		//private readonly ApplicationDbContext _context;
		private readonly IUnitOfWork _unitofWork;

		public StaffsController(IUnitOfWork unitofWork)
		{
			_unitofWork = unitofWork;
		}

		// GET: api/Staffs
		[HttpGet]
		public async Task<IActionResult> GetStaffs()
		{
			var staffs = await _unitofWork.Staffs.GetAll();
			return Ok(staffs);
		}

		// GET: api/Staffs/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetStaff(int id)
		{
			var staff = await _unitofWork.Staffs.Get(q => q.Id == id);

			if (staff == null)
			{
				return NotFound();
			}

			return Ok(staff);

		}

		// PUT: api/Staffs/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutStaff(int id, Staff staff)
		{
			if (id != staff.Id)
			{
				return BadRequest();
			}

			_unitofWork.Staffs.Update(staff);

			try
			{
				await _unitofWork.Save(HttpContext);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!await StaffExists(id))
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

		// POST: api/Staffs
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Staff>> PostStaff(Staff staff)
		{
			await _unitofWork.Staffs.Insert(staff);
			await _unitofWork.Save(HttpContext);

			return CreatedAtAction("GetStaff", new { id = staff.Id }, staff);
		}

		// DELETE: api/Staffs/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteStaff(int id)
		{
			var staff = await _unitofWork.Staffs.Get(q => q.Id == id);
			if (staff == null)
			{
				return NotFound();
			}

			await _unitofWork.Staffs.Delete(id);
			await _unitofWork.Save(HttpContext);

			return NoContent();
		}

		private async Task<bool> StaffExists(int id)
		{
			var staff = await _unitofWork.Staffs.Get(q => q.Id == id);
			return staff != null;
		}
	}
}
