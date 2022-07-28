using System;
using Microsoft.AspNetCore.Mvc;
using SchoolAPI.Models;
using SchoolAPI.Services;

namespace SchoolAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class StudentController : ControllerBase
	{
		private IPersonService<Student> service;

		public StudentController(IPersonService<Student> service)
		{
			this.service = service;
		}

		[HttpPost]
		[Consumes("application/json")]
		[Produces("application/json")]
		public Student Create(Student s)
		{
			return service.Create(s);
		}

		[HttpGet]
		[Produces("application/json")]
		public List<Student> GetStudents()
		{
			return service.GetAll();
		}

		[HttpGet("{id}")]
		[Produces("application/json")]
		public Student GetById(int id)
		{
			return service.GetById(id);
		}

		[HttpGet("GetFirstName")]
		[Produces("application/json")]
		public IDictionary<string, string> GetFirstName()
		{
			return service.GetAllFirstName();
		}
	}
}

