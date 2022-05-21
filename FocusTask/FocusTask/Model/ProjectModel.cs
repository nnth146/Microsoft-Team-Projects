using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FocusTask.Models
{
    public class ProjectModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string color { get; set; }
        public DateTimeOffset create_on { get; set; }

        public ProjectModel()
        {
            this.name = "Name...";
            this.color = "red";
            this.create_on = DateTimeOffset.Now;
        }

        public ProjectModel(int id, string name, string color, DateTimeOffset create_on)
        {
            this.id = id;
            this.name = name;
            this.color = color;
            this.create_on = create_on;
        }
    }
}
