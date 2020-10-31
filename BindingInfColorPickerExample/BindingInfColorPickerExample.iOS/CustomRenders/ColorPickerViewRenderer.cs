using System;
using BindingInfColorPickerExample;
using BindingInfColorPickerExample.iOS.CustomRenders;
using InfColorPicker;
using CoreGraphics;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;

[assembly: ExportRenderer(typeof(PickerColorSelectorView), typeof(ColorPickerViewRenderer))]
namespace BindingInfColorPickerExample.iOS.CustomRenders
{
    public class ColorPickerViewRenderer : PageRenderer
    {

        private PickerColorSelectorView xamarinView;
        private InfColorPickerController picker;

        public ColorPickerViewRenderer()
        {
        }

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            xamarinView = e.NewElement as PickerColorSelectorView;
            picker = InfColorPickerController.ColorPickerViewController;
            picker.View.Frame = new CGRect(0, 50, View.Frame.Width, NativeView.Frame.Height - 50);
            xamarinView.BackgroundColor = picker.View.BackgroundColor.ToColor();
            NativeView.Add(picker.View);

        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            UIBarButtonItem rightItem = new UIBarButtonItem("DONE", UIBarButtonItemStyle.Plain, (sender, e) =>
            {
                var color = picker.ResultColor;
                if (color != null)
                {
                    xamarinView.ColorSelectedDeleate.ColorSelected(color.ToColor());
                }
                else
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Xamarin.Forms.Application.Current.MainPage.Navigation.PopModalAsync();
                    });
                }
            });


            NavigationController.TopViewController.NavigationItem.RightBarButtonItem = rightItem;
        }
    }
}
