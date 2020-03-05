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
        public static DependencyProperty MaximizedBorderBrushProperty = DependencyProperty.Register("MaximizedBorderBrush", typeof(Brush), typeof(Window), new PropertyMetadata(new SolidColorBrush(Color.FromRgb(0,0,0))));
        public static DependencyProperty MaximizedBorderThicknessProperty = DependencyProperty.Register("MaximizedBorderThickness", typeof(Thickness), typeof(Window), new PropertyMetadata(new Thickness(0)));

        public MaximizedWindowType MaximizedWindowType
        {
            get => (MaximizedWindowType)GetValue(MaximizedWindowTypeProperty);
            set
            {
                UpdateMaxHeight(value);
                SetValue(MaximizedWindowTypeProperty, value);
            }
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

        static Window()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Window), new FrameworkPropertyMetadata(typeof(Window)));
        }

        public override void EndInit()
        {
            UpdateMaxHeight(MaximizedWindowType);
            base.EndInit();
        }

        private bool CanResize()
        {
            if (WindowStyle == WindowStyle.ToolWindow) return false;
            if (ResizeMode == ResizeMode.NoResize) return false;
            if (ResizeMode == ResizeMode.CanMinimize) return false;
            if (SizeToContent != SizeToContent.Manual) return false;

            return true;
        }

        private void UpdateMaxHeight(MaximizedWindowType type)
        {
            if (!CanResize()) return;

            if (type == MaximizedWindowType.Default)
                MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight - 2;
            else if (type == MaximizedWindowType.Fullscreen)
                MaxHeight = double.PositiveInfinity;
        }

        private void ToggleMaximizedWindowType()
        {
            if (!CanResize()) return;

            if (MaximizedWindowType == MaximizedWindowType.Default)
                MaximizedWindowType = MaximizedWindowType.Fullscreen;
            else
                MaximizedWindowType = MaximizedWindowType.Default;
        }

        public void ToggleFullscreen()
        {
            if (!CanResize()) return;

            if (WindowState == WindowState.Maximized)
            {
                ToggleMaximizedWindowType();
                if (MaximizedWindowType == MaximizedWindowType.Fullscreen)
                {
                    WindowState = WindowState.Normal;
                    WindowState = WindowState.Maximized;
                }
            }
            else
            {
                MaximizedWindowType = MaximizedWindowType.Fullscreen;
                WindowState = WindowState.Maximized;
            }
        }
    }
}
