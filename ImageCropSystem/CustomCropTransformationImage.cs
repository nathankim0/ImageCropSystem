using System;
using FFImageLoading.Forms;
using FFImageLoading.Transformations;
using FFImageLoading.Work;
using Xamarin.Forms;

namespace ImageCropSystem
{
    public class CustomCropTransformationImage : CachedImage
    {
        public static BindableProperty OptionsProperty = BindableProperty.Create(nameof(Options), typeof(double[]), typeof(CustomCropTransformationImage), null, propertyChanged: UpdateOptions);

        public double[] Options
        {
            get { return (double[])GetValue(OptionsProperty); }
            set { SetValue(OptionsProperty, value); }
        }
        private static void UpdateOptions(BindableObject bindable, object oldValue, object newValue)
        {
            var _new = (double[])newValue;

            var view = (CustomCropTransformationImage)bindable;
            var transformations = new System.Collections.Generic.List<ITransformation>() {
                    new CropTransformation()
                    {
                        XOffset = _new[0],
                        YOffset = _new[1],
                        CropHeightRatio =_new[2],
                        CropWidthRatio = _new[3]
                    }
                };
            view.Transformations = transformations;
        }
    }
}
