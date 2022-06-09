using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace KeepSafeForPassword.Model
{
    public class RandomPassword : ObservableObject
    {
        private double _length;
        public double Length { get { return _length; } set { SetProperty(ref _length, value); } }
        public bool IsAZChecked { get; set; }
        public bool Is09Checked { get; set; }
        public bool IsSymbolChecked { get; set; }

        public RandomPassword()
        {
            Length = 8;
            IsAZChecked = true;
            Is09Checked = true;
            IsSymbolChecked = true;
        }

        public string Random()
        {
            string az = "qwertyuiopasdfghjklzxcvbnm";
            string symbol = "!@#$%^&*()_+{}:\"<>?,./';][=-\\|";
            string s09 = "0123456789";
            string strToRandom = string.Empty;

            if (IsAZChecked)
            {
                strToRandom += az;
            }
            if (Is09Checked)
            {
                strToRandom += s09;
            }
            if (IsSymbolChecked)
            {
                strToRandom += symbol;
            }

            string result = string.Empty;
            Random random = new Random();

            if(strToRandom.Length > 0)
            {
                for(int i=0; i<Length; i++)
                {
                    int index = random.Next(0, strToRandom.Length);
                    result += strToRandom[index];
                }
            }
            return result;
        }
    }
}
