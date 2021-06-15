using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace ImageCropSystem
{
    class PhotoCropperCanvasView : SKCanvasView
    {
        SKBitmap bitmap;
        SKRect cropRect;

        public PhotoCropperCanvasView(SKBitmap bitmap, float width, float hegiht, float x = 0, float y = 0)
        {
            this.bitmap = bitmap;
            cropRect = new SKRect(x, y, width, hegiht);
        }

        public SKBitmap CroppedBitmap
        {
            get
            {
                SKBitmap croppedBitmap = new SKBitmap((int)cropRect.Width,
                                                      (int)cropRect.Height);
                SKRect dest = new SKRect(0, 0, cropRect.Width, cropRect.Height);
                SKRect source = new SKRect(cropRect.Left, cropRect.Top,
                                           cropRect.Right, cropRect.Bottom);

                using (SKCanvas canvas = new SKCanvas(croppedBitmap))
                {
                    canvas.DrawBitmap(bitmap, source, dest);
                }

                return croppedBitmap;
            }
        }
    }
}