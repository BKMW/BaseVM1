using BaseVM1.Models;
using BaseVM1.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BaseVM1.ViewModels
{
    class SignUpViewModel : BaseViewModel
    {

        public string Name { get; set; }
        public string Password { get; set; }
        #region constructor
        public SignUpViewModel(INavigation nav)
        {
            _nav = nav;
            CurrentPage = DependencyInject<SingUpView>.Get();
            OpenPage();
        }
        #endregion
        
        #region Sing Up Method Implementation

        public ICommand SingUp => new Command(async () =>
        {
            try
            {
               var user = new User
                {
                    Name = Name,
                    Password = Password,


                };
                await UserDS.AddAsync(user);
                var page = DependencyService.Get<LoginViewModel>() ?? new LoginViewModel();
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
