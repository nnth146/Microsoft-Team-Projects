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
        public int amount_task { get; set; }
        public DateTimeOffset create_on { get; set; }

        public ProjectModel()
        {
            this.name = "Tasks";
            this.color = "color01";
            this.amount_task = 0;
            this.create_on = DateTimeOffset.Now;
        }

        public ProjectModel(int id, string name, string color, int amount_task, DateTimeOffset create_on)
        {
            this.id = id;
            this.name = name;
            this.color = color;
            this.amount_task = amount_task;
            this.create_on = create_on;
        }
    }
}
