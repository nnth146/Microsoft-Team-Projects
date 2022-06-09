using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyLover.Model
{
    public class Basic
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public Boolean IsActive { get; set; }
        public string Visibility { get; set; }

        public Basic()
        {
            this.Name = "";
            this.Icon = "";
            this.IsActive = true;
            this.Visibility = "Visible";
        }

        public Basic(string Name, string Icon, Boolean IsActive, string Visibility)
        {
            this.Name = Name;
            this.Icon = Icon;
            this.IsActive = IsActive;
            this.Visibility = Visibility;
        }
    }
}
