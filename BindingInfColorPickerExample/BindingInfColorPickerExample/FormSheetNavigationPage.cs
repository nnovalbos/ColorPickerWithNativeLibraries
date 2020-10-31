using System;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace BindingInfColorPickerExample
{
    public class FormSheetNavigationPage : Xamarin.Forms.NavigationPage
    {
        public FormSheetNavigationPage(Xamarin.Forms.Page root) : base(root)
        {
            On<iOS>().SetModalPresentationStyle(UIModalPresentationStyle.FormSheet);
        }
    }
}
