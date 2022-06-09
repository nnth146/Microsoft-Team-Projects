using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace KeepSafeForPassword.Model
{
    public class NavViewItem : ObservableObject
    {
        public string Icon { get; set; }
        public string Title { get; set; }

        public IEnumerable<Password> Passwords { get; set; } = new ObservableCollection<Password>();
    }
}
