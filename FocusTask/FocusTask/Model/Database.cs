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

namespace FocusTask.Models
{
    public class Database
    {
        public Database()
        {

        }

        public async static void initDatabase()
        {
            await ApplicationData.Current.LocalFolder.CreateFileAsync("focusTask.db", CreationCollisionOption.OpenIfExists);
            string pathDatabase = Path.Combine(ApplicationData.Current.LocalFolder.Path, "focusTask.db");

            using (SqliteConnection conn = new SqliteConnection($"Filename={pathDatabase}"))
            {
                conn.Open();
                string projectCMD = "CREATE TABLE IF NOT EXISTS Projects (id integer primary key autoincrement, name nvarchar(255) not null, color text, create_on timestamp);"
                    + "CREATE TABLE IF NOT EXISTS Tasks(id integer primary key autoincrement, id_project integer not null, name nvarchar(255) not null, workingtime int, due_date timestamp, remender timestamp, repeat integer,"
                    + "type_repeat integer, priority integer, note text, is_completed boolean default false, create_on timestamp);"
                    + "CREATE TABLE IF NOT EXISTS SubTasks (id integer primary key autoincrement, id_task int not null, name nvarchar(255) not null, completed varchar(255))";
                SqliteCommand CMDCreateTable = new SqliteCommand(projectCMD, conn);
                CMDCreateTable.ExecuteReader();
                conn.Close();
            }
        }

        // Add new Item
        public static void addNewProject(ProjectModel project)
        {
            if(!string.IsNullOrEmpty(project.name))
            {
                string pathDataBase = Path.Combine(ApplicationData.Current.LocalFolder.Path, "focusTask.db");

                using (SqliteConnection conn = new SqliteConnection($"Filename={pathDataBase}"))
                {
                    conn.Open();
                    SqliteCommand CMD_Insert = new SqliteCommand();
                    CMD_Insert.Connection = conn;

                    CMD_Insert.CommandText = "INSERT INTO Projects (name, color, create_on) values (@name, @color, @create_on);";
                    CMD_Insert.Parameters.AddWithValue("@name", project.name);
                    CMD_Insert.Parameters.AddWithValue("@color", project.color);
                    CMD_Insert.Parameters.AddWithValue("@create_on", project.create_on);
                    CMD_Insert.ExecuteReader();
                    conn.Close();
                }
            }
        }
        public static void addNewTask(TaskModel taskModel)
        {
            if (!string.IsNullOrEmpty(taskModel.name))
            {
                string pathDataBase = Path.Combine(ApplicationData.Current.LocalFolder.Path, "focusTask.db");

                using (SqliteConnection conn = new SqliteConnection($"Filename={pathDataBase}"))
                {
                    conn.Open();
                    SqliteCommand CMD_Insert = new SqliteCommand();
                    CMD_Insert.Connection = conn;

                    CMD_Insert.CommandText = "INSERT INTO Tasks (id_project, name, workingtime, due_date, remender, repeat, type_repeat, priority, note, is_completed, create_on)"
                        + " values (@id_project, @name, @workingtime, @duedate, @remender, @repeat, @type_repeat, @priority, @note, @is_completed, @create_on);";
                    CMD_Insert.Parameters.AddWithValue("@id_project", taskModel.id_project);
                    CMD_Insert.Parameters.AddWithValue("@name", taskModel.name);
                    CMD_Insert.Parameters.AddWithValue("@workingtime", taskModel.workingtime);
                    CMD_Insert.Parameters.AddWithValue("@duedate", taskModel.due_date);
                    CMD_Insert.Parameters.AddWithValue("@remender", taskModel.remender);
                    CMD_Insert.Parameters.AddWithValue("@repeat", taskModel.repeat);
                    CMD_Insert.Parameters.AddWithValue("@type_repeat", taskModel.type_repeat);
                    CMD_Insert.Parameters.AddWithValue("@priority", taskModel.priority);
                    CMD_Insert.Parameters.AddWithValue("@note", taskModel.note);
                    CMD_Insert.Parameters.AddWithValue("@is_completed", taskModel.is_completed);
                    CMD_Insert.Parameters.AddWithValue("@create_on", taskModel.create_on);
                    CMD_Insert.ExecuteReader();
                    conn.Close();
                }
            }
        }
        public static void addNewSubTask(SubTaskModel subTaskModel)
        {
            if (!string.IsNullOrEmpty(subTaskModel.name))
            {
                string pathDataBase = Path.Combine(ApplicationData.Current.LocalFolder.Path, "focusTask.db");

                using (SqliteConnection conn = new SqliteConnection($"Filename={pathDataBase}"))
                {
                    conn.Open();
                    SqliteCommand CMD_Insert = new SqliteCommand();
                    CMD_Insert.Connection = conn;

                    CMD_Insert.CommandText = "INSERT INTO SubTasks (id_task, name, completed)"
                        + " values (@id_task, @name, @completed);";
                    CMD_Insert.Parameters.AddWithValue("@id_task", subTaskModel.id_task);
                    CMD_Insert.Parameters.AddWithValue("@name", subTaskModel.name);
                    CMD_Insert.Parameters.AddWithValue("@completed", subTaskModel.completed);
                    CMD_Insert.ExecuteReader();
                    conn.Close();
                }
            }
        }


