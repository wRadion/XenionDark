using System.Windows;
using System.Windows.Controls;

namespace XenionDark
{
    public enum SizeToItems
    {
        Manual,
        Width
    }


    public class ComboBox : System.Windows.Controls.ComboBox
    {
        public static DependencyProperty SizeToItemsProperty = DependencyProperty.Register("SizeToItems", typeof(SizeToItems), typeof(ComboBox));

        public SizeToItems SizeToItems
        {
            get => (SizeToItems)GetValue(SizeToItemsProperty);
            set => SetValue(SizeToItemsProperty, value);
        }

        static ComboBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ComboBox), new FrameworkPropertyMetadata(typeof(ComboBox)));
        }

        protected override void OnChildDesiredSizeChanged(UIElement child)
        {
            base.OnChildDesiredSizeChanged(child);

            if (SizeToItems == SizeToItems.Width && child is Border border)
            {
                ColumnDefinition col = (ColumnDefinition)Template.FindName("firstColumn", this);

                col.Width = new GridLength(border.ActualWidth - 16);
                Height = MinHeight;
            }

            ((ListBox)Template.FindName("listBox", this)).Visibility = Visibility.Collapsed;
        }
    }
}
