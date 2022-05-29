using FocusTask.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FocusTask.Model
{
    public class ProjectTaskModel
    {
        public ObservableCollection<TaskModel> taskModels { get; set; }
        public string nameProject { get; set; }
        public string colorProject { get; set; }

        public ProjectTaskModel()
        {
            this.taskModels = new ObservableCollection<TaskModel>();
            this.nameProject = "";
            this.colorProject = "";
        }
    }
}
