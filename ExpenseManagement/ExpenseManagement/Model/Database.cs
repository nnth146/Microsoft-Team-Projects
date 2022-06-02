using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace ExpenseManagement.Model
{
    public class Database
    {
        public Database()
        {

        }

        public async static void initDatabase()
        {
            await ApplicationData.Current.LocalFolder.CreateFileAsync("ExpenseManagement.db", CreationCollisionOption.OpenIfExists);
            string pathDatabase = Path.Combine(ApplicationData.Current.LocalFolder.Path, "ExpenseManagement.db");

            using (SqliteConnection conn = new SqliteConnection($"Filename={pathDatabase}"))
            {
                conn.Open();
                string projectCMD = "CREATE TABLE IF NOT EXISTS Transactions (id integer primary key autoincrement, name nvarchar(255) not null, color text, create_on timestamp);"
                    + "CREATE TABLE IF NOT EXISTS Spending(id integer primary key autoincrement, id_transaction integer not null, name nvarchar(255) not null, money double not null, status boolean not null, id_category int not null, note text, create_on timestamp);"
                    + "CREATE TABLE IF NOT EXISTS Category (id integer primary key autoincrement, name nvarchar(255), icon text)";
                SqliteCommand CMDCreateTable = new SqliteCommand(projectCMD, conn);
                CMDCreateTable.ExecuteReader();
                conn.Close();
            }
        }

        // Add New Item
        public static void addNewTransaction(Transaction transaction)
        {
            if (!string.IsNullOrEmpty(transaction.Name))
            {
                string pathDataBase = Path.Combine(ApplicationData.Current.LocalFolder.Path, "ExpenseManagement.db");

                using (SqliteConnection conn = new SqliteConnection($"Filename={pathDataBase}"))
                {
                    conn.Open();
                    SqliteCommand CMD_Insert = new SqliteCommand();
                    CMD_Insert.Connection = conn;

                    CMD_Insert.CommandText = "INSERT INTO Transactions (name, color, create_on) values (@name, @color, @create_on);";
                    CMD_Insert.Parameters.AddWithValue("@name", transaction.Name);
                    CMD_Insert.Parameters.AddWithValue("@color", transaction.Color);
                    CMD_Insert.Parameters.AddWithValue("@create_on", transaction.Create_On);
                    CMD_Insert.ExecuteReader();
                    conn.Close();
                }
            }
        }

        public static void addNewSpending(Spending spending)
        {
            if (!string.IsNullOrEmpty(spending.Name))
            {
                string pathDataBase = Path.Combine(ApplicationData.Current.LocalFolder.Path, "ExpenseManagement.db");

                using (SqliteConnection conn = new SqliteConnection($"Filename={pathDataBase}"))
                {
                    conn.Open();
                    SqliteCommand CMD_Insert = new SqliteCommand();
                    CMD_Insert.Connection = conn;

                    CMD_Insert.CommandText = "INSERT INTO Spending (id_transaction, name, money, status, id_category, note, create_on) values (@id_transaction, @name, @money, @status, @id_category, @note, @create_on);";
                    CMD_Insert.Parameters.AddWithValue("@id_transaction", spending.Id_Transaction);
                    CMD_Insert.Parameters.AddWithValue("@name", spending.Name);
                    CMD_Insert.Parameters.AddWithValue("@money", spending.Money);
                    CMD_Insert.Parameters.AddWithValue("@status", spending.Status);
                    CMD_Insert.Parameters.AddWithValue("@id_category", spending.Id_Category);
                    CMD_Insert.Parameters.AddWithValue("@note", spending.Note);
                    CMD_Insert.Parameters.AddWithValue("@create_on", spending.Create_On);
                    CMD_Insert.ExecuteReader();
                    conn.Close();
                }
            }
        }

        public static void addNewCategory(Category category)
        {
            if (!string.IsNullOrEmpty(category.Name))
            {
                string pathDataBase = Path.Combine(ApplicationData.Current.LocalFolder.Path, "ExpenseManagement.db");

                using (SqliteConnection conn = new SqliteConnection($"Filename={pathDataBase}"))
                {
                    conn.Open();
                    SqliteCommand CMD_Insert = new SqliteCommand();
                    CMD_Insert.Connection = conn;

                    CMD_Insert.CommandText = "INSERT INTO Category (name, icon) values (@name, @icon);";
                    CMD_Insert.Parameters.AddWithValue("@name", category.Name);
                    CMD_Insert.Parameters.AddWithValue("@icon", category.Icon);
                    CMD_Insert.ExecuteReader();
                    conn.Close();
                }
            }
        }

        // Get Item By Where
        public static ObservableCollection<Transaction> getTransactionByWhere(string wh)
        {
            ObservableCollection<Transaction> items = new ObservableCollection<Transaction>();
            string PathToDataBase = Path.Combine(ApplicationData.Current.LocalFolder.Path, "ExpenseManagement.db");

            using (SqliteConnection conn = new SqliteConnection($"Filename={ PathToDataBase }"))
            {
                conn.Open();

                string selectCMD = "SELECT * FROM Transactions " + wh;
                SqliteCommand CMD_GetData = new SqliteCommand(selectCMD, conn);

                SqliteDataReader render = CMD_GetData.ExecuteReader();
                while (render.Read())
                {
                    int countSpending = Database.getSpendingByWhere("where id_transaction = " + render.GetInt32(0)).Count;
                    Transaction item = new Transaction(render.GetInt32(0), render.GetString(1), render.GetString(2), countSpending, render.GetDateTimeOffset(3));
                    items.Add(item);
                }
                conn.Close();
            }

            return items;
        }

        public static ObservableCollection<Spending> getSpendingByWhere(string wh)
        {
            ObservableCollection<Spending> items = new ObservableCollection<Spending>();
            string PathToDataBase = Path.Combine(ApplicationData.Current.LocalFolder.Path, "ExpenseManagement.db");

            using (SqliteConnection conn = new SqliteConnection($"Filename={ PathToDataBase }"))
            {
                conn.Open();

                string selectCMD = "SELECT * FROM Spending " + wh;
                SqliteCommand CMD_GetData = new SqliteCommand(selectCMD, conn);

                SqliteDataReader render = CMD_GetData.ExecuteReader();
                while (render.Read())
                {
                    Spending item = new Spending(render.GetInt32(0), render.GetInt32(1), render.GetString(2), render.GetDouble(3), render.GetBoolean(4), render.GetInt32(5), render.GetString(6), render.GetDateTimeOffset(7));
                    items.Add(item);
                }
                conn.Close();
            }

            return items;
        }

        public static ObservableCollection<Category> getCategoryByWhere(string wh)
        {
            ObservableCollection<Category> items = new ObservableCollection<Category>();
            string PathToDataBase = Path.Combine(ApplicationData.Current.LocalFolder.Path, "ExpenseManagement.db");

            using (SqliteConnection conn = new SqliteConnection($"Filename={ PathToDataBase }"))
            {
                conn.Open();

                string selectCMD = "SELECT * FROM Category " + wh;
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

        // Update Item By Id
        public static void updateTransactionById(Transaction transaction, int id)
        {
            string PathToDataBase = Path.Combine(ApplicationData.Current.LocalFolder.Path, "ExpenseManagement.db");

            using (SqliteConnection conn = new SqliteConnection($"Filename={ PathToDataBase }"))
            {
                conn.Open();

                SqliteCommand CMD_Update = new SqliteCommand();
                CMD_Update.Connection = conn;
                CMD_Update.CommandText = "UPDATE Transactions SET name = @name, color = @color WHERE id = @id";
                CMD_Update.Parameters.AddWithValue("@name", transaction.Name);
                CMD_Update.Parameters.AddWithValue("@color", transaction.Color);
                CMD_Update.Parameters.AddWithValue("@id", id);
                CMD_Update.ExecuteReader();

                conn.Close();
            }
        }

        public static void updateSpendingById(Spending spending, int id)
        {
            string PathToDataBase = Path.Combine(ApplicationData.Current.LocalFolder.Path, "ExpenseManagement.db");

            using (SqliteConnection conn = new SqliteConnection($"Filename={ PathToDataBase }"))
            {
                conn.Open();

                SqliteCommand CMD_Update = new SqliteCommand();
                CMD_Update.Connection = conn;
                CMD_Update.CommandText = "UPDATE Spending SET id_transaction = @id_transaction, name = @name, money = @money, status = @status, id_category = @id_category, note = @note, create_on = @create_on WHERE id = @id";
                CMD_Update.Parameters.AddWithValue("@id_transaction", spending.Id_Transaction);
                CMD_Update.Parameters.AddWithValue("@name", spending.Name);
                CMD_Update.Parameters.AddWithValue("@money", spending.Money);
                CMD_Update.Parameters.AddWithValue("@status", spending.Status);
                CMD_Update.Parameters.AddWithValue("@id_category", spending.Id_Category);
                CMD_Update.Parameters.AddWithValue("@note", spending.Note);
                CMD_Update.Parameters.AddWithValue("@create_on", spending.Create_On);
                CMD_Update.Parameters.AddWithValue("@id", id);
                CMD_Update.ExecuteReader();

                conn.Close();
            }
        }

        public static void updateCategoryById(Category category, int id)
        {
            string PathToDataBase = Path.Combine(ApplicationData.Current.LocalFolder.Path, "ExpenseManagement.db");

            using (SqliteConnection conn = new SqliteConnection($"Filename={ PathToDataBase }"))
            {
                conn.Open();

                SqliteCommand CMD_Update = new SqliteCommand();
                CMD_Update.Connection = conn;
                CMD_Update.CommandText = "UPDATE Category SET name = @name, icon = @icon WHERE id = @id";
                CMD_Update.Parameters.AddWithValue("@name", category.Name);
                CMD_Update.Parameters.AddWithValue("@icon", category.Icon);
                CMD_Update.Parameters.AddWithValue("@id", id);
                CMD_Update.ExecuteReader();

                conn.Close();
            }
        }

        // Delete Item By Id
        public static void deleteTransactionById(int id)
        {
            string PathToDataBase = Path.Combine(ApplicationData.Current.LocalFolder.Path, "ExpenseManagement.db");

            using (SqliteConnection conn = new SqliteConnection($"Filename={ PathToDataBase }"))
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

        public static void deleteSpendingById(int id)
        {
            string PathToDataBase = Path.Combine(ApplicationData.Current.LocalFolder.Path, "ExpenseManagement.db");

            using (SqliteConnection conn = new SqliteConnection($"Filename={ PathToDataBase }"))
            {
                conn.Open();

                SqliteCommand CMD_Delete = new SqliteCommand();
                CMD_Delete.Connection = conn;
                CMD_Delete.CommandText = "DELETE FROM Spending WHERE id = @id";
                CMD_Delete.Parameters.AddWithValue("@id", id);
                CMD_Delete.ExecuteReader();

                conn.Close();
            }
        }

        public static void deleteCategoryById(int id)
        {
            string PathToDataBase = Path.Combine(ApplicationData.Current.LocalFolder.Path, "ExpenseManagement.db");

            using (SqliteConnection conn = new SqliteConnection($"Filename={ PathToDataBase }"))
            {
                conn.Open();

                SqliteCommand CMD_Delete = new SqliteCommand();
                CMD_Delete.Connection = conn;
                CMD_Delete.CommandText = "DELETE FROM Category WHERE id = @id";
                CMD_Delete.Parameters.AddWithValue("@id", id);
                CMD_Delete.ExecuteReader();

                conn.Close();
            }
        }
    }
}
