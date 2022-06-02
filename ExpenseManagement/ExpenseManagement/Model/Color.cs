using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagement.Model
{
    public class Color
    {
        public string name { get; set; }

        public Color()
        {
            this.name = "transaction1";
        }

        public Color(string color)
        {
            this.name = color;
        }
    }
}
