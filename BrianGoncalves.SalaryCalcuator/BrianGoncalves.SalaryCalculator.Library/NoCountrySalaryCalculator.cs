using System;
using BrianGoncalves.SalaryCalculator.Interface;

namespace BrianGoncalves.SalaryCalculator.Application
{
	/// <summary>
	/// Description of NoCountrySalaryCalculator.
	/// </summary>
	public class NoCountrySalaryCalculator : ICountrySalaryCalculator
	{
		public NoCountrySalaryCalculator()
		{
		}

		#region ICountrySalaryCalculator implementation

		public void Calculate(decimal valueHour, int totalHours)
		{
			this.TotalHours = totalHours;
			this.ValueHour = valueHour;
			this.GrossIncome = valueHour * totalHours;
			this.Country = "No valid country specified";
		}

		public string Country {get;set;}
		public decimal GrossIncome{get;set;}
		public decimal ValueHour {get;set;}
		public int TotalHours {get;set;}
		public decimal NetIncome {get;set;}
		public decimal Pension {get;set;}
		public decimal IncomeTax {get;set;}
		public decimal INPS {get;set;}
		public decimal UniversalSocialCharge {get;set;}

		#endregion
	}
}
