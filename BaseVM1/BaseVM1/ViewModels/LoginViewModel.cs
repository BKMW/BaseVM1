using BaseVM1.Models;
using BaseVM1.Views;
using System;
using System.Collections.Generic;
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
        User login = new User()
        {
            Name ="root",
            Email="root",
            Password="root",
        };
        #endregion
        #region constructor
        public LoginViewModel()
        {

        }
        //public LoginViewModel(INavigation nav)
        //{
        //    _nav = nav;
        //    CurrentPage = DependencyInject<LoginView>.Get();
        //    OpenPage();
        //}
        #endregion
        #region fun LoginCommand
        public ICommand LoginCommand => new Command(() =>
        {
            {
                if(Login != login.Name || Password != login.Password)
                {
                    CurrentPage.DisplayAlert("Invalid", "", "Ok");
                }
                else
                {
                    var page = DependencyService.Get<EmployeesViewModel>() ?? new EmployeesViewModel(_nav,Employees);
                }
                
            }

        });
        #endregion
    }
}
