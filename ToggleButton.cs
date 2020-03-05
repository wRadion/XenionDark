using System.Windows;

namespace XenionDark
{
    public class ToggleButton : System.Windows.Controls.Primitives.ToggleButton
    {
        static ToggleButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ToggleButton), new FrameworkPropertyMetadata(typeof(ToggleButton)));
        }
    }
}
