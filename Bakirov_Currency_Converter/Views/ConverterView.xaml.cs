using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Bakirov_Currency_Converter.ViewModels;

namespace Bakirov_Currency_Converter.Views
{
    /// <summary>
    /// Логика взаимодействия для ConverterPageView.xaml
    /// </summary>
    public partial class ConverterView : UserControl
    {
        public ConverterView()
        {
            InitializeComponent();

            DataContext = new ConverterViewModel();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        
        void OnComboboxTextChanged(object sender, RoutedEventArgs e)
        {
            var combobox = (ComboBox)sender;
            var tb = (TextBox)e.OriginalSource;
            if (tb.SelectionStart != 0)
            {
                combobox.SelectedItem = null; // Если набирается текст сбросить выбраный элемент
            }
            if (tb.SelectionStart == 0 && combobox.SelectedItem == null)
            {
                combobox.IsDropDownOpen = false; // Если сбросили текст и элемент не выбран, сбросить фокус выпадающего списка
            }

            combobox.IsDropDownOpen = true;
            if (combobox.SelectedItem == null)
            {
                // Если элемент не выбран менять фильтр
                CollectionView cv = (CollectionView)CollectionViewSource.GetDefaultView(combobox.ItemsSource);
                cv.Filter = s => ((string)s).IndexOf(combobox.Text, StringComparison.CurrentCultureIgnoreCase) >= 0;
            }
        }
    }
}
