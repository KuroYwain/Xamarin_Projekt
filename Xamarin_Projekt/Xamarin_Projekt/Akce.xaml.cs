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
    public partial class Akce : ContentPage
    {
        public Acc AccelerometrInstance { get; set; }
        public Akce()
        {
            AccelerometrInstance = new Acc();
            BindingContext = AccelerometrInstance;
            InitializeComponent();
        }
    }
}