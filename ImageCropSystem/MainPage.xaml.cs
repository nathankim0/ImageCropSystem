using System;
using FFImageLoading.Transformations;
using Xamarin.Forms;

namespace ImageCropSystem
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

         
            image.SizeChanged += Image_SizeChanged;
        }

        private void Image_SizeChanged(object sender, EventArgs e)
        {
            var w = image.Width;
            var h = image.Height;

            widthLabel.Text = w.ToString();
            heightLabel.Text = h.ToString();

            //crop.CropHeightRatio = 1;
            //crop.CropWidthRatio = 1;
            //crop.XOffset = w / 3;
            //crop.YOffset = -h / 3;
        }

        //void Button_Clicked(object sender, EventArgs e)
        //{
        //    var transformation = image.Transformations[0];
        //    ((CropTransformation)transformation).CropHeightRatio = 2;
            //((CropTransformation)transformation).CropWidthRatio = 1;
        //}
    }
}
