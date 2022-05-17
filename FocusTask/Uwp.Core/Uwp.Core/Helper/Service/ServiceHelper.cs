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
using UWP.Core.Service;

namespace Uwp.Core.Helper
{
    public sealed class ServiceHelper
    {
        static public void ConfigureServices()
        {
            //Sử dụng cho view và viewmodel cùng một project
            string projectName = "FocusTask";
            string viewNameSpace = projectName + ".View";
            string viewModelNameSpace = projectName + ".ViewModel";
            string viewDialogNameSpace = projectName + ".View.Dialog";

            Type[] typeViewList = GetTypesInNamespace(Assembly.Load(projectName), viewNameSpace);
            Type[] typeDialogList = GetTypesInNamespace(Assembly.Load(projectName), viewDialogNameSpace);
            Type[] typeViewModelList = GetTypesInNamespace(Assembly.Load(projectName), viewModelNameSpace);

            var services = new ServiceCollection()
                .AddSingleton<IDataService, LiteDBService>()
                .AddSingleton<INavigationService>(new NavigationService(GetPages(typeViewList, typeViewModelList)))
                .AddSingleton<IDialogService>(new DialogService(GetDialogs(typeDialogList, typeViewModelList)))
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
