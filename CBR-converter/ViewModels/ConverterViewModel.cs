using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CBR_converter.ViewModels
{
    public class ConverterViewModel : ObservableObject
    {

        public List<string> ValuteList { get; set; }
        public List<string> ValuteList2 { get; set; }
        public ConverterViewModel()
        {
            ValuteList = new List<string>();
            ValuteList.Add("asd1");
            ValuteList.Add("asd2");
            ValuteList.Add("asd3");
            ValuteList.Add("asd1");
            ValuteList.Add("asd2");
            ValuteList.Add("asd3");
            ValuteList.Add("asd1");
            ValuteList.Add("asd2");
            ValuteList.Add("asd3");
            ValuteList2 = new List<string>();
            ValuteList2.Add("asd1");
            ValuteList2.Add("asd2");
            ValuteList2.Add("asd3");
        }
    }
}
