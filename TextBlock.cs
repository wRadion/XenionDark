using System.Windows;

namespace XenionDark
{
   public class TextBlock : System.Windows.Controls.TextBlock
    {
        static TextBlock()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TextBlock), new FrameworkPropertyMetadata(typeof(TextBlock)));
        }
    }
}
