using LiteDB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace UWP.Mvvm.Core.Service
{
    public class FakeObject
    {
        public int Id { get; set; }
    }

    public class LiteDBService : IDataService
    {
        string path;
        LiteDatabase dB;
        ILiteCollection<FakeObject> liteCollection;
        public LiteDBService()
        {
            path = Path.Combine(ApplicationData.Current.LocalFolder.Path, "Data.db");
            dB = new LiteDatabase(path);
            liteCollection = dB.GetCollection<FakeObject>();
        }

        public void DeleteFakeObject(FakeObject FakeObject)
        {
            liteCollection.Delete(FakeObject.Id);
        }

        public ObservableCollection<FakeObject> GetFakeObjects()
        {
            if(liteCollection == null)
            {
                return new ObservableCollection<FakeObject>();
            }
            return new ObservableCollection<FakeObject>(liteCollection.Query().Select(x=>x).ToList());
        }

        public void InsertFakeObject(FakeObject FakeObject)
        {
            liteCollection.Insert(FakeObject);
        }

        public void UpdateFakeObject(FakeObject FakeObject)
        {
            liteCollection.Update(FakeObject);
        }

        private void RegisterDateTimeType()
        {
            BsonMapper.Global.RegisterType<DateTimeOffset>
            (
                serialize: obj =>
                {
                    var doc = new BsonDocument();
                    doc["DateTime"] = obj.DateTime.Ticks;
                    doc["Offset"] = obj.Offset.Ticks;
                    return doc;
                },
                deserialize: doc => new DateTimeOffset(doc["DateTime"].AsInt64, new TimeSpan(doc["Offset"].AsInt64))
            );
        }
        
    }
}
