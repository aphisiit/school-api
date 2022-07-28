using System;
namespace SchoolAPI.Services
{
	public interface IPersonService<T>
	{
		T Create(T t);
		List<T> GetAll();
		T GetById(int id);
		IDictionary<string, string> GetAllFirstName();
	}
}

