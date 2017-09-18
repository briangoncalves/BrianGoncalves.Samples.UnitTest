using System;
using BrianGoncalves.SalaryCalculator.Interface;
using BrianGoncalves.SalaryCalculator.Application;
using BrianGoncalves.SalaryCalculator.Core;

namespace BrianGoncalves.SalaryCalculator.ConsoleApp
{
	class Program
	{
		public static void Main(string[] args)
		{
			var hoursWorkedString = "";
			int hoursWorked;
			do
			{
				Console.Write("Please enter the hours worked: ");
				hoursWorkedString = Console.ReadLine();				
			} while (!int.TryParse(hoursWorkedString, out hoursWorked));
 
			var hourlyRateString = "";
			decimal hourlyRate;
			do
			{
				Console.Write("Please enter the hourly rate: ");
				hourlyRateString = Console.ReadLine();
			} while (!decimal.TryParse(hourlyRateString, out hourlyRate));
			
			Console.Write(@"Please enter the employee's location: ");
			var country = Console.ReadLine();
			
			ICountrySalaryCalculator Calculator = CountryCalculatorFactory.Instance.Calculator(
				country.ToEnum<Country>(Country.NoValidCountry)
			);
			Calculator.Calculate(hourlyRate, hoursWorked);
			
			Console.WriteLine("Employee location: " + Calculator.Country);
			Console.WriteLine();
			Console.WriteLine("Gross Amount: " + Calculator.GrossIncome);
			Console.WriteLine();			
			Console.WriteLine("Less deductions");
			Console.WriteLine();
			if (Calculator.IncomeTax > 0)
				Console.WriteLine("Income Tax: " + Calculator.IncomeTax);
			if (Calculator.UniversalSocialCharge > 0)
				Console.WriteLine("Universal Social Charge: " + Calculator.UniversalSocialCharge);
			if (Calculator.Pension > 0)
				Console.WriteLine("Pension: " + Calculator.Pension);
			if (Calculator.INPS > 0)
				Console.WriteLine("INPS: " + Calculator.INPS);
			Console.WriteLine("Net Amount: " + Calculator.NetIncome);

			
			Console.ReadKey(true);
		}
	}
}