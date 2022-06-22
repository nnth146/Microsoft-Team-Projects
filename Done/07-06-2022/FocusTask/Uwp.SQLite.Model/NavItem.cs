using System;
using System.Collections.Generic;
using System.Text;

namespace Uwp.SQLite.Model
{
    public class NavItem
    {
        public string Content { get; set; }
        public string Icon { get; set; }
        public Type Page { get; set; }


        public IEnumerable<Mission> Missions { get; set; }
    }
}
