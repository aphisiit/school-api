using System;
using Newtonsoft.Json;

namespace SchoolAPI.Services.Implements
{
	public class CircleService : IMathService
	{
		private readonly ILogger<CircleService> _logger;

		public CircleService(ILogger<CircleService> logger)
		{
			_logger = logger;
		}

		public IDictionary<string, object> Calculate(string json)
		{
			_logger.LogInformation("dict : {0}", json);

			IDictionary<string, object> dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(json)!;
			IDictionary<string, object> result = new Dictionary<string, object>();
			result["Type"] = "Circle";

			if (dict.ContainsKey("radius"))
			{
				_logger.LogInformation($"radius is {(float)Convert.ToInt32(dict["radius"]) }");
				result["area"] = Math.Pow((float)Convert.ToInt32(dict["radius"]), 2) * Math.PI;
			}
			else
			{
				result["error"] = "radius value not found";
			}

			return result;
		}
	}
}

