using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolAPI.Controllers
{
	[Route("api/[controller]")]
	public class JWTController : Controller
	{
		private ILogger<JWTController> logger;

		private IJWTService service;

		public JWTController(IJWTService service, ILogger<JWTController> _logger)
		{
			this.service = service;
			this.logger = _logger;
		}

		[HttpGet("VerifyToken")]
		[Produces("application/json")]
		public IDictionary<string, object> VerifyToken()
		{
			//foreach(var header in Request.Headers)
			//{

			//}
			Request.Headers.TryGetValue("authorization", out var tokenValue);
			logger.LogInformation($"token: {tokenValue}");
			return service.VerifyToken(tokenValue.ToString().Replace("Bearer ", ""));
		}

		// GET: api/values
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/values/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/values
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/values/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/values/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}

