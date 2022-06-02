using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP.Mvvm.Core.Service
{
    public interface IDataService
    {
        ObservableCollection<FakeObject> GetFakeObjects();
        void InsertFakeObject(FakeObject FakeObject);
        void UpdateFakeObject(FakeObject FakeObject);
        void DeleteFakeObject(FakeObject FakeObject);
    }
}
