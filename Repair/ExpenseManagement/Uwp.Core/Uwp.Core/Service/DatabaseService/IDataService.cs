using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uwp.SQLite.Model;

namespace Uwp.Core.Service
{
    public interface IDataService
    {
        void AddNewTransaction(Transaction transaction);
        void AddNewSpending(Spending spending);
        void AddNewCategory(Category category);

        ObservableCollection<Transaction> GetTransactionByWhere(string wh);
        ObservableCollection<Transaction> GetTransactions();

        ObservableCollection<Spending> GetSpendingByWhere(string wh);
        Spending GetSpendingByTransactionId(int id);
        ObservableCollection<Spending> GetSpendings();

        ObservableCollection<Category> GetCategoryByWhere(string wh);
        Category GetCategoryById(int id);
        ObservableCollection<Category> GetCategories();

        void UpdateTransactionById(Transaction transaction, int id);
        void UpdateSpendingById(Spending spending, int id);
        void UpdateCategoryById(Category category, int id);

        void SaveChanges();

        void DeleteTransactionById(int id);
        void DeleteTransaction(Transaction transaction);

        void DeleteSpendingById(int id);
        void DeleteSpending(Spending spending);

        void DeleteCategoryById(int id);
        void DeleteCategory(Category category);
    }
}
