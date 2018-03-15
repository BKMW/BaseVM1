using BaseVM1.ViewModels;
using BaseVM1.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace BaseVM1
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            //MainPage = new BaseVM1.MainPage();
            #region Intial page mvvm 
            var vm = DependencyInject<EmployeesViewModel>.Get();
            vm.CurrentPage = DependencyInject<EmployeesView>.Get();
            vm.CurrentPage.BindingContext = vm;
            var nav = new NavigationPage(vm.CurrentPage);
            vm._nav = nav.Navigation;
            MainPage = nav;
            #endregion
        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
