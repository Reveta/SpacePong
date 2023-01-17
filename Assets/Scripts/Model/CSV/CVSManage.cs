using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Model {
	public static class CvsManage {

		private const char Separate = '*';
		private const char SeparateEnd = ';';
		public static string Code(UserResult userResult) {
			return $"{userResult.Id}{Separate}" +
			       $"{userResult.Name}{Separate}" +
			       $"{userResult.Goals}{Separate}" +
			       $"{userResult.Score}{Separate}" +
			       $"{userResult.MaxSpeed}{SeparateEnd}";
		}

		public static UserResult Decode(string data) {
			var split = data.Split(Separate);
			UserResult userResult = new UserResult() {
				Id = Convert.ToInt32(split[0]),
				Name = split[1],
				Goals = Convert.ToInt32(split[2]),
				Score = Convert.ToInt32(split[3]),
				MaxSpeed = float.Parse(split[4], CultureInfo.InvariantCulture.NumberFormat)
			};

			return userResult;
		}
		
		public static List<UserResult> DecodeAll(string data) {
			var split = data.Split(SeparateEnd);
			return split
				.ToList()
				.FindAll(s => s.Length != 0)
				.Select(Decode)
				.ToList();
		}

	}
}