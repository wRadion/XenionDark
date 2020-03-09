using System.Windows;

namespace XenionDark.Controls
{
    public class ScrollBar : System.Windows.Controls.Primitives.ScrollBar
    {
        static ScrollBar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ScrollBar), new FrameworkPropertyMetadata(typeof(ScrollBar)));
        }
    }
}
