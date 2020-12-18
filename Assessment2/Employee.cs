using System;

namespace Assessment2
{
    public class Employee
    {
        public string FirstName { get; set; }

        public string Surname { get; set; }

        public double MonthlyPay { get; set; }

        public Employee(string firstname, string surname, double monthlyPay) //this alays expects this lol
        {
            MonthlyPay = monthlyPay;
            FirstName = firstname;
            Surname = surname;
        }

        public Employee()
        {
        }

        public override string ToString()
        {
            return string.Format($"{Surname}, {FirstName}");
        }

        
    }
}
