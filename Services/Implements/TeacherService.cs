using System;
using SchoolAPI.Models;
using SqlKata.Execution;

namespace SchoolAPI.Services.Implements
{
	public class TeacherService : IPersonService<Teacher>
	{
		private readonly QueryFactory queryFactory;

		private readonly ILogger<TeacherService> logger;

		public TeacherService(ILogger<TeacherService> logger, QueryFactory queryFactory)
		{
			this.logger = logger;
			this.queryFactory = queryFactory;
		}

		public Teacher Create(Teacher t)
		{
			int id = queryFactory.Query("Teachers").Insert(t);
			logger.LogInformation($"Insert ID: {id}");
			Teacher teacher = GetById(id);
			return teacher;
		}

		public IDictionary<string, string> Delete(int id)
		{
			throw new NotImplementedException();
		}

		public List<Teacher> FindByFisrtNameAndLastName(string str, int page, int limit)
		{
			throw new NotImplementedException();
		}

		public IDictionary<string, int> FindByFisrtNameAndLastNameSize(string str)
		{
			throw new NotImplementedException();
		}

		public List<Teacher> GetAll()
		{
			var teachers = queryFactory.Query("Teachers").Get<Teacher>();
			return teachers.ToList();
		}

		public IDictionary<string, string> GetAllFirstName()
		{
			throw new NotImplementedException();
		}

		public Teacher GetById(int id)
		{
			var teacher = queryFactory.Query("Teachers").Where("ID", "=", id).First<Teacher>();
			return teacher;
		}

		public Teacher Update(int id, Teacher t)
		{
			int affected = queryFactory.Query("Teachers").Where("ID", id).Update(t);
			logger.LogInformation($"update affected {affected} rows");
			return GetById(id);
		}

		public Teacher UpdateSomeFields(int id, Teacher t)
		{
			int affected = queryFactory.Query("Teachers").Where("ID", id).Update(t);
			logger.LogInformation($"update affected {affected} rows");
			return GetById(id);
		}
	}
}

