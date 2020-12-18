namespace Assessment2
{
    public class PartTimeEmployee : Employee
    {
        public double HoursWorked { get; set; }

        public double HourlyRate { get; set; }

        public bool FullTime { get; set; }

        public bool PartTime { get; set; }

        public PartTimeEmployee(string firstname, string surname, double hoursWorked, double hourlyRate, bool fullTime, bool partTime, double monthlyPay)
            : base(firstname, surname, monthlyPay)
        {
            FullTime = fullTime;
            PartTime = partTime;
            HoursWorked = hoursWorked;
            HourlyRate = hourlyRate;
        }
        
        public double CalculateMonthlyPay(double hourlyRate, double hoursWorked)
        {
            double monthlyPay;
            monthlyPay = hourlyRate * hoursWorked;
            return monthlyPay;
        }
    }
}
