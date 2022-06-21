using System;
using System.Collections.Generic;
using System.Text;

namespace Uwp.SQLite.Model
{
    public class Spending
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Money { get; set; }
        public Boolean Status { get; set; }
        public string Note { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        
        public int TransactionId { get; set; }
        public Transaction Transaction { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public Spending()
        {
            Name = "";
            Money = 0;
            Status = false;
            Note = "";
            CreatedOn = DateTimeOffset.Now;
        }

        public Spending(int Id, int TransactionId, string Name, double Money, Boolean Status, int CategoryId, string Note, DateTimeOffset CreatedOn)
        {
            this.Id = Id;
            this.Name = Name;
            this.Money = Money;
            this.Status = Status;
            this.Note = Note;
            this.CreatedOn = CreatedOn;
        }

        public void CopyFrom(Spending spending)
        {
            Name = spending.Name;
            Money = spending.Money;
            Status = spending.Status;
            Note = spending.Note;
            CreatedOn = spending.CreatedOn;
            Transaction = spending.Transaction;
            Category = spending.Category;
        }
    }
}
