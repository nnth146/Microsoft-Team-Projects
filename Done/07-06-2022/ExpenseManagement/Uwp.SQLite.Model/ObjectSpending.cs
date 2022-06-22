using System;
using System.Collections.Generic;
using System.Text;

namespace Uwp.SQLite.Model
{
    public class ObjectSpending
    {
        public string IconCategory { get; set; }
        public string NameCategory { get; set; }
        public string ColorStatus { get; set; }

        public Spending Spending { get; set; }

        public ObjectSpending()
        {
            this.Spending = new Spending();
            this.IconCategory = "";
            this.NameCategory = "";
            this.ColorStatus = "";
        }

        public ObjectSpending(Spending Spending, string iconSpending, string nameSpending, string colorStatus)
        {
            this.Spending = Spending;
            this.IconCategory = iconSpending;
            this.NameCategory = nameSpending;
            this.ColorStatus = colorStatus;
        }
    }
}
