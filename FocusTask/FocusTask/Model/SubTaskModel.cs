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
        public Boolean is_completed { get; set; }
        public SubTaskModel()
        {
            this.name = "SubTask...";
        }
        public SubTaskModel(int id, int id_task, string name, Boolean is_completed)
        {
            this.id = id;
            this.id_task = id_task;
            this.name = name;
            this.is_completed = is_completed;
        }
    }
}
