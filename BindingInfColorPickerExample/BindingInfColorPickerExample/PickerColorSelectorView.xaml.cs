using Xamarin.Forms;

namespace BindingInfColorPickerExample
{
    public partial class PickerColorSelectorView : ContentPage
    {
        public IColorSelectedDelegate ColorSelectedDeleate { get; set; }

       // public Grid GriDoneButton => GridDone;

        public PickerColorSelectorView()
        {
            InitializeComponent();
        }
    }
}
