using System;
using BrianGoncalves.SalaryCalculator.Interface;

namespace BrianGoncalves.SalaryCalculator.Application
{
	/// <summary>
	/// Description of ItalySalaryCalculator.
	/// </summary>
	public class ItalySalaryCalculator : ICountrySalaryCalculator
	{
		public ItalySalaryCalculator()
		{
		}
		
		#region ICountrySalaryCalculator implementation

		public void Calculate(decimal valueHour, int totalHours)
		{
			this.TotalHours = totalHours;
			this.ValueHour = valueHour;
			this.GrossIncome = valueHour * totalHours;
			this.Country = "Italy";
			this.INPS = this.CalculateINPS(this.GrossIncome);
			this.IncomeTax = this.CalculateIncomeTax(this.GrossIncome);
			this.NetIncome = this.GrossIncome - this.INPS - this.IncomeTax;
		}
		
		private decimal CalculateIncomeTax(decimal grossIncome)
		{
			return grossIncome * 0.25m;
		}
		
		private decimal CalculateINPS(decimal grossIncome)
		{
			decimal grossIncomeINPSSecond = grossIncome - 500;
			decimal grossIncomeINPSFirst = 500;
			decimal INPSExtra = 0;
			if (grossIncomeINPSSecond <= 0)
			{
				grossIncomeINPSSecond = 0;
				grossIncomeINPSFirst = grossIncome;
			} else {
				var percentage = Math.Truncate(grossIncomeINPSSecond / 100);
				INPSExtra = grossIncomeINPSSecond * (percentage/100);
			}			
			return (grossIncomeINPSFirst * 0.09m) + INPSExtra;
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
