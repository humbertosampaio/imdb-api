using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/movies")]
	[ApiController]
	public class MoviesController : ControllerBase
	{
		// GET: api/<MoviesController>
		[HttpGet]
		public IEnumerable<Movie> Get([FromServices]DataContext dataContext)
		{
			return null;
		}

		// GET api/<MoviesController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<MoviesController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<MoviesController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<MoviesController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
