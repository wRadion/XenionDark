using System.Windows;

namespace XenionDark
{
    public class MenuItem : System.Windows.Controls.MenuItem
    {
        static MenuItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MenuItem), new FrameworkPropertyMetadata(typeof(MenuItem)));
        }
    }
}
