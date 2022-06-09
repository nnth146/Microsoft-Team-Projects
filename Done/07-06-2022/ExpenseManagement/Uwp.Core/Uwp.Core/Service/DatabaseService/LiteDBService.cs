using LiteDB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Uwp.Core.Service
{
    public class DataObject
    {
        public int Id { get; set; }
    }

    public class LiteDBService : IDataService
    {
        string path;
        LiteDatabase dB;
        ILiteCollection<DataObject> liteCollection;
        public LiteDBService()
        {
            path = Path.Combine(ApplicationData.Current.LocalFolder.Path, "Data.db");
            dB = new LiteDatabase(path);
            liteCollection = dB.GetCollection<DataObject>();
        }

        public void DeleteDataObject(DataObject DataObject)
        {
            liteCollection.Delete(DataObject.Id);
        }

        public IEnumerable<DataObject> GetDataObjects()
        {
            if(liteCollection == null)
            {
                return new ObservableCollection<DataObject>();
            }
            return new ObservableCollection<DataObject>(liteCollection.Query().Select(x=>x).ToList());
        }

        public void InsertDataObject(DataObject DataObject)
        {
            liteCollection.Insert(DataObject);
        }

        public void UpdateDataObject(DataObject DataObject)
        {
            liteCollection.Update(DataObject);
        }
    }
}
