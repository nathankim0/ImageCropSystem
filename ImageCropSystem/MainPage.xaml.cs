using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ImageCropSystem
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            crop.XOffset = image.Width / 2;
        }
    }
}
