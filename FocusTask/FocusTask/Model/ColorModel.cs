using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FocusTask.Model
{
    public class ColorModel
    {
        public string color { get; set; }

        public ColorModel()
        {
            this.color = "color01";
        }

        public ColorModel(string color)
        {
            this.color = color;
        }
    }
}
