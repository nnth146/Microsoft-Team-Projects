using System;
using System.Collections.Generic;
using System.Text;

namespace KeepSafeForPassword.Model
{
    public class NavViewItem
    {
        public string Icon { get; set; }
        public string Title { get; set; }
        public Type Page { get; set; }

        public static List<NavViewItem> All = new List<NavViewItem>
        {
            new NavViewItem
            {
                Icon = "ms-appx:///Assets/Icons/lock.png",
                Title = "All Password",
            },
            new NavViewItem
            {
                Icon = "/Assets/Icons/user.png",
                Title = "Contact",
            },
            new NavViewItem
            {
                Icon = "ms-appx:///Assets/Icons/lock.png",
                Title = "All Password"
            },
            new NavViewItem
            {
                Icon = "ms-appx:///Assets/Icons/lock.png",
                Title = "All Password"
            },
            new NavViewItem
            {
                Icon = "ms-appx:///Assets/Icons/lock.png",
                Title = "All Password"
            },
        };
    }
}
