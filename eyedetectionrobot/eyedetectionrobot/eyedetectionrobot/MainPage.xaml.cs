using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace eyedetectionrobot
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        ImageSource image = ImageSource.FromUri(new Uri("https://assets.change.org/photos/5/oe/en/wVoEENmUBcLEAhU-800x450-noPad.jpg?1531231373"));

        public MainPage()
        {
            InitializeComponent();
        }
    }
}

