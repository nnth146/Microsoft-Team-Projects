using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyLover.Model
{
    public class Icon
    {
        public string Name { get; set; }
        public Icon()
        {
            Name = "";
        }

        public Icon(string Name)
        {
            this.Name = Name;
        }
    }
}
