using System;
using BrianGoncalves.SalaryCalculator.Interface;

namespace BrianGoncalves.SalaryCalculator.Application
{
	public enum Country
	{
		NoValidCountry,
		Germany,
		Italy,
		Ireland
	}
	public class CountryCalculatorFactory
	{
		public CountryCalculatorFactory()
		{
		}
		
		private static CountryCalculatorFactory instance;
		private static readonly object padlock = new object();

		public static CountryCalculatorFactory Instance
		{
			get
			{
				lock(padlock)
				{
					if (instance == null)
					{
						instance = new CountryCalculatorFactory();
					}
					return instance;
				}
			}
		}
		
		public ICountrySalaryCalculator Calculator(Country country)
		{			
			switch (country) {
				case Country.Italy:
					return new ItalySalaryCalculator();
				case Country.Germany:
					return new GermanySalaryCalculator();
				case Country.Ireland:
					return new IrelandSalaryCalculator();
				default:
					return new NoCountrySalaryCalculator();
			}
		}
	}
}
