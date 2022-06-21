using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Uwp.SQLite.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }

        public ObservableCollection<Spending> Spendings { get; set; } = new ObservableCollection<Spending>();

        public Category()
        {
            this.Name = "";
            this.Icon = "";
        }

        public Category(int Id, string Name, string Icon)
        {
            this.Id = Id;
            this.Name = Name;
            this.Icon = Icon;
        }
    }
}
