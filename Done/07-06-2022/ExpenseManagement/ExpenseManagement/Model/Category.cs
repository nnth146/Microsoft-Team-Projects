using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagement.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }

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
