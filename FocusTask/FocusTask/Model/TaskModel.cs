using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FocusTask.Models
{
    public class TaskModel
    {
        public int id { get; set; }
        public int id_project { get; set; }
        public string name { get; set; }
        public int workingtime { get; set; }
        public DateTimeOffset due_date { get; set; }
        public DateTimeOffset remender { get; set; }
        public int repeat { get; set; }
        public string type_repeat { get; set; }
        public int priority { get; set; }
        public string note { get; set; }
        public Boolean is_completed;
        public DateTimeOffset create_on { get; set; }

        public TaskModel()
        {
            this.id_project = 1;
            this.name = "";
            this.workingtime = 10;
            this.due_date = DateTimeOffset.Now.LocalDateTime;
            this.remender = DateTimeOffset.Now.LocalDateTime;
            this.repeat = 0;
            this.type_repeat = "Days";
            this.priority = 0;
            this.note = "";
            this.is_completed = false;
            this.create_on = DateTimeOffset.Now.LocalDateTime;
        }

        public TaskModel(int id, int id_project, string name, int workingtime, DateTimeOffset duedate, DateTimeOffset remender
            , int repeat, string type_repeat, int priority, string note, Boolean is_completed, DateTimeOffset create_on)
        {
            this.id = id;
            this.id_project = id_project;
            this.name = name;
            this.workingtime = workingtime;
            this.due_date = duedate;
            this.remender = remender;
            this.repeat = repeat;
            this.type_repeat = type_repeat;
            this.priority = priority;
            this.note = note;
            this.is_completed = is_completed;
            this.create_on = create_on;
        }
    }
}
