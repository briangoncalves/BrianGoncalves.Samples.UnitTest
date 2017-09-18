using System;
using BrianGoncalves.SalaryCalculator.Interface;

namespace BrianGoncalves.SalaryCalculator.Application
{
	/// <summary>
	/// Description of GermanySalaryCalculator.
	/// </summary>
	public class GermanySalaryCalculator : ICountrySalaryCalculator
	{
		public GermanySalaryCalculator()
		{
		}
		
		#region ICountrySalaryCalculator implementation

		public void Calculate(decimal valueHour, int totalHours)
		{
			this.TotalHours = totalHours;
			this.ValueHour = valueHour;
			this.GrossIncome = valueHour * totalHours;
			this.Country = "Germany";
			this.Pension = this.CalculatePension(this.GrossIncome);			
			this.IncomeTax = this.CalculateIncomeTax(this.GrossIncome);			
			this.NetIncome = this.GrossIncome - this.IncomeTax - this.Pension;
		}
		
		private decimal CalculateIncomeTax(decimal grossIncome)
		{
			decimal grossIncomeTaxSecond = grossIncome - 400;
			decimal grossIncomeTaxFirst = 400;
			if (grossIncomeTaxSecond <= 0)
			{
				grossIncomeTaxSecond = 0;
				grossIncomeTaxFirst = grossIncome;
			}
			return (grossIncomeTaxFirst * 0.25m) + (grossIncomeTaxSecond * 0.32m);
		}
		
		private decimal CalculatePension(decimal grossIncome)
		{
			return grossIncome * 0.02m;
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
