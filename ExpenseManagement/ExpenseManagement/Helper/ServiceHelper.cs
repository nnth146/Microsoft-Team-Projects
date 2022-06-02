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
using UWP.Mvvm.Core.Service;

namespace Uwp.Mvvm.Core.Helper
{
    public sealed class ServiceHelper
    {
        static public void ConfigureServices()
        {
            /*
             * Thêm libraryName với projectName phù hợp
             */
            string libraryName = "ExpenseManagement";
            string viewModelNameSpace = libraryName + ".ViewModel";
            string projectName = "ExpenseManagement";
            string viewNameSpace = projectName + ".View";
            string viewDialogNameSpace = projectName + ".View.Dialog";

            Type[] typeViewList = GetTypesInNamespace(Assembly.Load(projectName), viewNameSpace);
            Type[] typeDialogList = GetTypesInNamespace(Assembly.Load(projectName), viewDialogNameSpace);
            Type[] typeViewModelList = GetTypesInNamespace(Assembly.GetExecutingAssembly(), viewModelNameSpace);

            var pages = GetPages(typeViewList, typeViewModelList);
            var dialogs = GetDialogs(typeDialogList, typeViewModelList);

            var services = new ServiceCollection()
                .AddSingleton<IDataService, LiteDBService>()
                .AddSingleton<INavigationService>(new NavigationService(pages))
                .AddSingleton<IDialogService>(new DialogService(dialogs))
                .AddSingleton<IMessenger, MessengerService>();

            for (int i = 0; i < typeViewModelList.Length; i++)
            {
                services.AddTransient(typeViewModelList[i]);
            }

            Ioc.Default.ConfigureServices(services.BuildServiceProvider());

            GenerateViewModelLocator(typeViewModelList);
        }

        static private Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
        {
            return
              assembly.GetTypes()
                      .Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal))
                      .ToArray();
        }

        static private Dictionary<Type, Type> GetPages(Type[] typeViewList, Type[] typeViewModelList)
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

        static private Dictionary<Type, Type> GetDialogs(Type[] typeViewList, Type[] typeViewModelList)
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

        static private void GenerateViewModelLocator(Type[] typelist)
        {
            Debug.WriteLine("Auto generate viewmodellocator by tuanhungdev =)))");
            for (int i = 0; i < typelist.Length; i++)
            {
                string result = "public " + typelist[i].Name + " " + typelist[i].Name.Split("ViewModel").First() + " => Ioc.Default.GetService<" + typelist[i].Name + ">();";
                Debug.WriteLine(result);
            }
            Debug.WriteLine("--------------------------------------------------");
        }
    }
}
