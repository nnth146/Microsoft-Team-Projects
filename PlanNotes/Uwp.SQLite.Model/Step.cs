using System;

namespace Uwp.SQLite.Model
{
    public class Step
    {
        public int StepId { get; set; }
        public string StepName { get; set; }
        public bool StepStatus { get; set; }
        public DateTime StepCreate_On { get; set; }
        public int CheckListId { get; set; }
        public CheckList CheckList { get; set; }
    }
}