        // Get all item
        public static ObservableCollection<ProjectModel> getAllProject()
        {
            ObservableCollection<ProjectModel> items = new ObservableCollection<ProjectModel>();
            string PathToDataBase = Path.Combine(ApplicationData.Current.LocalFolder.Path, "focusTask.db");

            using (SqliteConnection conn = new SqliteConnection($"Filename={ PathToDataBase }"))
            {
                conn.Open();

                string selectCMD = "SELECT * FROM Projects";
                SqliteCommand CMD_GetData = new SqliteCommand(selectCMD, conn);

                SqliteDataReader render = CMD_GetData.ExecuteReader();
                while (render.Read())
                {
                    ProjectModel item = new ProjectModel();
                    item.id = render.GetInt32(0);
                    item.name = render.GetString(1);
                    item.color = render.GetString(2);
                    int amount_task = Database.getTaskByWhere("id_project = " + item.id).Count;
                    item.amount_task = amount_task;
                    item.create_on = render.GetDateTimeOffset(3);
                    items.Add(item);
                }

                conn.Close();
            }

            return items;
        }
        public static ObservableCollection<TaskModel> getAllTask()
        {
            ObservableCollection<TaskModel> items = new ObservableCollection<TaskModel>();
            string PathToDataBase = Path.Combine(ApplicationData.Current.LocalFolder.Path, "focusTask.db");

            using (SqliteConnection conn = new SqliteConnection($"Filename={ PathToDataBase }"))
            {
                conn.Open();

                string selectCMD = "SELECT * FROM Tasks";
                SqliteCommand CMD_GetData = new SqliteCommand(selectCMD, conn);

                SqliteDataReader render = CMD_GetData.ExecuteReader();
                while (render.Read())
                {
                    TaskModel item = new TaskModel();
                    item.id = render.GetInt32(0);
                    item.id_project = render.GetInt32(1);
                    item.name = render.GetString(2);
                    item.workingtime = render.GetInt32(3);
                    item.due_date = render.GetDateTimeOffset(4);
                    item.remender = render.GetDateTimeOffset(5);
                    item.repeat = render.GetInt32(6);
                    item.type_repeat = render.GetString(7);
                    item.priority = render.GetInt32(8);
                    item.note = render.GetString(9);
                    item.is_completed = render.GetBoolean(10);
                    item.create_on = render.GetDateTimeOffset(11);
                    items.Add(item);
                }

                conn.Close();
            }

            return items;
        }
        public static ObservableCollection<SubTaskModel> getAllSubTask()
        {
            ObservableCollection<SubTaskModel> items = new ObservableCollection<SubTaskModel>();
            string PathToDataBase = Path.Combine(ApplicationData.Current.LocalFolder.Path, "focusTask.db");

            using (SqliteConnection conn = new SqliteConnection($"Filename={ PathToDataBase }"))
            {
                conn.Open();

                string selectCMD = "SELECT * FROM SubTasks";
                SqliteCommand CMD_GetData = new SqliteCommand(selectCMD, conn);

                SqliteDataReader render = CMD_GetData.ExecuteReader();
                while (render.Read())
                {
                    SubTaskModel item = new SubTaskModel();
                    item.id = render.GetInt32(0);
                    item.id_task = render.GetInt32(1);
                    item.name = render.GetString(2);
                    item.completed = render.GetString(3);
                    items.Add(item);
                }

                conn.Close();
            }

            return items;
        }

