using System;
namespace SchoolAPI.Services
{
	public interface IPersonService<T>
	{
		T Create(T t);
		List<T> GetAll();
		T GetById(int id);
		IDictionary<string, string> GetAllFirstName();
		T Update(int id, T t);
		T UpdateSomeFields(int d, T t);
		List<T> FindByFisrtNameAndLastName(string str, int page, int limit);
		IDictionary<string, int> FindByFisrtNameAndLastNameSize(string str);
		IDictionary<string, string> Delete(int id);
	}
}

