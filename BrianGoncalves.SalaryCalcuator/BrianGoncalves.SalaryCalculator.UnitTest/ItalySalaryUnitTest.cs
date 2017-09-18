using System;
using BrianGoncalves.SalaryCalculator.Application;
using BrianGoncalves.SalaryCalculator.Interface;
using NUnit.Framework;

namespace BrianGoncalves.SalaryCalculator.UnitTest
{
	[TestFixture]
	public class ItalySalaryUnitTest
	{
		ICountrySalaryCalculator Calculator;
		[TestFixtureSetUp]
		public void Setup()
		{
			Calculator = CountryCalculatorFactory.Instance.Calculator(Country.Italy);
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
			Calculator.Calculate(10, 60);
			incomeTax = Calculator.IncomeTax;
			
			// Assert
			Assert.AreEqual(150, incomeTax, "The income tax should be 150");
		}
		
		[Test]
		public void When_GrossIncome1000_Expect_IncomeTax250()
		{
			// Arrange
			var incomeTax = 0m;
						
			// Act
			Calculator.Calculate(20, 50);
			incomeTax = Calculator.IncomeTax;
			
			// Assert
			Assert.AreEqual(250, incomeTax, "The income tax should be 250");
		}
		
		[Test]
		public void When_GrossIncome500_Expect_INPS45()
		{
			// Arrange
			var INPS = 0m;
						
			// Act
			Calculator.Calculate(10, 50);
			INPS = Calculator.INPS;
			
			// Assert
			Assert.AreEqual(45, INPS, "The INPS should be 45");
		}
		
		[Test]
		public void When_GrossIncome1000_Expect_INPS70()
		{
			// Arrange
			var INPS = 0m;
						
			// Act
			Calculator.Calculate(20, 50);
			INPS = Calculator.INPS;
			
			// Assert
			Assert.AreEqual(70, INPS, "The INPS should be 70");
		}
		
		[Test]
		public void When_GrossIncome1000_Expect_NetIncome565()
		{
			// Arrange
			var INPS = 0m;
			var incomeTax = 0m;
			var netIncome = 0m;
			
			// Act
			Calculator.Calculate(20, 50);
			incomeTax = Calculator.IncomeTax;
			INPS = Calculator.INPS;
			netIncome = Calculator.NetIncome;
			
			// Assert
			Assert.AreEqual(250, incomeTax, "The income tax should be 250");
			Assert.AreEqual(70, INPS, "The Universal Social Charge should be 70");
			Assert.AreEqual(680, netIncome, "The Net Income should be 680");
		}
	}
}
