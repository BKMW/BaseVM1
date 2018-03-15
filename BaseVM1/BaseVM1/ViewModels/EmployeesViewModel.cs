using BaseVM1.Models;
using BaseVM1.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BaseVM1.ViewModels
{
    class EmployeesViewModel : BaseViewModel
    {


        #region Fields

        #endregion
        #region Properties

        #endregion
        #region constructor without parameters
        public EmployeesViewModel()
        {

        }
        #endregion
        #region constructor with parameters

        public EmployeesViewModel(INavigation nav, ObservableCollection<Employee> employees=null)
        {

            Employees = employees;

            _nav = nav;
            CurrentPage = DependencyInject<EmployeesView>.Get();
            OpenPage();
         
        }
        #endregion

        #region EditEmployee Method Implementation

        //public Command<Object> EditEmployee => new Command<Object>(async (Object o) =>

        //{
        //    var nextPage = new DetailView
        //    {
        //        BindingContext = o
        //    };
        //    await _nav.PushAsync(nextPage);
        //    //await _nav.PushAsync(new DetailView());

        //});

        public Command<Object> EditEmployee => new Command<Object>( (Object o) =>

        {
           var employee=o as Employee;
           var page = DependencyService.Get<DetailViewModel>() ?? new DetailViewModel(_nav,employee);
        });


        #endregion
        #region RemoveEmployee Method Implementation

        public Command<Object> RemoveEmployee => new Command<Object>( (Object o) =>
        {

            if (o != null)
            {
                var employee = o as Employee;
                Employees.Remove(employee);
            }

        });

        #endregion
        #region AddEmployee Method Implementation

        public ICommand AddEmployee => new Command( () =>
        {
            {

                var page = DependencyService.Get<AddEmployeeViewModel>() ?? new AddEmployeeViewModel(_nav);
            }

        });

        #endregion
    
    }
}
