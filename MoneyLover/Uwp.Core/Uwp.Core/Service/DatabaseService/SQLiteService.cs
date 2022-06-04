using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uwp.SQLite.Model;

namespace Uwp.Core.Service
{
    public class SQLiteService : IDataService
    {
        private static DataContext _db = new DataContext();
        public static DataContext Db { get { return _db; } }

        //Viết các hàm lấy dữ liệu tại đây
        public void DeleteDataObject(DataObject DataObject)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DataObject> GetDataObjects()
        {
            throw new NotImplementedException();
        }

        public void InsertDataObject(DataObject DataObject)
        {
            throw new NotImplementedException();
        }

        public void UpdateDataObject(DataObject DataObject)
        {
            throw new NotImplementedException();
        }
    }
}
