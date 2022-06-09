using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagement.Model
{
    public class ObjectSpending
    {
        public Spending Spending { get; set; }
        public string iconCategory { get; set; }
        public string nameCategory { get; set; }
        public string colorStatus { get; set; }

        public ObjectSpending()
        {
            this.Spending = new Spending();
            this.iconCategory = "";
            this.nameCategory = "";
            this.colorStatus = "";
        }

        public ObjectSpending(Spending Spending, string iconSpending, string nameSpending, string colorStatus)
        {
            this.Spending = Spending;
            this.iconCategory = iconSpending;
            this.nameCategory = nameSpending;
            this.colorStatus = colorStatus;
        }
    }
}