        // Get item by where
        public static ObservableCollection<TaskModel> getTaskByWhere(string wh)
        {
            ObservableCollection<TaskModel> items = new ObservableCollection<TaskModel>();
            string PathToDataBase = Path.Combine(ApplicationData.Current.LocalFolder.Path, "focusTask.db");

            using (SqliteConnection conn = new SqliteConnection($"Filename={ PathToDataBase }"))
            {
                conn.Open();

                string selectCMD = "SELECT * FROM Tasks where " + wh;
                SqliteCommand CMD_GetData = new SqliteCommand(selectCMD, conn);

                SqliteDataReader render = CMD_GetData.ExecuteReader();
                while (render.Read())
                {
                    TaskModel item = new TaskModel();
                    item.id = render.GetInt32(0);
                    item.id_project = render.GetInt32(1);
                    item.name = render.GetString(2);
                    item.workingtime = render.GetInt32(3);
                    item.due_date = render.GetDateTimeOffset(4);
                    item.remender = render.GetDateTimeOffset(5);
                    item.repeat = render.GetInt32(6);
                    item.type_repeat = render.GetString(7);
                    item.priority = render.GetInt32(8);
                    item.note = render.GetString(9);
                    item.is_completed = render.GetBoolean(10);
                    item.create_on = render.GetDateTimeOffset(11);
                    items.Add(item);
                }
                Debug.WriteLine("Select: " + selectCMD + " - " + items.Count);

                conn.Close();
            }

            return items;
        }

        public static ObservableCollection<SubTaskModel> getSubTaskByWhere(string wh)
        {
            ObservableCollection<SubTaskModel> items = new ObservableCollection<SubTaskModel>();
            string PathToDataBase = Path.Combine(ApplicationData.Current.LocalFolder.Path, "focusTask.db");

            using (SqliteConnection conn = new SqliteConnection($"Filename={ PathToDataBase }"))
            {
                conn.Open();

                string selectCMD = "SELECT * FROM SubTasks WHERE " + wh;
                SqliteCommand CMD_GetData = new SqliteCommand(selectCMD, conn);

                SqliteDataReader render = CMD_GetData.ExecuteReader();
                while (render.Read())
                {
                    SubTaskModel subTaskModel = new SubTaskModel(render.GetInt32(0), render.GetInt32(1), render.GetString(2), render.GetString(3));
                    items.Add(subTaskModel);
                }

                conn.Close();
            }

            return items;
        }

        // Get item by id
        public static ProjectModel getProjectByID(int id)
        {
            ProjectModel projectModel = new ProjectModel();
            string PathToDataBase = Path.Combine(ApplicationData.Current.LocalFolder.Path, "focusTask.db");

            using (SqliteConnection conn = new SqliteConnection($"Filename={ PathToDataBase }"))
            {
                conn.Open();

                string selectCMD = "SELECT * FROM Projects WHERE id = " + id;
                SqliteCommand CMD_GetData = new SqliteCommand(selectCMD, conn);

                SqliteDataReader render = CMD_GetData.ExecuteReader();
                render.Read();
                int amount_task = Database.getTaskByWhere("id_project = " + render.GetInt32(0)).Count;
                projectModel = new ProjectModel(render.GetInt32(0), render.GetString(1), render.GetString(2), amount_task, render.GetDateTimeOffset(3));

                conn.Close();
            }

            return projectModel;
        }
        public static TaskModel getTaskByID(int id)
        {
            TaskModel taskModel = new TaskModel();
            string PathToDataBase = Path.Combine(ApplicationData.Current.LocalFolder.Path, "focusTask.db");

            using (SqliteConnection conn = new SqliteConnection($"Filename={ PathToDataBase }"))
            {
                conn.Open();

                string selectCMD = "SELECT * FROM Tasks WHERE id = " + id;
                SqliteCommand CMD_GetData = new SqliteCommand(selectCMD, conn);

                SqliteDataReader render = CMD_GetData.ExecuteReader();
                render.Read();
                taskModel = new TaskModel(render.GetInt32(0), render.GetInt32(1), render.GetString(2), render.GetInt32(3), render.GetDateTimeOffset(4), render.GetDateTimeOffset(5), render.GetInt32(6), render.GetString(7),
                    render.GetInt32(8), render.GetString(9), render.GetBoolean(10), render.GetDateTimeOffset(11));

                conn.Close();
            }

            return taskModel;
        }
        public static SubTaskModel getSubTaskByID(int id)
        {
            SubTaskModel subTaskModel = new SubTaskModel();
            string PathToDataBase = Path.Combine(ApplicationData.Current.LocalFolder.Path, "focusTask.db");

            using (SqliteConnection conn = new SqliteConnection($"Filename={ PathToDataBase }"))
            {
                conn.Open();

                string selectCMD = "SELECT * FROM SubTasks WHERE id = " + id;
                SqliteCommand CMD_GetData = new SqliteCommand(selectCMD, conn);

                SqliteDataReader render = CMD_GetData.ExecuteReader();
                render.Read();
                subTaskModel = new SubTaskModel(render.GetInt32(0), render.GetInt32(1), render.GetString(2), render.GetString(3));

                conn.Close();
            }

            return subTaskModel;
        }

