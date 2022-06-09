using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace KeepSafeForPassword.Model
{
    public class Password : ObservableObject
    {
        public int Id { get; set; }

        private string _title;
        public string Title { get { return _title; } set { SetProperty(ref _title, value); } }

        public DateTime CreatedOn { get; set; }

        public Password()
        {
            CreatedOn = DateTime.Now;
        }
    }
}
