using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uwp.HCore.Service.Database
{
    public interface IDataService
    {
        ObservableCollection<object> GetData();
        void InsertData(object Object);

        void UpdateData(object Object);

        void DeleteData(object Object);

        void RemoveAllData();
    }
}
