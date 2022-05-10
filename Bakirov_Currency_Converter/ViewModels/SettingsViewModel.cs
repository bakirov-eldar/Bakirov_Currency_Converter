using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Windows;
using Microsoft.Toolkit.Mvvm.Input;
using Bakirov_Currency_Converter.Models;

namespace Bakirov_Currency_Converter.ViewModels
{
    public class SettingsViewModel : ObservableObject
    {
        public List<string> Languages { get; set; } = new List<string>()
        {
            Resources.Languages.Lang.SystemLanguage,
            "English",
            "Русский"
        };
        public List<string> Themes 
        {
            get
            {
                return new List<string>()
                {
                    Resources.Languages.Lang.SystemTheme,
                    Resources.Languages.Lang.LightTheme,
                    Resources.Languages.Lang.DarkTheme
                };
            }
        }
        public SettingsViewModel()
        {
        }
        private AppLanguage _currentLanguage;
        public AppLanguage CurrentLanguage
        {
            get => _currentLanguage;
            set
            {
                if (_currentLanguage == value)
                    return;
                _currentLanguage = value;

            }
        }
        private AppTheme _currentTheme;
        public AppTheme CurrentTheme
        {
            get { return _currentTheme; }
            set
            {
                int GetSystemTheme()
                {
                    var OsTheme = Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", "AppsUseLightTheme", "1");
                    if (OsTheme != null && OsTheme.ToString() == "0")
                        return 2;
                    return 1;
                }
                if (_currentTheme == value)
                    return;
                _currentTheme = value;
                

                var uri = new Uri($"Resources/Styles/{
                    _currentTheme switch
                    {
                        > 0 => $"{_currentTheme}",
                        _ => $"{(AppTheme)GetSystemTheme()}",
                    }
                    }Style.xaml", UriKind.Relative);
                ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
                Application.Current.Resources.MergedDictionaries.RemoveAt(0);
                Application.Current.Resources.MergedDictionaries.Add(resourceDict);
            }
        }
    }
}
