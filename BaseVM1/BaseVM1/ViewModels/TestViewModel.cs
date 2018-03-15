using BaseVM1.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BaseVM1.ViewModels
{
    class TestViewModel : BaseViewModel
    {
        #region constructor
        public TestViewModel(INavigation nav)
        {
            //
            _nav = nav;
            CurrentPage = DependencyInject<EmployeesView>.Get();
            OpenPage();
            //
        }
        #endregion
    }
}
