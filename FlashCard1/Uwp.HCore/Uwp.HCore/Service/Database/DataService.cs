using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uwp.HCore.Service.Database
{
    public class DataObjectDataContext
    {
        public int Id { get; set; }
        public object Object { get; set; }

    }
    public class DataService : IDataService
    {
        public static DataObjectDataContext db = new DataObjectDataContext();

        public void DeleteData(object Object)
        {
            //Example
            //db.Remove(item);
            //db.SaveChanges();

            throw new NotImplementedException();
        }

        public ObservableCollection<object> GetData()
        {

            // return ObservableCollection<object> data = new ObservableCollection<object>(db.Object.ToList());
            throw new NotImplementedException();
        }

        public void InsertData(object Object)
        {
            //Example
            //db.Add(new NgayMua(item.Name, item.Money, item.AmountGuest, item.NameGuests, item.DateBuy));
            //db.SaveChanges();
            //-----
            throw new NotImplementedException();
        }

        public void RemoveAllData()
        {
            //Example
            //db.Ngaymuas.RemoveRange(db.Ngaymuas);
            //db.SaveChanges();

            throw new NotImplementedException();
        }

        public void UpdateData(object Object)
        {

            //Example
            //NgayMua tmp = db.Ngaymuas.OrderBy(b => item.Id).FirstOrDefault();
            //tmp = item;
            //db.SaveChanges();

            throw new NotImplementedException();
        }
    }
}
