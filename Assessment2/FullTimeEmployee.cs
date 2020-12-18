namespace Assessment2
{
    public class FullTimeEmployee : Employee
    {
        public double Salary { get; set; }

        public bool FullTime { get; set; }

        public bool PartTime { get; set; }

        public FullTimeEmployee(string firstname, string surname, double salary, bool fullTime, bool partTime, double monthlyPay)
            : base(firstname, surname, monthlyPay)
        {
            FullTime = fullTime;
            PartTime = partTime;
            Salary = salary;
        }
        
        public double CalculateMonthlyPay(double hourlyRate, double hoursWorked)
        {
            double monthlyPay;
            monthlyPay = hourlyRate / hoursWorked;
            return monthlyPay;
        }
        
    }
}
