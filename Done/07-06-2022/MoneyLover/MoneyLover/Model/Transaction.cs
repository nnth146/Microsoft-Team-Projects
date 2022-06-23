using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyLover.Model
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Money { get; set; }
        public int Id_Category { get; set; }
        public string Note { get; set; }
        public DateTimeOffset Create_On { get; set; }

        public int Id_Budget { get; set; }
        public Budget Budget { get; set; }
        public Transaction()
        {
            this.Name = "Transaction";
            this.Money = 0;
            this.Note = "";
            this.Create_On = DateTimeOffset.Now;
        }

        public Transaction(int Id, int Id_Budget, string Name, double Money, int Id_Category, string Note, DateTimeOffset Create_On)
        {
            this.Id = Id;
            this.Id_Budget = Id_Budget;
            this.Name = Name;
            this.Money = Money;
            this.Id_Category = Id_Category;
            this.Note = Note;
            this.Create_On = Create_On;
        }
    }
}
