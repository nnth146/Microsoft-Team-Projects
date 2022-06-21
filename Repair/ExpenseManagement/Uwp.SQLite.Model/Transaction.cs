using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Uwp.SQLite.Model
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public int AmountSpending { get; set; }
        public DateTimeOffset CreatedOn { get; set; }

        public ObservableCollection<Spending> Spendings { get; set; } = new ObservableCollection<Spending>();

        public Transaction()
        {
            this.Name = "";
            this.Color = "";
            this.AmountSpending = 0;
            this.CreatedOn = DateTimeOffset.Now;
        }

        public Transaction(int Id, string Name, string Color, int AmountSpending, DateTimeOffset CreatedOn)
        {
            this.Id = Id;
            this.Name = Name;
            this.Color = Color;
            this.AmountSpending = AmountSpending;
            this.CreatedOn = CreatedOn;
        }
    }
}
