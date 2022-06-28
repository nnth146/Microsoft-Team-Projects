using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4sTodo.Model
{
    public class TagOfWork
    {
        public ObservableCollection<string> ListTag { get; set; }

        public TagOfWork()
        {
            ListTag = new ObservableCollection<string>
            {
                "Work",
                "Bussiness",
                "Sport",
                "Life"
            };
        }
    }
}
