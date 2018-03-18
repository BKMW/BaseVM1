using BaseVM1.Models;
using BaseVM1.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BaseVM1.ViewModels
{
    class DetailViewModel : BaseViewModel
    {
        #region fields
        #endregion
        #region properties

        public string Name { get; set; }
        public string GSM { get; set; }
        public string Department { get; set; }
        public string CIN { get; set; }

        public int ID;

        #endregion

        #region constructor without parameters
        public DetailViewModel()
        {

        }
        #endregion

        #region constructor with parameters
        public DetailViewModel(INavigation nav, Employee employee)
        {
            ID = employee.Id;
            Name = employee.Name;
            GSM = employee.GSM;
            Department = employee.Department;
            CIN = employee.CIN;
            _nav = nav;
            CurrentPage = DependencyInject<DetailView>.Get();
            OpenPage();

            //if (o != null)
            //{
            //    CurrentPage.BindingContext = o;
            //}

        }
        #endregion

        #region UpdateEmployee
        public ICommand UpdateEmployee => new Command(async() =>
        {

            //List<Employee> employee = Employees.Where(emp => emp.Name.Contains(Name)).ToList();

            //employee[0].GSM = GSM;
            //employee[0].Department = Department;
            //employee[0].CIN = CIN;

            var employee = new Employee
            {
                Id =ID,
                Name = Name,
                CIN = CIN,
                Department = Department,
                GSM = GSM,

            };

            await EmployeesDS.UpdateAsync(employee);

            // var page = DependencyService.Get<EmployeesViewModel>() ?? new EmployeesViewModel(_nav, Employees);
            var page = DependencyService.Get<EmployeesViewModel>() ?? new EmployeesViewModel(_nav);


        });

        #endregion
        #region DeleteEmployee
        public ICommand DeleteEmployee => new Command(async () =>
        {

            //List<Employee> employee = Employees.Where(emp => emp.Name.Contains(Name)).ToList();

            //employee[0].GSM = GSM;
            //employee[0].Department = Department;
            //employee[0].CIN = CIN;

            var employee = new Employee
            {
                Id = ID,
                Name = Name,
                CIN = CIN,
                Department = Department,
                GSM = GSM,

            };

            await EmployeesDS.DeleteAsync(employee);

           // var page = DependencyService.Get<EmployeesViewModel>() ?? new EmployeesViewModel(_nav, Employees);
            var page = DependencyService.Get<EmployeesViewModel>() ?? new EmployeesViewModel(_nav);


        });

        #endregion

    }
}
