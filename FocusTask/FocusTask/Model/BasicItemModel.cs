using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FocusTask.Model
{
    public class BasicItemModel
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public int TaskCount { get; set; }

        public BasicItemModel()
        {
            this.Name = "";
            this.Icon = "";
            this.TaskCount = 0;
        }

        public BasicItemModel(string Name, string Icon, int TaskCount) { this.Name = Name; this.Icon = Icon; this.TaskCount = TaskCount; }
    }
}
