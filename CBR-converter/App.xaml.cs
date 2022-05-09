using System;
using System.Collections.Generic;
using System.Windows;

namespace CBR_converter
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        List<string> Styles = new List<string>()
        {
            "Resources/Styles/LightStyle.xaml",
            "Resources/Styles/DarkStyle.xaml"
        };
        public App()
        {
            InitializeComponent();
            LoadResource(0);
        }
        public void LoadResource(int index)
        {
            
            var uri = new Uri(Styles[index], UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.MergedDictionaries.RemoveAt(0);
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }
    }
}
