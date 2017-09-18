using System;
using BrianGoncalves.SalaryCalculator.Application;
using BrianGoncalves.SalaryCalculator.Interface;
using NUnit.Framework;

namespace BrianGoncalves.SalaryCalculator.UnitTest
{
	[TestFixture]
	public class GermanySalaryUnitTest
	{
		ICountrySalaryCalculator Calculator;
		[TestFixtureSetUp]
		public void Setup()
		{
			Calculator = CountryCalculatorFactory.Instance.Calculator(Country.Germany);
		}
		
		[TestFixtureTearDown]
		public void Teardown()
		{
			Calculator = null;
		}
		
		[Test]
		public void When_GrossIncome400_Expect_IncomeTax100()
		{
			// Arrange
			var incomeTax = 0m;
						
			// Act
			Calculator.Calculate(10, 40);
			incomeTax = Calculator.IncomeTax;
			
			// Assert
			Assert.AreEqual(100, incomeTax, "The income tax should be 100");
		}
		
		[Test]
		public void When_GrossIncome1000_Expect_IncomeTax292()
		{
			// Arrange
			var incomeTax = 0m;
						
			// Act
			Calculator.Calculate(20, 50);
			incomeTax = Calculator.IncomeTax;
			
			// Assert
			Assert.AreEqual(292, incomeTax, "The income tax should be 292");
		}
		
		[Test]
		public void When_GrossIncome1000_Expect_CompulsoryPension20()
		{
			// Arrange
			var pension = 0m;
						
			// Act
			Calculator.Calculate(20, 50);
			pension = Calculator.Pension;
			
			// Assert
			Assert.AreEqual(20, pension, "The Compulsory Pension should be 20");
		}
		
		[Test]
		public void When_GrossIncome1000_Expect_NetIncome565()
		{
			// Arrange
			var pension = 0m;
			var incomeTax = 0m;
			var netIncome = 0m;
			
			// Act
			Calculator.Calculate(20, 50);
			incomeTax = Calculator.IncomeTax;
			pension = Calculator.Pension;
			netIncome = Calculator.NetIncome;
			
			// Assert
			Assert.AreEqual(292, incomeTax, "The income tax should be 292");			
			Assert.AreEqual(20, pension, "The Compulsory Pension should be 20");
			Assert.AreEqual(688, netIncome, "The Net Income should be 688");
		}
	}
}
