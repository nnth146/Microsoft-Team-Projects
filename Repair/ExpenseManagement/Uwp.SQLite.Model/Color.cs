using System;
using System.Collections.Generic;
using System.Text;

namespace Uwp.SQLite.Model
{
    public class Color
    {
        public string Name { get; set; }

        public Color()
        {
            this.Name = "transaction1";
        }

        public Color(string color)
        {
            this.Name = color;
        }
    }
}
