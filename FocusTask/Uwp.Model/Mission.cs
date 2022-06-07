using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Uwp.SQLite.Model
{
    public enum Priority { No, Low, Medium, High }

    public class Mission : ObservableObject
    {
        public int Id { get; set; }

        private string _name;
        public string Name { get { return _name; } set { SetProperty(ref _name, value); } }

        private string _description;
        public string Description { get { return _description; } set { SetProperty(ref _description, value); } }

        private bool _isCompleted;
        public bool IsCompleted { get { return _isCompleted; } set { SetProperty(ref _isCompleted, value); } }

        private Priority _priority;
        public Priority Priority { get { return _priority; } set { SetProperty(ref _priority, value); } }

        private DateTime? _dueDate;
        public DateTime? DateTime { get { return _dueDate; } set { SetProperty(ref _dueDate, value); } }

        private DateTime? _reminder;
        public DateTime? Reminder { get { return _reminder; } set { SetProperty(ref _reminder, value); } }

        private DateTime? _created;
        public DateTime? Created { get { return _created; } set { SetProperty(ref _created, value); } }

        private int _repeat;
        public int Repeat { get { return _repeat; } set { SetProperty(ref _repeat, value); } }


        public int ProjectId { get; set; }

        private Project _project;   
        public Project Project
        {
            get { return _project; }
            set { SetProperty(ref _project, value); }
        }

        public Mission()
        {
            IsCompleted = false;
            Priority = Priority.No;
        }
    }
}
