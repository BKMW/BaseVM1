using BaseVM1.Models;
using Root.Services.Sqlite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace BaseVM1.ViewModels
{
    class BaseViewModel : INotifyPropertyChanged
    {
        #region private 

        #region properties
        public IDataStore<Employee> EmployeesDS => DependencyService.Get<IDataStore<Employee>>() ?? new DataStore<Employee>("DB.db3");
        public IDataStore<User> UserDS => DependencyService.Get<IDataStore<User>>() ?? new DataStore<User>("DB.db3");
        #endregion

        public ObservableCollection<Employee> Employees { get; set; }
        #region List of Names  

       

        #endregion
        #region constructor
         public BaseViewModel()
        {
            Employees = new ObservableCollection<Employee>();
            UserDS.CreateTableAsync();
            EmployeesDS.CreateTableAsync();


        }
        #endregion

        #endregion
        #region general
        public INavigation _nav;
        public ContentPage CurrentPage { get; set; }

        public void OpenPage()
        {

            if (CurrentPage != null)
            {
                CurrentPage.BindingContext = this;
                _nav.PushAsync(CurrentPage);
            }
        }

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #endregion
    }
}