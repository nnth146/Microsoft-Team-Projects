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
        private readonly static DataContext _db = new DataContext();
        public DataContext Db => _db;

        //Code
    }
}