        // Update item by id
        public static void updateProjectByID(ProjectModel projectModel, int id)
        {
            string PathToDataBase = Path.Combine(ApplicationData.Current.LocalFolder.Path, "focusTask.db");

            using (SqliteConnection conn = new SqliteConnection($"Filename={ PathToDataBase }"))
            {
                conn.Open();

                SqliteCommand CMD_Update = new SqliteCommand();
                CMD_Update.Connection = conn;
                CMD_Update.CommandText = "UPDATE Projects SET name = @name, color = @color, create_on = @create_on WHERE id = @id";
                CMD_Update.Parameters.AddWithValue("@name", projectModel.name);
                CMD_Update.Parameters.AddWithValue("@color", projectModel.color);
                CMD_Update.Parameters.AddWithValue("@create_on", projectModel.create_on);
                CMD_Update.Parameters.AddWithValue("@id", id);
                CMD_Update.ExecuteReader();

                conn.Close();
            }
        }
        public static void updateTaskByID(TaskModel taskModel, int id)
        {
            string PathToDataBase = Path.Combine(ApplicationData.Current.LocalFolder.Path, "focusTask.db");

            using (SqliteConnection conn = new SqliteConnection($"Filename={ PathToDataBase }"))
            {
                conn.Open();

                SqliteCommand CMD_Update = new SqliteCommand();
                CMD_Update.Connection = conn;
                CMD_Update.CommandText = "UPDATE Tasks SET id_project = @id_project, name = @name, workingtime = @workingtime, due_date = @due_date, remender = @remender," +
                    " repeat = @repeat, type_repeat = @type_repeat, priority = @priority, note = @note, is_completed = @is_completed, create_on = @create_on WHERE id = @id";
                CMD_Update.Parameters.AddWithValue("@id_project", taskModel.id_project);
                CMD_Update.Parameters.AddWithValue("@name", taskModel.name);
                CMD_Update.Parameters.AddWithValue("@workingtime", taskModel.workingtime);
                CMD_Update.Parameters.AddWithValue("@due_date", taskModel.due_date);
                CMD_Update.Parameters.AddWithValue("@remender", taskModel.remender);
                CMD_Update.Parameters.AddWithValue("@repeat", taskModel.repeat);
                CMD_Update.Parameters.AddWithValue("@type_repeat", taskModel.type_repeat);
                CMD_Update.Parameters.AddWithValue("@priority", taskModel.priority);
                CMD_Update.Parameters.AddWithValue("@note", taskModel.note);
                CMD_Update.Parameters.AddWithValue("@is_completed", taskModel.is_completed);
                CMD_Update.Parameters.AddWithValue("@create_on", taskModel.create_on);
                CMD_Update.Parameters.AddWithValue("@id", id);
                CMD_Update.ExecuteReader();

                conn.Close();
            }
        }
        public static void updateSubTaskByID(SubTaskModel subTaskModel, int id)
        {
            string PathToDataBase = Path.Combine(ApplicationData.Current.LocalFolder.Path, "focusTask.db");

            using (SqliteConnection conn = new SqliteConnection($"Filename={ PathToDataBase }"))
            {
                conn.Open();

                SqliteCommand CMD_Update = new SqliteCommand();
                CMD_Update.Connection = conn;
                CMD_Update.CommandText = "UPDATE SubTasks SET id_task = @id_task, name = @name, completed = @completed WHERE id = @id";
                CMD_Update.Parameters.AddWithValue("@id_task", subTaskModel.id_task);
                CMD_Update.Parameters.AddWithValue("@name", subTaskModel.id);
                CMD_Update.Parameters.AddWithValue("@completed", subTaskModel.completed);
                CMD_Update.Parameters.AddWithValue("@id", id);
                CMD_Update.ExecuteReader();

                conn.Close();
            }
        }

