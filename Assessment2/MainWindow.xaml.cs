/*
Name: Konrad Szpak
Student Number: S00197298
Date 18 / 12 / 2020
Description: Assesment 2
*/

//%%%%%%%%%%%%%%             THERE ARE NO COMMENTS BECAUSE EVERYTHING IS OBVIOUS                     %%%%%%%%%%%%%%%%%%%%%%


using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Assessment2
{
    public partial class MainWindow : Window
    {
        ObservableCollection<Employee> employees = new ObservableCollection<Employee>(); //list
        ObservableCollection<Employee> tempEmployees = new ObservableCollection<Employee>(); //list

        public MainWindow()
        {
            InitializeComponent();
        }
        //happens when window is loaded
        private void lbxEmployees_Loaded(object sender, RoutedEventArgs e)
        {
            cbxFullTime.IsChecked = true; //presets the checkboxes
            cbxPartTime.IsChecked = true; //presets the checkboxes

        }
        //adds employee
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEmp();
        }
        //adds employee
        public void AddEmp()
        {
            if (tbxFirstName.Text != "" && tbxSurname.Text != "" && tbxSalary.Text != "" && rbFT.IsChecked == true && rbPT.IsChecked == false) //checks if everything is not empty 
            {
                double salary = double.Parse(tbxSalary.Text); 

                double monthlyPay = 0;

                FullTimeEmployee employee = new FullTimeEmployee(tbxFirstName.Text, tbxSurname.Text.ToUpper(), salary, rbFT.IsChecked == true, rbPT.IsChecked == null, monthlyPay);
                employees.Add(employee);
            }
            else if (tbxFirstName.Text != "" && tbxSurname.Text != "" && tbxHoursWorked.Text != "" && tbxHourlyRate.Text != "" && rbFT.IsChecked == false && rbPT.IsChecked == true)
            {
                double hourlyRate = double.Parse(tbxHourlyRate.Text);

                double hoursWorked = double.Parse(tbxHoursWorked.Text);

                double monthlyPay = 0;

                PartTimeEmployee employee = new PartTimeEmployee(tbxFirstName.Text, tbxSurname.Text.ToUpper(), hoursWorked, hourlyRate, rbFT.IsChecked == null, rbPT.IsChecked == true, monthlyPay);
                employees.Add(employee);
            }
            else
            {
                MessageBox.Show("fill everything in before adding");
            }
            RefreshEmployees2();
        }
        //takes data from the list and displays it back onto the screen
        private void lbxEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbxEmployees.SelectedItem is FullTimeEmployee)
            {
                FullTimeEmployee selectedFullTimeEmployee = lbxEmployees.SelectedItem as FullTimeEmployee;

                rbFT.IsChecked = selectedFullTimeEmployee.FullTime;
                rbPT.IsChecked = selectedFullTimeEmployee.PartTime;
                tbxFirstName.Text = selectedFullTimeEmployee.FirstName;
                tbxSurname.Text = selectedFullTimeEmployee.Surname;
                tbxSalary.Text = selectedFullTimeEmployee.Salary.ToString();
                tblkMonthlyPayNumber.Text = selectedFullTimeEmployee.CalculateMonthlyPay(selectedFullTimeEmployee.Salary, 12).ToString();
            }
            else if (lbxEmployees.SelectedItem is PartTimeEmployee)
            {
                PartTimeEmployee selectedPartTimeEmployee = lbxEmployees.SelectedItem as PartTimeEmployee;

                rbFT.IsChecked = selectedPartTimeEmployee.FullTime;
                rbPT.IsChecked = selectedPartTimeEmployee.PartTime;
                tbxFirstName.Text = selectedPartTimeEmployee.FirstName;
                tbxSurname.Text = selectedPartTimeEmployee.Surname;
                tbxHourlyRate.Text = selectedPartTimeEmployee.HourlyRate.ToString();
                tbxHoursWorked.Text = selectedPartTimeEmployee.HoursWorked.ToString();
                
                tblkMonthlyPayNumber.Text = selectedPartTimeEmployee.CalculateMonthlyPay(selectedPartTimeEmployee.HoursWorked, selectedPartTimeEmployee.HourlyRate).ToString();
            }
        }
        //delets the employee and add a new one with updated information
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (lbxEmployees.SelectedItem is FullTimeEmployee && tbxFirstName.Text != "" && tbxSurname.Text != "" && tbxSalary.Text != "")
            {
                FullTimeEmployee selectedFullTimeEmployee = lbxEmployees.SelectedItem as FullTimeEmployee;

                for (int i = 0; i < employees.Count; i++)
                {
                    if (selectedFullTimeEmployee == employees[i])
                    {
                        employees.Remove(employees[i]);
                    }
                }
                AddEmp();
            }
            else if (lbxEmployees.SelectedItem is PartTimeEmployee && tbxFirstName.Text != "" && tbxSurname.Text != "" && tbxHoursWorked.Text != "" && tbxHourlyRate.Text != "")
            {
                PartTimeEmployee selectedPartTimeEmployee = lbxEmployees.SelectedItem as PartTimeEmployee;

                for (int i = 0; i < employees.Count; i++)
                {
                    if (selectedPartTimeEmployee == employees[i])
                    {
                        employees.Remove(employees[i]);
                    }
                }
                AddEmp();
            }
            else if (lbxEmployees.SelectedItem == null)
                MessageBox.Show("select something!");
            else
                MessageBox.Show("fill in everything");
        }
        //clears text boxes
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearTextBoxes();
        }
        //deletes employee and clears the textboxes
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Employee selectedEmployee = lbxEmployees.SelectedItem as Employee;

            if (selectedEmployee != null)
            {
                ClearTextBoxes();

                for (int i = 0; i < employees.Count; i++)
                {
                    if (employees[i] == selectedEmployee)
                    {
                        employees.Remove(employees[i]);
                    }
                }
            }
            else
                MessageBox.Show("HOW CAN I DELETE NOTHING?!");

            RefreshEmployees2();
        }
        //clears text boxes
        public void ClearTextBoxes()
        {
            tbxFirstName.Text = null;
            tbxSurname.Text = null;
            tbxSalary.Text = null;
            tbxHoursWorked.Text = null;
            tbxHourlyRate.Text = null;
            rbFT.IsChecked = false;
            rbPT.IsChecked = false;
        }
        //refreshes emps
        private void cbx_Checked(object sender, RoutedEventArgs e)
        {
            RefreshEmployees2();
        }
        //refreshes emps
        public void RefreshEmployees2()
        {
            lbxEmployees.ItemsSource = null;
            tempEmployees.Clear();

            if (cbxFullTime.IsChecked == true && cbxPartTime.IsChecked == true)
            {
                lbxEmployees.ItemsSource = employees;
            }
            else if (cbxFullTime.IsChecked == true && cbxPartTime.IsChecked == false)
            {
                for (int i = 0; i < employees.Count; i++)
                {
                    if (employees[i] is FullTimeEmployee)
                    {
                        tempEmployees.Add(employees[i]);
                    }
                }
                lbxEmployees.ItemsSource = tempEmployees;
            }
            else if (cbxPartTime.IsChecked == true && cbxFullTime.IsChecked == false)
            {
                for (int i = 0; i < employees.Count; i++)
                {
                    if (employees[i] is PartTimeEmployee)
                    {
                        tempEmployees.Add(employees[i]);
                    }
                }
                lbxEmployees.ItemsSource = tempEmployees;
            }
        }
    }
}
