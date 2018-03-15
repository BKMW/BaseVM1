using BaseVM1.Models;
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

        public ObservableCollection<Employee> Employees { get; set; }
        #region List of Names  

        private string[] Names = new string[]
        {
            "Mohamed", "Bachir", "Fawzi", "Imen", "Emna", "Salwa",
        };


        #endregion
        #region constructor
        public BaseViewModel()
        {
            Employees = new ObservableCollection<Employee>();
            Random r = new Random();
            foreach (var name in Names)
            {
                var employee = new Employee(name, r.Next(216, 870).ToString() + "-" + r.Next(22222222, 22999999))
                {
                    Image = ImageSource.FromResource("Auth1.Images.image" + r.Next(1, 3) + ".png")
                };
                Employees.Add(employee);
            }
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