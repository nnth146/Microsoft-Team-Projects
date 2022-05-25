using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FocusTask.Models
{
    public class SubTaskModel
    {
        public int id { get; set; }
        public int id_task { get; set; }
        public string name { get; set; }
        public string completed { get; set; }
        public SubTaskModel()
        {
            this.name = "SubTask...";
            this.completed = "None";
        }
        public SubTaskModel(int id, int id_task, string name, string completed)
        {
            this.id = id;
            this.id_task = id_task;
            this.name = name;
            this.completed = completed;
        }
    }
}
