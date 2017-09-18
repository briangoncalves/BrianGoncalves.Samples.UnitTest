using System;

namespace BrianGoncalves.SalaryCalculator.Core
{
	public static class StringExtension
	{
		public static T ToEnum<T>(this string value, T defaultValue) where T : struct, IConvertible
		{
			if (string.IsNullOrEmpty(value))
			{
				return defaultValue;
			}

			T result;
			return Enum.TryParse<T>(value, true, out result) ? result : defaultValue;
		}
	}
}