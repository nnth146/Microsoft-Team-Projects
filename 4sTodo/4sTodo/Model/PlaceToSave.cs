using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4sTodo.Model
{   
    public class PlaceToSave
    {
        public string Icon { get; set; }
        public string Name { get; set; }
    }

    public class ListPlaceToSave
    {
        public ObservableCollection<PlaceToSave> PlaceToSaves { get; set; }

        public ListPlaceToSave()
        {
            PlaceToSaves = new ObservableCollection<PlaceToSave>
            {
                new PlaceToSave
                {
                    Icon = "ms-appx:///Assets/Icon/Icon5.png",
                    Name = "Urgent and important"
                },
                new PlaceToSave
                {
                    Icon = "ms-appx:///Assets/Icon/Icon6.png",
                    Name = "Import not urgent"
                },
                new PlaceToSave
                {
                    Icon = "ms-appx:///Assets/Icon/Icon7.png",
                    Name = "Not Urgent / important"
                },
                new PlaceToSave
                {
                    Icon = "ms-appx:///Assets/Icon/Icon8.png",
                    Name = "Urgent not important"
                },
            };
        }
    }
}
