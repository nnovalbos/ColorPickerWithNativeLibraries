using System;
using Xamarin.Forms;

namespace BindingInfColorPickerExample
{
    public interface IColorSelectedDelegate
    {
        void ColorSelected(Color color);
    }
}
