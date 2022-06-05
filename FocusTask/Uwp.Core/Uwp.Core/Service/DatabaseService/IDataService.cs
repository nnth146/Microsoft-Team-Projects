using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uwp.Core.Service
{
    public interface IDataService
    {
        IEnumerable<DataObject> GetDataObjects();
        void InsertDataObject(DataObject DataObject);
        void UpdateDataObject(DataObject DataObject);
        void DeleteDataObject(DataObject DataObject);
    }
}
