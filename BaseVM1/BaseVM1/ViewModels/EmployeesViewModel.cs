using BaseVM1.Models;
using BaseVM1.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BaseVM1.ViewModels
{
    class EmployeesViewModel : BaseViewModel
    {


        #region Fields
        private Employee Old_Employee;
        private ObservableCollection<Employee> _Employees;
        public string _Search_Word;
        #endregion
        #region Properties

        public string Search_Word
        {
            get { return _Search_Word; }
            set { _Search_Word = value;
                OnPropertyChanged();
                SearchEmployees(_Search_Word);
            }

        }


    #endregion
    #region constructor without parameters
    public EmployeesViewModel()
        {
            //
            _Employees = new ObservableCollection<Employee>();
            //
            DisplayEmployees();
        }

        
        #endregion
        #region constructor with parameters
        public EmployeesViewModel(INavigation nav)
        {

            DisplayEmployees();
            //
            _Employees = new ObservableCollection<Employee>();
            //
            _nav = nav;
            CurrentPage = DependencyInject<EmployeesView>.Get();
            OpenPage();

        }

        //public EmployeesViewModel(INavigation nav, ObservableCollection<Employee> employees)
        //{

        //    Employees = employees;

        //    _nav = nav;
        //    CurrentPage = DependencyInject<EmployeesView>.Get();
        //    OpenPage();
         
        //}
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
                      _Employees.Remove(employee);
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
           

            var page = DependencyService.Get<AddEmployeeViewModel>() ?? new AddEmployeeViewModel(_nav);
            

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
                _Employees.Add(employee);
            }

        }
        #endregion
        #region Extandple liste 
        internal void HideOrShowEmployee(Employee employee)
        {

            if (Old_Employee == employee)
            {
                employee.IsVisible = !employee.IsVisible;

                UpdateItemList(employee);
            }
            else
            {
                if (Old_Employee != null)
                {
                    Old_Employee.IsVisible = false;

                    UpdateItemList(Old_Employee);
                }
                employee.IsVisible = !employee.IsVisible;

                UpdateItemList(employee);
            }
               
            Old_Employee = employee;

        }
        internal void UpdateItemList(Employee employee)
        {
            var index = Employees.IndexOf(employee);
            Employees.Remove(employee);
            Employees.Insert(index, employee);
        }
        #endregion

        #region SearchEmployees
        //public ICommand SearchEmployeess => new Command(() =>
        //{
        //    if (Search_Word != string.Empty)
        //    {

        //        List<Employee> employees = _Employees.Where(emp => emp.Name.ToLower().Contains(Search_Word.ToLower())).ToList();
        //        Employees.Clear();
        //        foreach (Employee employee in employees)
        //        {
        //            Employees.Add(employee);
        //        }
        //    }
        //    else { 
        //        Employees.Clear();
        //        foreach (Employee employee in _Employees)
        //        {
        //            Employees.Add(employee);
        //        }
        //    }


        //});

      
    
        //
        internal void SearchEmployees(string word)
        {

            if (Search_Word != string.Empty)
            {

                List<Employee> employees = _Employees.Where(emp => emp.Name.ToLower().Contains(Search_Word.ToLower())).ToList();
                Employees.Clear();
                foreach (Employee employee in employees)
                {
                    Employees.Add(employee);
                }
            }
            else
            {
                Employees.Clear();
                foreach (Employee employee in _Employees)
                {
                    Employees.Add(employee);
                }
            }
        }
        #endregion

    }
}
