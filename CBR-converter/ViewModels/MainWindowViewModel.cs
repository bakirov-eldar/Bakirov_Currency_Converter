using CBR_converter.Views;
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

namespace CBR_converter.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public MainWindowViewModel()
        {

        }
        public string AppName
        {
            get
            {
                return "Конвертер валют";
            }
        }
        public ICommand ExitWindowCommand;
        public ICommand MinimizeWindowCommand;
        private void OnExit()
        {
            Application.Current.Shutdown();
        }
        private void OnMinimize() => Application.Current.MainWindow.WindowState = WindowState.Minimized;
    }
}
