using System;
using System.Security.Cryptography;
using JWT;
using JWT.Algorithms;
using JWT.Exceptions;
using JWT.Serializers;
using Newtonsoft.Json;

namespace SchoolAPI.Services.Implements
{
	public class JWTService : IJWTService
	{
		private ILogger<JWTService> logger;

		private string certificate = @"REPLACE_PUBLIC_KEY_HERE";

		public JWTService(ILogger<JWTService> logger)
		{
			this.logger = logger;
		}

		public IDictionary<string, object> VerifyToken(string token)
		{
			try
			{
				//var 
				var keyBytes = Convert.FromBase64String(certificate);
				RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
				rsa.ImportSubjectPublicKeyInfo(keyBytes, out _);


				IJsonSerializer serializer = new JsonNetSerializer();
				IDateTimeProvider provider = new UtcDateTimeProvider();
				IJwtValidator validator = new JwtValidator(serializer, provider);
				IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
				IJwtAlgorithm algorithm = new RS256Algorithm(rsa);
				IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder, algorithm);

				var json = decoder.Decode(token);

				logger.LogInformation(json);
				//JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
				return JsonConvert.DeserializeObject<Dictionary<string, object>>(json); ;
			}
			catch (TokenNotYetValidException)
			{
				logger.LogError("Token is not valid yet");
				throw new Exception("Token is not valid yet");
			}
			catch (TokenExpiredException)
			{
				logger.LogError("Token has expired");
				throw new Exception("Token has expired");
			}
			catch (SignatureVerificationException)
			{
				logger.LogError("Token has invalid signature");
				throw new Exception("Token has invalid signature");
			}
		}
	}
}

