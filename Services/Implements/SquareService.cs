using System;
using Newtonsoft.Json;

namespace SchoolAPI.Services.Implements
{
	public class SquareService : IMathService
	{
		private readonly ILogger<SquareService> _logger;

		public SquareService(ILogger<SquareService> logger)
		{
			_logger = logger;
		}

		public IDictionary<string, object> Calculate(string json)
		{
			IDictionary<string, object> dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(json)!;
			IDictionary<string, object> result = new Dictionary<string, object>();
			result["Type"] = "Square";

			string errMsg = "";

			if (!dict.ContainsKey("width"))
			{
				errMsg += "No 'width' value";
			}
			if (!dict.ContainsKey("long"))
			{
				if (errMsg.Length == 0)
				{
					errMsg += "No 'long' value";
				}
				else
				{
					errMsg += " and 'long' value";
				}
			}
			if (errMsg.Length == 0)
			{
				result["area"] = (float)Convert.ToInt32(dict["width"]) * (float)Convert.ToInt32(dict["long"]);
			}
			else
			{
				errMsg += " found";
				result["message"] = errMsg;
			}

			return result;
		}
	}
}

