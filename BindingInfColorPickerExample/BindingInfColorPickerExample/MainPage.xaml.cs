using Xamarin.Forms;
using BindingInfColorPickerExample;
using System;

namespace BindingInfColorPickerExample
{
    public partial class MainPage : ContentPage, IColorSelectedDelegate
    {

        public MainPage()
        {
            InitializeComponent();
        }

        public void ColorSelected(Color color)
        {
            this.BackgroundColor = color;
            Navigation.PopModalAsync();
        }

        void Button_Clicked(Object sender, System.EventArgs e)
        {
            var pickerView = new PickerColorSelectorView();
            pickerView.ColorSelectedDeleate = this;
            Navigation.PushModalAsync(new FormSheetNavigationPage(pickerView));
        }
    }
}
