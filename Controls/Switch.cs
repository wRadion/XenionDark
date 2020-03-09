using System.Windows;

namespace XenionDark.Controls
{
    public class Switch : System.Windows.Controls.Primitives.ToggleButton
    {
        static Switch()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Switch), new FrameworkPropertyMetadata(typeof(Switch)));
        }
    }
}
