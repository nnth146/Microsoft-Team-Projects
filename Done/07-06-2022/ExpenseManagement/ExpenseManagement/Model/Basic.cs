using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagement.Model
{
    public class Basic
    {
        public string Icon { get; set; }
        public string Name { get; set; }
        public Boolean IsActive { get; set; }

        public Basic()
        {
            this.Icon = "";
            this.Name = "";
            this.IsActive = true;
        }

        public Basic(string Icon, string Name, Boolean IsActive)
        {
            this.Icon = Icon;
            this.Name = Name;
            this.IsActive = IsActive;
        }
    }
}
