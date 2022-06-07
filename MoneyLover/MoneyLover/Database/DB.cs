using Microsoft.Data.Sqlite;
using MoneyLover.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace MoneyLover.Database
{
    public class DB
    {
        public DB()
        {

        }

        #region Init Database
        public async static void initDatabase()
        {
            await ApplicationData.Current.LocalFolder.CreateFileAsync("MoneyLover.db", CreationCollisionOption.OpenIfExists);
            string pathDatabase = Path.Combine(ApplicationData.Current.LocalFolder.Path, "MoneyLover.db");

            using (SqliteConnection conn = new SqliteConnection($"Filename={pathDatabase}"))
            {
                conn.Open();
                string projectCMD = "CREATE TABLE IF NOT EXISTS Budgets (id integer primary key autoincrement, name nvarchar(255) not null, money double not null, curency varchar(255) not null, note text, create_on timestamp);"
                    + "CREATE TABLE IF NOT EXISTS Transactions (id integer primary key autoincrement, id_budget integer not null, name nvarchar(255) not null, money double not null, id_category integer not null, note text, create_on timestamp);"
                    + "CREATE TABLE IF NOT EXISTS Categories (id integer primary key autoincrement, name nvarchar(255), icon text)";
                SqliteCommand CMDCreateTable = new SqliteCommand(projectCMD, conn);
                CMDCreateTable.ExecuteReader();
                conn.Close();
            }
        }
        #endregion

        #region Add New Data
        // Add New Item
        public static void addNewBudget(Budget budget)
        {
            if (!string.IsNullOrEmpty(budget.Name))
            {
                string pathDataBase = Path.Combine(ApplicationData.Current.LocalFolder.Path, "MoneyLover.db");

                using (SqliteConnection conn = new SqliteConnection($"Filename={pathDataBase}"))
                {
                    conn.Open();
                    SqliteCommand CMD_Insert = new SqliteCommand();
                    CMD_Insert.Connection = conn;

                    CMD_Insert.CommandText = "INSERT INTO Budgets (name, money, curency, note, create_on) values (@name, @money, @curency, @note, @create_on);";
                    CMD_Insert.Parameters.AddWithValue("@name", budget.Name);
                    CMD_Insert.Parameters.AddWithValue("@money", budget.Money);
                    CMD_Insert.Parameters.AddWithValue("@curency", budget.Curency);
                    CMD_Insert.Parameters.AddWithValue("@note", budget.Note);
                    CMD_Insert.Parameters.AddWithValue("@create_on", budget.Create_On);
                    CMD_Insert.ExecuteReader();
                    conn.Close();
                }
            }
        }

        public static void addNewTransaction(Transaction transaction)
        {
            if (!string.IsNullOrEmpty(transaction.Name))
            {
                string pathDataBase = Path.Combine(ApplicationData.Current.LocalFolder.Path, "MoneyLover.db");

                using (SqliteConnection conn = new SqliteConnection($"Filename={pathDataBase}"))
                {
                    conn.Open();
                    SqliteCommand CMD_Insert = new SqliteCommand();
                    CMD_Insert.Connection = conn;

                    CMD_Insert.CommandText = "INSERT INTO Transactions (id_budget, name, money, id_category, note, create_on) values (@id_budget, @name, @money, @id_category, @note, @create_on);";
                    CMD_Insert.Parameters.AddWithValue("@id_budget", transaction.Id_Budget);
                    CMD_Insert.Parameters.AddWithValue("@name", transaction.Name);
                    CMD_Insert.Parameters.AddWithValue("@money", transaction.Money);
                    CMD_Insert.Parameters.AddWithValue("@id_category", transaction.Id_Category);
                    CMD_Insert.Parameters.AddWithValue("@note", transaction.Note);
                    CMD_Insert.Parameters.AddWithValue("@create_on", transaction.Create_On);
                    CMD_Insert.ExecuteReader();
                    conn.Close();
                }
            }
        }

        public static void addNewCategory(Category category)
        {
            if (!string.IsNullOrEmpty(category.Name))
            {
                string pathDataBase = Path.Combine(ApplicationData.Current.LocalFolder.Path, "MoneyLover.db");

                using (SqliteConnection conn = new SqliteConnection($"Filename={pathDataBase}"))
                {
                    conn.Open();
                    SqliteCommand CMD_Insert = new SqliteCommand();
                    CMD_Insert.Connection = conn;

                    CMD_Insert.CommandText = "INSERT INTO Categories (name, icon) values (@name, @icon);";
                    CMD_Insert.Parameters.AddWithValue("@name", category.Name);
                    CMD_Insert.Parameters.AddWithValue("@icon", category.Icon);
                    CMD_Insert.ExecuteReader();
                    conn.Close();
                }
            }
        }

        #endregion

        #region Get Data By Where
        // Get Budget
        public static ObservableCollection<Budget> getBudgetByWhere(string wh)
        {
            ObservableCollection<Budget> items = new ObservableCollection<Budget>();
            string PathToDataBase = Path.Combine(ApplicationData.Current.LocalFolder.Path, "MoneyLover.db");

            using (SqliteConnection conn = new SqliteConnection($"Filename={PathToDataBase}"))
            {
                conn.Open();

                string selectCMD = "SELECT * FROM Budgets " + wh;
                SqliteCommand CMD_GetData = new SqliteCommand(selectCMD, conn);

                SqliteDataReader render = CMD_GetData.ExecuteReader();
                while (render.Read())
                {
                    Budget item = new Budget(render.GetInt32(0), render.GetString(1), render.GetDouble(2), render.GetString(3), render.GetString(4), render.GetDateTimeOffset(5));
                    items.Add(item);
                }
                conn.Close();
            }

            return items;
        }

        // Get Transaction
        public static ObservableCollection<Transaction> getTransactionByWhere(string wh)
        {
            ObservableCollection<Transaction> items = new ObservableCollection<Transaction>();
            string PathToDataBase = Path.Combine(ApplicationData.Current.LocalFolder.Path, "MoneyLover.db");

            using (SqliteConnection conn = new SqliteConnection($"Filename={PathToDataBase}"))
            {
                conn.Open();

                string selectCMD = "SELECT * FROM Transactions " + wh;
                SqliteCommand CMD_GetData = new SqliteCommand(selectCMD, conn);

                SqliteDataReader render = CMD_GetData.ExecuteReader();
                while (render.Read())
                {
                    Transaction item = new Transaction(render.GetInt32(0), render.GetInt32(1), render.GetString(2), render.GetDouble(3), render.GetInt32(4), render.GetString(5), render.GetDateTimeOffset(6));
                    items.Add(item);
                }
                conn.Close();
            }

            return items;
        }

        // Get Category
        public static ObservableCollection<Category> getCategoryByWhere(string wh)
        {
            ObservableCollection<Category> items = new ObservableCollection<Category>();
            string PathToDataBase = Path.Combine(ApplicationData.Current.LocalFolder.Path, "MoneyLover.db");

            using (SqliteConnection conn = new SqliteConnection($"Filename={PathToDataBase}"))
            {
                conn.Open();

                string selectCMD = "SELECT * FROM Categories " + wh;
                SqliteCommand CMD_GetData = new SqliteCommand(selectCMD, conn);

                SqliteDataReader render = CMD_GetData.ExecuteReader();
                while (render.Read())
                {
                    Category item = new Category(render.GetInt32(0), render.GetString(1), render.GetString(2));
                    items.Add(item);
                }
                conn.Close();
            }

            return items;
        }
        #endregion

        #region Update Data By Id
        // Update Budget
        public static void updateBudgetById(Budget budget, int id)
        {
            string PathToDataBase = Path.Combine(ApplicationData.Current.LocalFolder.Path, "MoneyLover.db");

            using (SqliteConnection conn = new SqliteConnection($"Filename={PathToDataBase}"))
            {
                conn.Open();

                SqliteCommand CMD_Update = new SqliteCommand();
                CMD_Update.Connection = conn;
                CMD_Update.CommandText = "UPDATE Budgets SET name = @name, money = @money, curency = @curency, note = @note, create_on = @create_on WHERE id = @id";
                CMD_Update.Parameters.AddWithValue("@name", budget.Name);
                CMD_Update.Parameters.AddWithValue("@money", budget.Money);
                CMD_Update.Parameters.AddWithValue("@curency", budget.Curency);
                CMD_Update.Parameters.AddWithValue("@note", budget.Note);
                CMD_Update.Parameters.AddWithValue("@create_on", budget.Create_On);
                CMD_Update.Parameters.AddWithValue("@id", id);
                CMD_Update.ExecuteReader();

                conn.Close();
            }
        }

        // Update Transaction
        public static void updateTransactionById(Transaction transaction, int id)
        {
            string PathToDataBase = Path.Combine(ApplicationData.Current.LocalFolder.Path, "MoneyLover.db");

            using (SqliteConnection conn = new SqliteConnection($"Filename={PathToDataBase}"))
            {
                conn.Open();

                SqliteCommand CMD_Update = new SqliteCommand();
                CMD_Update.Connection = conn;
                CMD_Update.CommandText = "UPDATE Transactions SET id_budget = @id_budget, name = @name, money = @money, id_category = @id_category, note = @note, create_on = @create_on WHERE id = @id";
                CMD_Update.Parameters.AddWithValue("@id_budget", transaction.Id_Budget);
                CMD_Update.Parameters.AddWithValue("@name", transaction.Name);
                CMD_Update.Parameters.AddWithValue("@money", transaction.Money);
                CMD_Update.Parameters.AddWithValue("@id_category", transaction.Id_Category);
                CMD_Update.Parameters.AddWithValue("@note", transaction.Note);
                CMD_Update.Parameters.AddWithValue("@create_on", transaction.Create_On);
                CMD_Update.Parameters.AddWithValue("@id", id);
                CMD_Update.ExecuteReader();

                conn.Close();
            }
        }

        // Update Category
        public static void updateCategoryById(Category category, int id)
        {
            string PathToDataBase = Path.Combine(ApplicationData.Current.LocalFolder.Path, "MoneyLover.db");

            using (SqliteConnection conn = new SqliteConnection($"Filename={PathToDataBase}"))
            {
                conn.Open();

                SqliteCommand CMD_Update = new SqliteCommand();
                CMD_Update.Connection = conn;
                CMD_Update.CommandText = "UPDATE Categories SET name = @name, icon = @icon WHERE id = @id";
                CMD_Update.Parameters.AddWithValue("@name", category.Name);
                CMD_Update.Parameters.AddWithValue("@icon", category.Icon);
                CMD_Update.Parameters.AddWithValue("@id", id);
                CMD_Update.ExecuteReader();

                conn.Close();
            }
        }
        #endregion

        #region Delete Data By Id
        // Delete Budget
        public static void deleteBudgetById(int id)
        {
            string PathToDataBase = Path.Combine(ApplicationData.Current.LocalFolder.Path, "MoneyLover.db");

            using (SqliteConnection conn = new SqliteConnection($"Filename={PathToDataBase}"))
            {
                conn.Open();

                SqliteCommand CMD_Delete = new SqliteCommand();
                CMD_Delete.Connection = conn;
                CMD_Delete.CommandText = "DELETE FROM Budgets WHERE id = @id";
                CMD_Delete.Parameters.AddWithValue("@id", id);
                CMD_Delete.ExecuteReader();

                conn.Close();
            }
        }

        // Delete Transaction
        public static void deleteTransactionById(int id)
        {
            string PathToDataBase = Path.Combine(ApplicationData.Current.LocalFolder.Path, "MoneyLover.db");

            using (SqliteConnection conn = new SqliteConnection($"Filename={PathToDataBase}"))
            {
                conn.Open();

                SqliteCommand CMD_Delete = new SqliteCommand();
                CMD_Delete.Connection = conn;
                CMD_Delete.CommandText = "DELETE FROM Transactions WHERE id = @id";
                CMD_Delete.Parameters.AddWithValue("@id", id);
                CMD_Delete.ExecuteReader();

                conn.Close();
            }
        }

        // Delete Category
        public static void deleteCategoryById(int id)
        {
            string PathToDataBase = Path.Combine(ApplicationData.Current.LocalFolder.Path, "MoneyLover.db");

            using (SqliteConnection conn = new SqliteConnection($"Filename={PathToDataBase}"))
            {
                conn.Open();

                SqliteCommand CMD_Delete = new SqliteCommand();
                CMD_Delete.Connection = conn;
                CMD_Delete.CommandText = "DELETE FROM Categories WHERE id = @id";
                CMD_Delete.Parameters.AddWithValue("@id", id);
                CMD_Delete.ExecuteReader();

                conn.Close();
            }
        }
        #endregion
    }
}
