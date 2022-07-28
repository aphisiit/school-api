using System;
namespace SchoolAPI.Services
{
	public interface IMathService
	{
		IDictionary<string, object> Calculate(string json);
	}
}

