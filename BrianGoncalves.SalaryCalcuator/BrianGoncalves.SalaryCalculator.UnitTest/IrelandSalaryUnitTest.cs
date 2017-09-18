using System;
using BrianGoncalves.SalaryCalculator.Application;
using BrianGoncalves.SalaryCalculator.Interface;
using NUnit.Framework;

namespace BrianGoncalves.SalaryCalculator.UnitTest
{
	[TestFixture]
	public class IrelandSalaryUnitTest
	{		
		ICountrySalaryCalculator Calculator;		
		[TestFixtureSetUp]
		public void Setup()
		{			
			Calculator = CountryCalculatorFactory.Instance.Calculator(Country.Ireland);
		}
		
		[TestFixtureTearDown]
		public void Teardown()
		{
			Calculator = null;
		}
		
		[Test]
		public void When_GrossIncome600_Expect_IncomeTax150()
		{
			// Arrange
			var incomeTax = 0m;
						
			// Act
			Calculator.Calculate(15, 40);
			incomeTax = Calculator.IncomeTax;
			
			// Assert
			Assert.AreEqual(150, incomeTax, "The income tax should be 150");
		}
		
		[Test]
		public void When_GrossIncome1000_Expect_IncomeTax310()
		{
			// Arrange
			var incomeTax = 0m;
						
			// Act
			Calculator.Calculate(20, 50);
			incomeTax = Calculator.IncomeTax;
			
			// Assert
			Assert.AreEqual(310, incomeTax, "The income tax should be 310");
		}
		
		[Test]
		public void When_GrossIncome500_Expect_UniversalSocialCharge35()
		{
			// Arrange
			var universalSocialCharge = 0m;
						
			// Act
			Calculator.Calculate(10, 50);
			universalSocialCharge = Calculator.UniversalSocialCharge;
			
			// Assert
			Assert.AreEqual(35, universalSocialCharge, "The Universal Social Charge should be 35");
		}
		
		[Test]
		public void When_GrossIncome1000_Expect_UniversalSocialCharge75()
		{
			// Arrange
			var universalSocialCharge = 0m;
						
			// Act
			Calculator.Calculate(20, 50);
			universalSocialCharge = Calculator.UniversalSocialCharge;
			
			// Assert
			Assert.AreEqual(75, universalSocialCharge, "The Universal Social Charge should be 75");
		}
		
		[Test]
		public void When_GrossIncome1000_Expect_CompulsoryPension40()
		{
			// Arrange
			var pension = 0m;
						
			// Act
			Calculator.Calculate(20, 50);
			pension = Calculator.Pension;
			
			// Assert
			Assert.AreEqual(40, pension, "The Compulsory Pension should be 40");
		}
		
		[Test]
		public void When_GrossIncome1000_Expect_NetIncome575()
		{
			// Arrange
			var pension = 0m;
			var universalSocialCharge = 0m;
			var incomeTax = 0m;
			var netIncome = 0m;
			
			// Act
			Calculator.Calculate(20, 50);
			incomeTax = Calculator.IncomeTax;
			pension = Calculator.Pension;
			universalSocialCharge = Calculator.UniversalSocialCharge;
			netIncome = Calculator.NetIncome;
			
			// Assert
			Assert.AreEqual(310, incomeTax, "The income tax should be 310");
			Assert.AreEqual(75, universalSocialCharge, "The Universal Social Charge should be 75");
			Assert.AreEqual(40, pension, "The Compulsory Pension should be 40");
			Assert.AreEqual(575, netIncome, "The Net Income should be 575");
		}
	}
}