        // Delete item by id
        public static void deleteProjectByID(int id)
        {
            string PathToDataBase = Path.Combine(ApplicationData.Current.LocalFolder.Path, "focusTask.db");

            using (SqliteConnection conn = new SqliteConnection($"Filename={ PathToDataBase }"))
            {
                conn.Open();

                SqliteCommand CMD_Delete = new SqliteCommand();
                CMD_Delete.Connection = conn;
                CMD_Delete.CommandText = "DELETE FROM Projects WHERE id = @id";
                CMD_Delete.Parameters.AddWithValue("@id", id);
                CMD_Delete.ExecuteReader();

                conn.Close();
            }
        }
        public static void deleteTaskByID(int id)
        {
            string PathToDataBase = Path.Combine(ApplicationData.Current.LocalFolder.Path, "focusTask.db");

            using (SqliteConnection conn = new SqliteConnection($"Filename={ PathToDataBase }"))
            {
                conn.Open();

                SqliteCommand CMD_Delete = new SqliteCommand();
                CMD_Delete.Connection = conn;
                CMD_Delete.CommandText = "DELETE FROM Tasks WHERE id = @id";
                CMD_Delete.Parameters.AddWithValue("@id", id);
                CMD_Delete.ExecuteReader();

                conn.Close();
            }
        }
        public static void deleteSubTaskByID(int id)
        {
            string PathToDataBase = Path.Combine(ApplicationData.Current.LocalFolder.Path, "focusTask.db");

            using (SqliteConnection conn = new SqliteConnection($"Filename={ PathToDataBase }"))
            {
                conn.Open();

                SqliteCommand CMD_Delete = new SqliteCommand();
                CMD_Delete.Connection = conn;
                CMD_Delete.CommandText = "DELETE FROM SubTasks WHERE id = @id";
                CMD_Delete.Parameters.AddWithValue("@id", id);
                CMD_Delete.ExecuteReader();

                conn.Close();
            }
        }


        // Delete all item
        public static void deleteAllProject()
        {
            string PathToDataBase = Path.Combine(ApplicationData.Current.LocalFolder.Path, "focusTask.db");

            using (SqliteConnection conn = new SqliteConnection($"Filename={ PathToDataBase }"))
            {
                conn.Open();

                SqliteCommand CMD_Delete = new SqliteCommand();
                CMD_Delete.Connection = conn;
                CMD_Delete.CommandText = "DELETE FROM Projects";
                CMD_Delete.ExecuteReader();

                conn.Close();
            }
        }
        public static void deleteAllTask()
        {
            string PathToDataBase = Path.Combine(ApplicationData.Current.LocalFolder.Path, "focusTask.db");

            using (SqliteConnection conn = new SqliteConnection($"Filename={ PathToDataBase }"))
            {
                conn.Open();

                SqliteCommand CMD_Delete = new SqliteCommand();
                CMD_Delete.Connection = conn;
                CMD_Delete.CommandText = "DELETE FROM Tasks";
                CMD_Delete.ExecuteReader();

                conn.Close();
            }
        }
        public static void deleteAllSubTask()
        {
            string PathToDataBase = Path.Combine(ApplicationData.Current.LocalFolder.Path, "focusTask.db");

            using (SqliteConnection conn = new SqliteConnection($"Filename={ PathToDataBase }"))
            {
                conn.Open();

                SqliteCommand CMD_Delete = new SqliteCommand();
                CMD_Delete.Connection = conn;
                CMD_Delete.CommandText = "DELETE FROM SubTasks";
                CMD_Delete.ExecuteReader();

                conn.Close();
            }
        }
    }
}
