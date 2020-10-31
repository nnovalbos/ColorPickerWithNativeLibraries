using Android.Content;
using BindingInfColorPickerExample;
using BindingInfColorPickerExample.Droid.CustomRenders;
using Com.Azeesoft.Lib.Colorpicker;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using static Com.Azeesoft.Lib.Colorpicker.ColorPickerDialog;

[assembly: ExportRenderer(typeof(PickerColorSelectorView), typeof(ColorPickerViewRenderer))]
namespace BindingInfColorPickerExample.Droid.CustomRenders
{
    public class ColorPickerViewRenderer : PageRenderer, IOnClosedListener, IOnColorPickedListener
    {
        private PickerColorSelectorView xamarinView;
        private readonly Context _context;

        public ColorPickerViewRenderer(Context contex) : base(contex)
        {
            _context = contex;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            xamarinView = e.NewElement as PickerColorSelectorView;

            ColorPickerDialog colorPickerDialog = CreateColorPickerDialog(_context);
            
            colorPickerDialog.SetOnColorPickedListener(this);
            colorPickerDialog.SetOnClosedListener(this);

            colorPickerDialog.Show();


        }


        public void OnClosed()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                Application.Current.MainPage.Navigation.PopModalAsync();
            });
        }

        public void OnColorPicked(int p0, string p1)
        {
            xamarinView.ColorSelectedDeleate.ColorSelected(Color.FromHex(p1));
        }
    }
}
