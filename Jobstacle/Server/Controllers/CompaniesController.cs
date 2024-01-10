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

namespace Jobstacle.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CompaniesController : ControllerBase
	{
		//private readonly ApplicationDbContext _context;
		private readonly IUnitOfWork _unitofWork;

		public CompaniesController(IUnitOfWork unitofWork)
		{
			_unitofWork = unitofWork;
		}

		// GET: api/Companies
		[HttpGet]
		public async Task<IActionResult> GetCompanies()
		{
			var companies = await _unitofWork.Companies.GetAll();
			return Ok(companies);
		}

		// GET: api/Companies/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetCompanie(int id)
		{
			var company = await _unitofWork.Companies.Get(q => q.Id == id);

			if (company == null)
			{
				return NotFound();
			}

			return Ok(company);

		}

		// PUT: api/Companies/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutCompanie(int id, Company company)
		{
			if (id != company.Id)
			{
				return BadRequest();
			}

			_unitofWork.Companies.Update(company);

			try
			{
				await _unitofWork.Save(HttpContext);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!await CompaniesExists(id))
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

		// POST: api/Companies
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Company>> PostCompanie(Company company)
		{
			await _unitofWork.Companies.Insert(company);
			await _unitofWork.Save(HttpContext);

			return CreatedAtAction("GetCompanie", new { id = company.Id }, company);
		}

		// DELETE: api/Companies/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteCompanie(int id)
		{
			var company = await _unitofWork.Companies.Get(q => q.Id == id);
			if (company == null)
			{
				return NotFound();
			}

			await _unitofWork.Companies.Delete(id);
			await _unitofWork.Save(HttpContext);

			return NoContent();
		}

		private async Task<bool> CompaniesExists(int id)
		{
			var company = await _unitofWork.Companies.Get(q => q.Id == id);
			return company != null;
		}
	}
}
