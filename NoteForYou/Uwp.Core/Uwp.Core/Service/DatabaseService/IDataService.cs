using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP.Core.Service
{
    public interface IDataService
    {
        ObservableCollection<DataObject> GetDataObjects();
        void InsertDataObject(DataObject DataObject);
        void UpdateDataObject(DataObject DataObject);
        void DeleteDataObject(DataObject DataObject);
    }
}
