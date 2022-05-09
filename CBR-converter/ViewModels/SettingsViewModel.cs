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

namespace CBR_converter.ViewModels
{
    public class SettingsViewModel : ObservableObject
    {
        public List<string> Themes { get;}
        public SettingsViewModel()
        {
            Themes = new List<string>();
            Themes.Add("Светлая");
            Themes.Add("Тёмная");
        }
        public int CurrentTheme
        {
            get 
            { 
                return _currentTheme;
            }
            set 
            {
                if (value == _currentTheme)
                    return;
                _currentTheme = value;
                if (value == 0)
                {
                    
                    LoadResource("Resources/Styles/LightStyle.xaml");
                    return;
                }
                LoadResource("Resources/Styles/DarkStyle.xaml");
            }
        }
        int _currentTheme;
        public void LoadResource(string path_f)
        {
            var uri = new Uri(path_f, UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.MergedDictionaries.RemoveAt(0);
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }
    }
}
