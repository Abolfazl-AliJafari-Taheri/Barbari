using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Markup;

namespace PersianToolkit
{
    /// <summary>
    /// کلاسی برای تغییر نوع تقویم
    /// </summary>
    public class ConfigHelper : INotifyPropertyChanged
    {
        private ConfigHelper()
        {

        }

        public static ConfigHelper Instance = new Lazy<ConfigHelper>(() => new ConfigHelper()).Value;

        private XmlLanguage _lang = XmlLanguage.GetLanguage("fa-ir");

        public XmlLanguage Lang
        {
            get => _lang;
            set
            {
                if (!_lang.IetfLanguageTag.Equals(value.IetfLanguageTag))
                {
                    _lang = value;
                    OnPropertyChanged(nameof(Lang));
                }
            }
        }

        public void SetLanguage(Language language)
        {
            if (language == Language.Persian)
            {
                Lang = XmlLanguage.GetLanguage("fa-ir");
            }
            else if (language == Language.Gregorian)
            {
                Lang = XmlLanguage.GetLanguage("en-us");
            }

            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo((int)language);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
        }

        public enum Language
        {
            Persian = 1065,
            Gregorian = 1033
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
