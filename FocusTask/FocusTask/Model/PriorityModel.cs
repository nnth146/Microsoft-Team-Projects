using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FocusTask.Model
{
    public class PriorityModel
    {
        public string color { get; set; }
        public string name{ get; set; }

        public PriorityModel()
        {
            this.color = "noColor";
            this.name = "No Priority";
        }

        public PriorityModel(string color, string priority)
        {
            this.color = color;
            this.name = priority;
        }
    }
}
