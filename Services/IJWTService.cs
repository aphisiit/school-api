using System;
namespace SchoolAPI.Services
{
	public interface IJWTService
	{
		IDictionary<string, object> VerifyToken(string token);
	}
}

