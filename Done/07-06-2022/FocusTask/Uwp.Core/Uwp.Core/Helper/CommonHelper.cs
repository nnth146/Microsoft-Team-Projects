using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Storage;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;

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

        static public object GetAppResources(string key)
        {
            return Application.Current.Resources[key];
        }

        private async Task<byte[]> ConvertImageToByte(StorageFile file)
        {
            using (var inputStream = await file.OpenSequentialReadAsync())
            {
                var readStream = inputStream.AsStreamForRead();

                var byteArray = new byte[readStream.Length];
                await readStream.ReadAsync(byteArray, 0, byteArray.Length);
                return byteArray;
            }

        }
    }
}
