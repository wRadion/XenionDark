using System.Windows;

namespace XenionDark.Controls
{
    public class ListBox : System.Windows.Controls.ListBox
    {
        static ListBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ListBox), new FrameworkPropertyMetadata(typeof(ListBox)));
        }
    }
}
