using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BaseVM1.Models
{
    class Employee
    {
        #region fields
        private int _Id;
        private string _CIN;
        private string _Name;
        private string _Department;
        private string _GSM;
        // private ImageSource _Image;

        #endregion
       
        #region properties
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get { return _Id; }
            set
            {
                _Id = value;

            }
        }
        public string CIN
        {
            get { return _CIN; }
            set
            {
                _CIN = value;
            }
        }
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
            }
        }
        public string Department
        {
            get { return _Department; }
            set
            {
                _Department = value;
            }
        }
        public string GSM
        {
            get { return _GSM; }
            set
            {
                _GSM = value;
            }
        }
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
