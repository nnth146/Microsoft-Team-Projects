using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Uwp.SQLite.Model
{
    public class Category : ObservableObject
    {
        public int Id { get; set; }

        private string _categoryName;
        public string CategoryName
        {
            get { return _categoryName; }
            set { SetProperty(ref _categoryName, value); }
        }

        private string _categoryDescription;
        public string CategoryDescription
        {
            get { return _categoryDescription; }
            set { SetProperty(ref _categoryDescription, value); }
        }

        private string _categoryIcon;
        public string CategoryIcon
        {
            get { return _categoryIcon; }
            set { SetProperty(ref _categoryIcon, value); }
        }
    }
}
