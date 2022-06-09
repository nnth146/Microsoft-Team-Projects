using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagement.Model
{
    public class Spending
    {
        public int Id { get; set; }
        public int Id_Transaction { get; set; }
        public string Name { get; set; }
        public double Money { get; set; }
        public Boolean Status { get; set; }
        public int Id_Category { get; set; }
        public string Note { get; set; }
        public DateTimeOffset Create_On { get; set; }

        public Spending()
        {
            this.Id_Transaction = 1;
            this.Name = "";
            this.Money = 0;
            this.Status = false;
            this.Id_Category = 1;
            this.Note = "";
            this.Create_On = DateTimeOffset.Now;
        }

        public Spending(int Id, int Id_Transaction, string Name, double Money, Boolean Status, int Id_Category, string Note, DateTimeOffset Create_On)
        {
            this.Id = Id;
            this.Id_Transaction = Id_Transaction;
            this.Name = Name;
            this.Money = Money;
            this.Status = Status;
            this.Id_Category = Id_Category;
            this.Note = Note;
            this.Create_On = Create_On;
        }
    }
}
