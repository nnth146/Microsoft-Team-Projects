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
                Icon = "ms-appx:///Assets/Icons/icon_password.png"
            },
            new PasswordType
            {
                Title = "Contact",
                Icon = "ms-appx:///Assets/Icons/icon_contact.png"
            },
            new PasswordType
            {
                Title = "Address",
                Icon = "ms-appx:///Assets/Icons/icon_address.png"
            },
            new PasswordType
            {
                Title = "Database",
                Icon = "ms-appx:///Assets/Icons/icon_database.png"
            },
            new PasswordType
            {
                Title = "Server",
                Icon = "ms-appx:///Assets/Icons/icon_server.png"
            },
            new PasswordType
            {
                Title = "Secure Note",
                Icon = "ms-appx:///Assets/Icons/icon_secure_note.png"
            },
            new PasswordType
            {
                Title = "Wifi",
                Icon = "ms-appx:///Assets/Icons/icon_wifi.png"
            },
        };
    }
}
