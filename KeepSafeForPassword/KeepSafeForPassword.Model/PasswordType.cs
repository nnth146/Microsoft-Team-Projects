using System;
using System.Collections.Generic;
using System.Text;

namespace KeepSafeForPassword.Model
{
    public class PasswordType
    {
        public string Title { get; set; }
        public string Icon { get; set; }

        public static List<PasswordType> All { get; set; } = new List<PasswordType>
        {
            new PasswordType
            {
                Title = "Password",
                Icon = "ms-appx:///Assets/Icons/lock.png"
            },
            new PasswordType
            {
                Title = "Contact",
                Icon = "ms-appx:///Assets/Icons/user.png"
            },
            new PasswordType
            {
                Title = "Address",
                Icon = "ms-appx:///Assets/Icons/map-pin.png"
            },
            new PasswordType
            {
                Title = "Database",
                Icon = "ms-appx:///Assets/Icons/database.png"
            },
            new PasswordType
            {
                Title = "Sever",
                Icon = "ms-appx:///Assets/Icons/server.png"
            },
            new PasswordType
            {
                Title = "Secure Note",
                Icon = "ms-appx:///Assets/Icons/Clipboard Note.png"
            },
        };
    }
}
