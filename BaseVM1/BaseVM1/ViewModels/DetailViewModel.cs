using BaseVM1.Models;
using BaseVM1.Views;
using System;
using System.Collections.Generic;
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

        #endregion

        #region constructor without parameters
        public DetailViewModel()
        {

        }
        #endregion

        #region constructor with parameters
        public DetailViewModel(INavigation nav)
        {
           
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
        public ICommand UpdateEmployee => new Command(async () =>
        {

            //foreach (Employee employee in Employees)
            //{
            //    if (employee.Name.Equals(Name))
            //    {

            //        employee.Name = Name;
            //        employee.GSM = GSM;
            //        employee.Department = Department;
            //       // employee.CIN = CIN;
            //    }
            //}

            await _nav.PopAsync();
           // var page = DependencyService.Get<EmployeesViewModel>() ?? new EmployeesViewModel(_nav, Employees);

        });
 
         #endregion
      
    }
}
