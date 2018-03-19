using BaseVM1.Models;
using BaseVM1.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BaseVM1.ViewModels
{
    class AddEmployeeViewModel : BaseViewModel
    {
        #region fields
        
        #endregion
        #region add properties
        public string Name { get; set; }
        public string GSM { get; set; }
        public string Department { get; set; }
        public string CIN { get; set; }
       
        #endregion 

        #region constructor
        public AddEmployeeViewModel(INavigation nav)
        {
         

            _nav = nav;
            CurrentPage = DependencyInject<AddEmployeeView>.Get();
            OpenPage();
        }
        #endregion

        #region AddEmloyee Method Implementation

        public ICommand SaveEmloyee => new Command(async() =>
        {
            try
            {
                var employee = new Employee
                {
                    Name = Name,
                    CIN = CIN,
                    Department = Department,
                    GSM = GSM,
                    IsVisible=false

                };
                await EmployeesDS.AddAsync(employee);
                //var page = DependencyService.Get<EmployeesViewModel>() ?? new EmployeesViewModel(_nav, Employees);
                var page = DependencyService.Get<EmployeesViewModel>() ?? new EmployeesViewModel(_nav);

            }
            catch (Exception ex)
            {
                ex.GetBaseException();
            }

            //var employee = new Employee(Name, GSM, Department, CIN);

            //Employees.Add(employee);
            //var page = DependencyService.Get<EmployeesViewModel>() ?? new EmployeesViewModel(_nav, Employees);

        });

        #endregion
    }
}
