using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.UI.ViewManagement;

namespace Uwp.Core.Helper
{
    public sealed class CommonHelper
    {
        static public void ChangeSizeLaunchScreen(Size size)
        {
            ApplicationView.GetForCurrentView().SetPreferredMinSize(size);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            ApplicationView.PreferredLaunchViewSize = size;
        }

        static public string GetRandomString(int length)
        {
            string str = "1234567890-=qwertyuiop[]\\asdfghjkl;'zxcvbnm,./`~!@#$%^&*()_+{}|:\"<>?";
            string randomStr = "";
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                randomStr += str[random.Next(0, str.Length)];
            }
            return randomStr;
        }

        static public void SetContentClipboard(string content)
        {
            DataPackage data = new DataPackage();
            data.SetText(content);
            Clipboard.SetContent(data);
        }
    }
}
