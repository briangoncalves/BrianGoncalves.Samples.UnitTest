using System;

namespace BrianGoncalves.SalaryCalculator.Interface
{
	/// <summary>
	/// Description of ICountrySalaryCalculator.
	/// </summary>
	public interface ICountrySalaryCalculator
	{
		string Country { get; set; }
		decimal GrossIncome { get; set; }
		decimal ValueHour { get; set; }
		int TotalHours { get; set; }
		decimal NetIncome { get; set; }
		decimal Pension { get; set; }
		decimal IncomeTax { get; set; }
		decimal INPS { get; set; }
		decimal UniversalSocialCharge { get; set; }				
		void Calculate(decimal valueHour, int totalHour);
	}
}
