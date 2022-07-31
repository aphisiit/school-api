using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SchoolAPI.Models;
using SchoolAPI.Services;

namespace SchoolAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
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

		[HttpPut("{id}")]
		[Consumes("application/json")]
		[Produces("application/json")]
		public Student Update(int id, Student student)
		{
			return service.Update(id, student);
		}

		[HttpPatch("{id}")]
		[Consumes("application/json")]
		[Produces("application/json")]
		public Student UpdateSomeFields(int id, Student student)
		{
			return service.UpdateSomeFields(id, student);
		}

		[HttpGet("findByFirstNameAndLastName")]
		[Produces("application/json")]
		public List<Student> FindByFirstNameAndLastName(string? str, int page = 1, int limit = 10)
		{
			return service.FindByFisrtNameAndLastName(str, page, limit);
		}

		[HttpGet("findByFirstNameAndLastNameSize")]
		[Produces("application/json")]
		public IDictionary<string, int> FindByFirstNameAndLastName(string? str)
		{
			return service.FindByFisrtNameAndLastNameSize(str);
		}

		[HttpDelete("{id}")]
		[Produces("application/json")]
		public IDictionary<string, string> DeleteById(int id)
		{
			return service.Delete(id);
		}
	}
}

