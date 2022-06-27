using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin_Projekt
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Kompas : ContentPage
    {
        CompassViewModel vm;
        public Kompas()
        {
            BindingContext = vm = new CompassViewModel();
            vm.StartCompass();
            InitializeComponent();
        }
    }
}