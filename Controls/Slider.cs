using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace XenionDark.Controls
{
    public class Slider : System.Windows.Controls.Slider
    {
        public static DependencyProperty AutoToolTipFormatProperty = DependencyProperty.Register("AutoToolTipFormat", typeof(string), typeof(Slider));
        public static DependencyProperty AutoToolTipStyleProperty = DependencyProperty.Register("AutoToolTipStyle", typeof(Style), typeof(Slider));

        public string AutoToolTipFormat
        {
            get => (string)GetValue(AutoToolTipFormatProperty);
            set => SetValue(AutoToolTipFormatProperty, value);
        }

        public Style AutoToolTipStyle
        {
            get => (Style)GetValue(AutoToolTipStyleProperty);
            set => SetValue(AutoToolTipStyleProperty, value);
        }

        private ToolTip _autoToolTip;
        private bool _styleSet = false;
        private ToolTip AutoToolTip
        {
            get
            {
                if (_autoToolTip == null)
                {
                    FieldInfo field = typeof(System.Windows.Controls.Slider).GetField("_autoToolTip", BindingFlags.NonPublic | BindingFlags.Instance);
                    _autoToolTip = (ToolTip)field.GetValue(this);
                }

                if (_autoToolTip != null && !_styleSet && AutoToolTipStyle != null)
                {
                    _autoToolTip.Style = AutoToolTipStyle;
                    _styleSet = true;
                }

                return _autoToolTip;
            }
        }

        static Slider()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Slider), new FrameworkPropertyMetadata(typeof(Slider)));
        }

        private void FormatAutoToolTip()
        {
            if (string.IsNullOrEmpty(AutoToolTipFormat)) return;
            AutoToolTip.Content = string.Format(AutoToolTipFormat, AutoToolTip.Content);
        }

        protected override void OnThumbDragStarted(DragStartedEventArgs e)
        {
            base.OnThumbDragStarted(e);
            FormatAutoToolTip();
        }

        protected override void OnThumbDragDelta(DragDeltaEventArgs e)
        {
            base.OnThumbDragDelta(e);
            FormatAutoToolTip();
        }
    }
}
