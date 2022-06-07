using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Uwp.SQLite.Model
{
    public class Project : ObservableObject
    {
        public int Id { get; set; }

        private string _name;
        public string Name { get { return _name; } set { SetProperty(ref _name, value); } }

        private string _color;
        public string Color { get { return _color; } set { SetProperty(ref _color, value); } }

        private DateTime? _created;
        public DateTime? Created { get { return _created; } set { SetProperty(ref _created, value); } }


        public ObservableCollection<Mission> Missions { get; set; } = new ObservableCollection<Mission>();
    }
}
