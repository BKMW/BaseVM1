using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BaseVM1.Models
{
    class Employee
    {
       
       
        #region properties
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
                 
            
                
        public string CIN { get; set; }
        
         
           
        
        public string Name { get; set; }
        
        public string Department { get; set; }
       
        public string GSM { get; set; }
        public bool IsVisible { get; set; }

        //public ImageSource Image
        //{
        //    get { return _Image; }
        //    set
        //    {
        //        _Image = value;
        //    }
        //}
        #endregion
        #region constructor
        //public Employee(string Name = "", string GSM = "", string Department = "", string CIN = "")
        //{
        //    _GSM = GSM;
        //    _Name = Name;
        //    _Department = Department;
        //    _CIN = CIN;
        //}


        #endregion


    }
}
