using System;
using BrianGoncalves.SalaryCalculator.Interface;

namespace BrianGoncalves.SalaryCalculator.Application
{
	/// <summary>
	/// Description of IrelandSalaryCalculator.
	/// </summary>
	public class IrelandSalaryCalculator : ICountrySalaryCalculator
	{
		public IrelandSalaryCalculator()
		{
		}
		
		#region ICountrySalaryCalculator implementation

		public void Calculate(decimal valueHour, int totalHours)
		{
			this.TotalHours = totalHours;
			this.ValueHour = valueHour;
			this.GrossIncome = valueHour * totalHours;
			this.Country = "Ireland";			
			this.Pension = this.CalculatePension(this.GrossIncome);
			this.IncomeTax = this.CalculateIncomeTax(this.GrossIncome);
			this.UniversalSocialCharge = this.CalculateUSC(this.GrossIncome);			
			this.NetIncome = this.GrossIncome - this.UniversalSocialCharge - this.IncomeTax - this.Pension;
		}
		
		private decimal CalculateIncomeTax(decimal grossIncome)
		{
			decimal grossIncomeTaxSecond = grossIncome - 600;
			decimal grossIncomeTaxFirst = 600;
			if (grossIncomeTaxSecond <= 0)
			{
				grossIncomeTaxSecond = 0;
				grossIncomeTaxFirst = grossIncome;
			}
			return (grossIncomeTaxFirst * 0.25m) + (grossIncomeTaxSecond * 0.40m);
		}
		
		private decimal CalculatePension(decimal grossIncome)
		{
			return grossIncome * 0.04m;
		}
		
		private decimal CalculateUSC(decimal grossIncome)
		{
			decimal grossIncomeUSCSecond = grossIncome - 500;
			decimal grossIncomeUSCFirst = 500;
			if (grossIncomeUSCSecond <= 0)
			{
				grossIncomeUSCSecond = 0;
				grossIncomeUSCFirst = grossIncome;
			}
			return (grossIncomeUSCFirst * 0.07m) + (grossIncomeUSCSecond * 0.08m);
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
