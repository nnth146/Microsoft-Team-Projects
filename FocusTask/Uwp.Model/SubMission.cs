using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Uwp.SQLite.Model
{
    public class SubMission : ObservableObject
    {
        public int Id { get; set; }

        private string _name;
        public string Name { get { return _name; } set { SetProperty(ref _name, value); } }

        private bool _isCompleted;
        public bool IsCompleted { get { return _isCompleted; } set { SetProperty(ref _isCompleted, value); } }

        
        public int MissionId { get; set; }
        public Mission Mission { get; set; }
    }
}
