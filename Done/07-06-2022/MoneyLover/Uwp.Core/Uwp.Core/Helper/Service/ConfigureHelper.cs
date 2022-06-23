using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Uwp.Core.Service;

namespace Uwp.Core.Helper
{
    public sealed class ConfigureHelper : IDisposable
    {

        public ConfigureHelper()
        {
            _projectName = "MoneyLover";
            _viewNameSpace = _projectName + ".View";
            _viewModelNameSpace = _projectName + ".ViewModel";
            _viewDialogNameSpace = _projectName + ".View.Dialog";

            _typeViewList = GetTypesInNamespace(Assembly.Load(_projectName), _viewNameSpace);
            _typeDialogList = GetTypesInNamespace(Assembly.Load(_projectName), _viewDialogNameSpace);
            _typeViewModelList = GetTypesInNamespace(Assembly.Load(_projectName), _viewModelNameSpace);
        }

        private readonly string _projectName;
        private readonly string _viewNameSpace;
        private readonly string _viewModelNameSpace;
        private readonly string _viewDialogNameSpace;

        private Type[] _typeViewList;
        private Type[] _typeDialogList;
        private Type[] _typeViewModelList;

        public static void ConfigureAll()
        {
            ConfigureHelper helper = new ConfigureHelper();

            helper.ConfigureServices();

            //Nếu sử dụng Uwp.SQLite.Model thì bỏ ghi chú
            //helper.ConfigureDatabase();

            //Tự động tạo biến cho khi chạy chương trình ViewModelLocator
            helper.GenerateViewModelLocator(helper._typeViewModelList);
        }

        #region Configure Services

        public void ConfigureDatabase()
        {
            using(SQLite.Model.DataContext db = new SQLite.Model.DataContext())
            {
                //Thực hiện Migrate. Chỉ có thể thực hiện sau khi build Migration
                db.Database.Migrate();
            }
        }

        public void ConfigureServices()
        {
            //Sử dụng cho View và ViewModel cùng một project

            var services = new ServiceCollection()
                .AddSingleton<IDataService, SQLiteService>()
                .AddSingleton<INavigationService>(new NavigationService(GetPages(_typeViewList, _typeViewModelList)))
                .AddSingleton<IDialogService>(new DialogService(GetDialogs(_typeDialogList, _typeViewModelList)))
                .AddSingleton<IMessenger, MessengerService>();

            for (int i = 0; i < _typeViewModelList.Length; i++)
            {
                services.AddTransient(_typeViewModelList[i]);
            }

            Ioc.Default.ConfigureServices(services.BuildServiceProvider());

        }
        private void GenerateViewModelLocator(Type[] typelist)
        {
            Debug.WriteLine("Auto generate ViewModelLocator");
            Debug.WriteLine("--------------------------------------------------");
            for (int i = 0; i < typelist.Length; i++)
            {
                if (typelist[i].Name == "<>c") continue;

                string result = "public " + typelist[i].Name + " " + typelist[i].Name.Split("ViewModel").First() + " => Ioc.Default.GetService<" + typelist[i].Name + ">();";
                Debug.WriteLine(result);
            }
            Debug.WriteLine("--------------------------------------------------");
        }

        private Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
        {
            return
              assembly.GetTypes()
                      .Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal))
                      .ToArray();
        }

        private Dictionary<Type, Type> GetPages(Type[] typeViewList, Type[] typeViewModelList)
        {
            Dictionary<Type, Type> pages = new Dictionary<Type, Type>();
            foreach (Type type in typeViewList)
            {
                foreach (Type typeViewModel in typeViewModelList)
                {
                    if (typeViewModel.Name.Replace("ViewModel", "") == type.Name)
                    {
                        pages.Add(typeViewModel, type);
                        break;
                    }
                }
            }
            return pages;
        }

        private Dictionary<Type, Type> GetDialogs(Type[] typeViewList, Type[] typeViewModelList)
        {
            Dictionary<Type, Type> pages = new Dictionary<Type, Type>();
            foreach (Type type in typeViewList)
            {
                foreach (Type typeViewModel in typeViewModelList)
                {
                    if (typeViewModel.Name.Replace("ViewModel", "") == type.Name && type.Name.Contains("Dialog"))
                    {
                        pages.Add(typeViewModel, type);
                        break;
                    }
                }
            }
            return pages;
        }

        public void Dispose()
        {
            
        }

        #endregion
    }
}
