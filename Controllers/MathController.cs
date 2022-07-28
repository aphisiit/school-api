using System;
using Microsoft.AspNetCore.Mvc;
using SchoolAPI.Services;
using static SchoolAPI.Startup;

namespace SchoolAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class MathController: ControllerBase
	{
		private IMathService circleService;
		private IMathService squareService;

		public MathController(ServiceResolver serviceResolver)
		{
			circleService = serviceResolver("Circle");
			squareService = serviceResolver("Square");
		}

		[HttpPost("circle")]
		[Consumes("application/json")]
		[Produces("application/json")]
		public IDictionary<string, object> CalculateCircle(string json)
		{
			return circleService.Calculate(json);
		}

		[HttpPost("square")]
		[Consumes("application/json")]
		[Produces("application/json")]
		public IDictionary<string, object> CalculateSquare(string json)
		{
			return squareService.Calculate(json);
		}
	}
}

