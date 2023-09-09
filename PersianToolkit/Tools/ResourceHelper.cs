using System;
using System.Windows;

namespace PersianToolkit
{
    public class ResourceHelper
    {

        /// <summary>
        ///    
        /// </summary>
        /// <param name="skin"></param>
        /// <returns></returns>
        public static ResourceDictionary GetSkin(SkinType skin)
        {
            return new ResourceDictionary
            {
                Source = new Uri($"pack://application:,,,/PersianToolkit;component/Themes/Skin{skin.ToString()}.xaml")
            };
        }

        public static T GetResource<T>(string key)
        {
            if (Application.Current.TryFindResource(key) is T resource)
            {
                return resource;
            }

            return default(T);
        }
    }
}