using System;
using System.Windows;
using System.Windows.Media;

namespace XenionDark
{
    public enum MaximizedWindowType
    {
        Default,
        Fullscreen
    }

    public class Window : System.Windows.Window
    {
        public static DependencyProperty MaximizedWindowTypeProperty = DependencyProperty.Register("MaximizedWindowType", typeof(MaximizedWindowType), typeof(Window), new PropertyMetadata(MaximizedWindowType.Default));
        public static DependencyProperty MaximizedBorderBrushProperty = DependencyProperty.Register("MaximizedBorderBrush", typeof(Brush), typeof(Window), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(0,0,0,0))));
        public static DependencyProperty MaximizedBorderThicknessProperty = DependencyProperty.Register("MaximizedBorderThickness", typeof(Thickness), typeof(Window), new PropertyMetadata(new Thickness(0)));

        public MaximizedWindowType MaximizedWindowType
        {
            get => (MaximizedWindowType)GetValue(MaximizedWindowTypeProperty);
            set => SetValue(MaximizedWindowTypeProperty, value);
        }
        public Brush MaximizedBorderBrush
        {
            get => (Brush)GetValue(MaximizedBorderBrushProperty);
            set => SetValue(MaximizedBorderBrushProperty, value);
        }
        public Thickness MaximizedBorderThickness
        {
            get => (Thickness)GetValue(MaximizedBorderThicknessProperty);
            set => SetValue(MaximizedBorderThicknessProperty, value);
        }

        public Window ThisWindow => this;
        public Thickness OffsetBorderThickness
        {
            get => new Thickness(7 + MaximizedBorderThickness.Left,
                7 + MaximizedBorderThickness.Top,
                7 + MaximizedBorderThickness.Right,
                7 + MaximizedBorderThickness.Bottom);
        }

        static Window()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Window), new FrameworkPropertyMetadata(typeof(Window)));
        }

        protected override void OnInitialized(EventArgs e)
        {
            if (MaximizedWindowType == MaximizedWindowType.Default)
                MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight - 2;

            base.OnInitialized(e);
        }
    }
}
