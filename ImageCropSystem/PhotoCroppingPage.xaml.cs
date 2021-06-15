using System;
using Xamarin.Forms;
using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace ImageCropSystem
{
    public partial class PhotoCroppingPage : ContentPage
    {
        PhotoCropperCanvasView photoCropper;
        SKBitmap croppedBitmap;
        SKBitmap bitmap;

        public PhotoCroppingPage()
        {
            InitializeComponent();

            bitmap = BitmapExtensions.LoadBitmapResource(GetType(),
                "ImageCropSystem.Image.png");
            widthLabel.Text = bitmap.Width.ToString();
            heightLabel.Text = bitmap.Height.ToString();
            widthEntry.Text = widthLabel.Text;
            heightEntry.Text = heightLabel.Text;
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            var info = args.Info;
            var surface = args.Surface;
            var canvas = surface.Canvas;

            canvas.Clear();
            canvas.DrawBitmap(croppedBitmap, info.Rect, BitmapStretch.Uniform);
        }

        void Button_Clicked(object sender, EventArgs e)
        {
            photoCropper = new PhotoCropperCanvasView(bitmap, float.Parse(widthEntry.Text), float.Parse(heightEntry.Text), float.Parse(xEntry.Text), float.Parse(yEntry.Text));

            croppedBitmap = photoCropper.CroppedBitmap;

            var canvasView = new SKCanvasView();
            canvasView.PaintSurface += OnCanvasViewPaintSurface;
            contentView.Content = canvasView;
        }
    }
}