using BaseVM1.Models;
using BaseVM1.Views;
using BaseVM1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BaseVM1.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        #region properties
        public string Login { get; set; }
        public string Password { get; set; }
       
        #endregion
        #region constructors
        public LoginViewModel()
        {

        }

        public LoginViewModel(INavigation nav)
        {
            _nav = nav;
            CurrentPage = DependencyInject<LoginView>.Get();
            OpenPage();
        }
        #endregion
        #region fun LoginCommand
        public ICommand LoginCommand => new Command(async() =>
        {
           
           IEnumerable <User> login = await UserDS.GetAllAsync(user => user.Name.Equals(Login) && user.Password.Equals(Password));
            //User CurrentUser = new User()
            //{
            //    Name = "root",
            //    Email = "root",
            //    Password = "root",
            //};
          
              if (login.Count() > 0)
                {
               // var page = DependencyService.Get<EmployeesViewModel>() ?? new EmployeesViewModel(_nav, Employees);
                var page = DependencyService.Get<EmployeesViewModel>() ?? new EmployeesViewModel(_nav);

            }
                else
                {
                   await CurrentPage.DisplayAlert("Invalid", "", "Ok");
                }
                
            

        });
        #endregion

        #region SingUpPage Method Implementation

        public ICommand SingUpPage => new Command(() =>
        {
           
                var page =  DependencyService.Get<SignUpViewModel>() ?? new SignUpViewModel (_nav);
           

            //var employee = new Employee(Name, GSM, Department, CIN);

            //Employees.Add(employee);
            //var page = DependencyService.Get<EmployeesViewModel>() ?? new EmployeesViewModel(_nav, Employees);

        });

        #endregion
    }
}
