using Bakirov_Currency_Converter.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace Bakirov_Currency_Converter.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        private readonly Style OpenSettingsButtonStyle = App.Current.FindResource("OpenSettingsButtonStyle") as Style;
        private readonly Style CloseSettingsButtonStyle = App.Current.FindResource("CloseSettingsButtonStyle") as Style;
        public MainWindowViewModel()
        {
            MinimizeWindowCommand = new RelayCommand(OnMinimize);
            ExitWindowCommand = new RelayCommand(OnExit);
            ChangeViewCommand = new RelayCommand(OnChangeView);
            MainContent = ConverterView;
            SettingsButtonStyle = OpenSettingsButtonStyle;
        }
        private ConverterView ConverterView = new();
        private SettingsView SettingsView = new();
        private ContentControl _mainContent;
        public ContentControl MainContent
        {
            get => _mainContent;
            set => SetProperty(ref _mainContent, value);
        }
        public string AppName
        {
            get
            {
                return "Конвертер валют";
            }
        }
        public RelayCommand ExitWindowCommand { get; init; }
        public RelayCommand MinimizeWindowCommand { get; init; }
        public RelayCommand ChangeViewCommand { get; set; }
        private Style _settingsButtonStyle;
        public Style SettingsButtonStyle
        {
            get => _settingsButtonStyle;
            set => SetProperty(ref _settingsButtonStyle, value);
        }
        private void OnChangeView()
        {
            if (MainContent is ConverterView)
            {
                MainContent = SettingsView;
                SettingsButtonStyle = CloseSettingsButtonStyle;
                return;
            }
            MainContent = ConverterView;
            SettingsButtonStyle =OpenSettingsButtonStyle;
        }
        private void OnExit() => Application.Current.Shutdown();
        private void OnMinimize() => Application.Current.MainWindow.WindowState = WindowState.Minimized;
    }
}
