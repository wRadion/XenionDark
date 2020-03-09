using System.Windows;

namespace XenionDark.Controls
{
   public class RadioButton : System.Windows.Controls.RadioButton
    {
        static RadioButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RadioButton), new FrameworkPropertyMetadata(typeof(RadioButton)));
        }
    }
}
