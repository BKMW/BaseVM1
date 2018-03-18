using BaseVM1.Models;
using BaseVM1.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

            DisplayEmployees();
        }
        #endregion
        #region constructor with parameters
        public EmployeesViewModel(INavigation nav)
        {

            DisplayEmployees();

            _nav = nav;
            CurrentPage = DependencyInject<EmployeesView>.Get();
            OpenPage();

        }

        public EmployeesViewModel(INavigation nav, ObservableCollection<Employee> employees)
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
        if (IsBusy)
            return;

        IsBusy = true;

        try
        {
            var employee=o as Employee;
           var page = DependencyService.Get<DetailViewModel>() ?? new DetailViewModel(_nav,employee);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        });


        #endregion
        #region RemoveEmployee Method Implementation

        public Command<Object> RemoveEmployee => new Command<Object>(async (Object o) =>
        {
        if (IsBusy)
            return;

        IsBusy = true;

        try
        {
            if (o != null)
            {
                var employee = o as Employee;
                await EmployeesDS.DeleteAsync(employee);
                    //remove employee frome list to refresh data in list view
                      Employees.Remove(employee);
                   
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
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
       
        #region ShowEmployees fun
        public ICommand ShowEmployees => new Command(async() =>
        {

            // IEnumerable<Employee> employees = await EmployeesDS.GetAllAsync(employee => employee.Name.Contains("r"));
            IEnumerable<Employee> employees = await EmployeesDS.GetAllAsync();
            foreach (Employee employee in employees)
            {
                Employees.Add(employee);
            }
        });
          
       async void DisplayEmployees()
        {
            IEnumerable<Employee> employees = await EmployeesDS.GetAllAsync();
            foreach (Employee employee in employees)
            {
                Employees.Add(employee);
            }
        }
        #endregion


    }
}
