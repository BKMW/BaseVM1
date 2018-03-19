using BaseVM1.Models;
using BaseVM1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BaseVM1.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EmployeesView : ContentPage
	{
		public EmployeesView ()
		{
			InitializeComponent ();
		}
        void LitView_OnItemTapped(Object sender, ItemTappedEventArgs e)
        {
           var vm = BindingContext as EmployeesViewModel;
           var employee = e.Item as Employee;
            vm.HideOrShowEmployee(employee);
        }

    }
}