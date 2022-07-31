using System;
using Microsoft.AspNetCore.Mvc;
using SchoolAPI.Models;
using SchoolAPI.Services;

namespace SchoolAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class TeacherController : ControllerBase
	{
		private readonly IPersonService<Teacher> service;

		private readonly ILogger<TeacherController> logger;

		public TeacherController(IPersonService<Teacher> service, ILogger<TeacherController> logger)
		{
			this.service = service;
			this.logger = logger;
		}

		[HttpPost]
		[Consumes("application/json")]
		[Produces("application/json")]
		public Teacher Create(Teacher t)
		{
			return service.Create(t);
		}

		[HttpGet]
		[Produces("application/json")]
		public List<Teacher> GetTeachers()
		{
			return service.GetAll();
		}

		[HttpGet("{id}")]
		[Produces("application/json")]
		public Teacher GetById(int id)
		{
			return service.GetById(id);
		}

		[HttpGet("GetFirstName")]
		[Produces("application/json")]
		public IDictionary<string, string> GetFirstName()
		{
			return service.GetAllFirstName();
		}

		[HttpPut("{id}")]
		[Consumes("application/json")]
		[Produces("application/json")]
		public Teacher Update(int id, Teacher teacher)
		{
			return service.Update(id, teacher);
		}

		[HttpPatch("{id}")]
		[Consumes("application/json")]
		[Produces("application/json")]
		public Teacher UpdateSomeFields(int id, Teacher teacher)
		{
			return service.UpdateSomeFields(id, teacher);
		}
	}
}

