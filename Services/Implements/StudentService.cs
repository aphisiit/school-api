using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SchoolAPI.Contexts;
using SchoolAPI.Models;

namespace SchoolAPI.Services.Implements
{
	public class StudentService : IPersonService<Student>
	{
		private readonly ILogger<StudentService> logger;
		private readonly TrainingContext trainContext;

		public StudentService(ILogger<StudentService> logger, TrainingContext context)
		{
			trainContext = context;
			this.logger = logger;
		}

		public Student Create(Student t)
		{
			trainContext.Add(t);
			trainContext.SaveChanges();

			return t;
		}

		public IDictionary<string, string> Delete(int id)
		{
			Dictionary<string, string> map = new Dictionary<string, string>();
			try
			{
				Student student = GetById(id);
				trainContext.Remove(student);
				trainContext.SaveChanges();
				map["message"] = "delete successful";
			}
			catch(Exception e)
			{
				map["message"] = "delete unsuccessful";
				map["error-message"] = e.Message.ToString();
			}
			return map;
		}

		public List<Student> FindByFisrtNameAndLastName(string str, int page, int limit)
		{
			int skip = page;
			int size = limit;
			List<Student> students = trainContext.Students.Where(x =>
				EF.Functions.Like(x.FisrtName.ToLower(), $"%{str}%")
				||
				EF.Functions.Like(x.LastName.ToLower(), $"%{str}%")
			).Skip(skip - 1).Take(size).ToList();

			return students;
		}

		public IDictionary<string, int> FindByFisrtNameAndLastNameSize(string str)
		{
			int count = trainContext.Students.Where(x =>
				   EF.Functions.Like(x.FisrtName.ToLower(), $"%{str}%")
				   ||
				   EF.Functions.Like(x.LastName.ToLower(), $"%{str}%")
			).Count();

			IDictionary<string, int> map = new Dictionary<string, int>();
			map["count"] = count;

			return map;
		}

		public List<Student> GetAll()
		{
			return trainContext.Students.ToList();
		}

		public IDictionary<string, string> GetAllFirstName()
		{
			var obj = from s in trainContext.Students
					  select new
					  {
						  IDNew = s.ID,
						  FirstNameNew = s.FisrtName
					  };
			Dictionary<string, string> d = new Dictionary<string, string>();
			foreach(var x in obj)
			{
				d[$"firstName-{x.IDNew}"] = x.FirstNameNew;
			}
			return d;
		}

		public Student GetById(int id)
		{
			return trainContext.Students.Where(x => x.ID == id).FirstOrDefault();
		}

		public Student Update(int id, Student t)
		{
			t.ID = id;
			trainContext.Entry(t).State = EntityState.Modified;
			trainContext.SaveChanges();

			return t;
		}

		public Student UpdateSomeFields(int id, Student s)
		{
			var data = GetById(id);

			if(s.FisrtName != null && s.FisrtName.Length != 0)
			{
				data.FisrtName = s.FisrtName;
			}
			if (s.LastName != null && s.LastName.Length != 0)
			{
				data.LastName = s.LastName;
			}
			if (s.Age != null)
			{
				data.Age = s.Age;
			}
			if (s.Sex != null && s.Sex.ToString() != "")
			{
				data.Sex = s.Sex;
			}

			trainContext.Entry(data).State = EntityState.Modified;
			trainContext.SaveChanges();

			return data;
		}
	}
}

