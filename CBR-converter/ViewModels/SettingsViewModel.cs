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
using CBR_converter.Models;

namespace CBR_converter.ViewModels
{
    public class SettingsViewModel : ObservableObject
    {
        public List<string> Themes { get; }
        public SettingsViewModel()
        {
            Themes = new List<string>()
            {

            };
        }

        private AppTheme currentTheme;
        public AppTheme CurrentTheme
        {
            get { return currentTheme; }
            set
            {
                if (currentTheme == value)
                    return;
                currentTheme = value;
                var uri = new Uri($"Resources/Styles/{currentTheme}Style.xaml", UriKind.Relative);
                ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
                Application.Current.Resources.MergedDictionaries.RemoveAt(0);
                Application.Current.Resources.MergedDictionaries.Add(resourceDict);
            }
        }
    }
}
