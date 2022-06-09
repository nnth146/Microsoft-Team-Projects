using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyLover.Model
{
    public class Budget
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Money { get; set; }
        public string Curency { get; set; }
        public string Note { get; set; }
        public DateTimeOffset Create_On { get; set; }
        public ObservableCollection<Transaction> Transactions { get; set; } = new ObservableCollection<Transaction>();

        public Budget()
        {
            this.Name = "Budget...";
            this.Money = 0;
            this.Curency = "$";
            this.Note = "";
            this.Create_On = DateTimeOffset.Now;
        }

        public Budget(int Id, string Name, double Money, string Curency, string Note, DateTimeOffset Create_On)
        {
            this.Id = Id;
            this.Name = Name;
            this.Money = Money;
            this.Curency = Curency;
            this.Note = Note;
            this.Create_On = Create_On;
        }
    }
}
