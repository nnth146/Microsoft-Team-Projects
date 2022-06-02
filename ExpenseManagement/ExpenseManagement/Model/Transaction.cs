using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagement.Model
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public int AmountSpending { get; set; }
        public DateTimeOffset Create_On { get; set; }

        public Transaction()
        {
            this.Name = "";
            this.Color = "";
            this.AmountSpending = 0;
            this.Create_On = DateTimeOffset.Now;
        }

        public Transaction(int Id, string Name, string Color, int AmountSpending, DateTimeOffset Create_On)
        {
            this.Id = Id;
            this.Name = Name;
            this.Color = Color;
            this.AmountSpending = AmountSpending;
            this.Create_On = Create_On;
        }
    }
}
