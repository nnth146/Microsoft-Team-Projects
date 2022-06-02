using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uwp.Mvvm.Core.Helper
{
    public class LinkingHelper
    {
        /* Sumary
         * Đối tượng này để hỗ trợ liên kết giữa các viewmodel
         * 
         */
        private static LinkingHelper _instance = new LinkingHelper();
        public static LinkingHelper Default => _instance;
        public LinkingHelper()
        {
            //Thêm các liên kết tại đây
        }

        //Danh sách các view model

    }
}
