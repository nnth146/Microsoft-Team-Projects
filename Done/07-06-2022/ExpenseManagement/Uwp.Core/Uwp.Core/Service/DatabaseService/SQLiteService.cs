using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uwp.SQLite.Model;

namespace Uwp.Core.Service
{
    public class SQLiteService : IDataService
    {
        public DataContext Db => DataContext.Default;

        public void AddNewCategory(Category category)
        {
            Db.Categories.Add(category);
            SaveChanges();
        }

        public void AddNewSpending(Spending spending)
        {
            Db.Spendings.Add(spending);
            SaveChanges();
        }

        public void AddNewTransaction(Transaction transaction)
        {
            Db.Transactions.Add(transaction);
            SaveChanges();
        }

        public void DeleteCategory(Category category)
        {
            Db.Categories.Remove(category);
            SaveChanges();
        }

        public void DeleteCategoryById(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteSpending(Spending spending)
        {
            Db.Spendings.Remove(spending);
            SaveChanges();
        }

        public void DeleteSpendingById(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteTransaction(Transaction transaction)
        {
            Db.Transactions.Remove(transaction);
            SaveChanges();
        }

        public void DeleteTransactionById(int id)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Category> GetCategories()
        {
            return new ObservableCollection<Category>(Db.Categories.Include(x=>x.Spendings).ToList());
        }

        public Category GetCategoryById(int id)
        {
            return Db.Categories.Where(x => x.Id == id).Include(x => x.Spendings).First();
        }

        public ObservableCollection<Category> GetCategoryByWhere(string wh)
        {
            throw new NotImplementedException();
        }

        public Spending GetSpendingByTransactionId(int id)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Spending> GetSpendingByWhere(string wh)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Spending> GetSpendings()
        {
            return new ObservableCollection<Spending>(Db.Spendings
                .Include(x=>x.Transaction)
                .Include(x=>x.Category)
                .ToList());
        }

        public ObservableCollection<Transaction> GetTransactionByWhere(string wh)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Transaction> GetTransactions()
        {
            return new ObservableCollection<Transaction>(Db.Transactions.Include(x => x.Spendings).ToList());
        }

        public void SaveChanges()
        {
            Db.SaveChanges();
        }

        public void UpdateCategoryById(Category category, int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateSpendingById(Spending spending, int id)
        {
            Spending updatedSpending = Db.Spendings.Where(x => x.Id == id).First();
            updatedSpending.CopyFrom(spending);
            SaveChanges();
        }

        public void UpdateTransactionById(Transaction transaction, int id)
        {
            throw new NotImplementedException();
        }
    }
}
