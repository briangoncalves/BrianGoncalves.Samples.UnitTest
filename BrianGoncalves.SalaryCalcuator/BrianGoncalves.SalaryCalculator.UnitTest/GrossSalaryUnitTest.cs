using System;
using BrianGoncalves.SalaryCalculator.Application;
using BrianGoncalves.SalaryCalculator.Interface;
using NUnit.Framework;

namespace BrianGoncalves.SalaryCalculator.UnitTest
{
	[TestFixture]
	public class GrossSalaryUnitTest
	{		
		ICountrySalaryCalculator Calculator;
		[TestFixtureSetUp]
		public void Setup()
		{
			Calculator = CountryCalculatorFactory.Instance.Calculator(Country.NoValidCountry);
		}
		
		[TestFixtureTearDown]
		public void Teardown()
		{
			Calculator = null;
		}
		
		[Test]
		public void When_10PerHourFor40Hours_Expect_GrossIncome400()
		{
			// Arrange
			var grossIncome = 0m;
			
			// Act
			Calculator.Calculate(10, 40);
			grossIncome = Calculator.GrossIncome;
			
			// Assert
			Assert.AreEqual(400, grossIncome, "The gross income should be 400");
		}
	}
}
