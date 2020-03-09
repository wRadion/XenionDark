using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace XenionDark.Controls.Subcontrols
{
    /// <summary>
    /// Interaction logic for TitleBar.xaml
    /// </summary>
    public partial class TitleBar : UserControl
    {
        public static readonly BitmapImage MaximizeIcon;
        public static readonly BitmapImage UnmaximizeIcon;

        static TitleBar()
        {
            MaximizeIcon = new BitmapImage(new Uri(@"/XenionDark;component/Themes/Generic/Resources/Images/Window/maximize_icon.png", UriKind.Relative));
            UnmaximizeIcon = new BitmapImage(new Uri(@"/XenionDark;component/Themes/Generic/Resources/Images/Window/unmaximize_icon.png", UriKind.Relative));
        }

        public static DependencyProperty WindowProperty = DependencyProperty.Register("Window", typeof(Window), typeof(TitleBar));
        public static DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(Image), typeof(TitleBar));
        public static DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(TitleBar));

        public Window Window
        {
            get => (Window)GetValue(WindowProperty);
            set => SetValue(WindowProperty, value);
        }
        public Image Icon
        {
            get => (Image)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }
        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public TitleBar()
        {
            InitializeComponent();
        }

        public override void EndInit()
        {
            if (Window != null)
            {
                Window.StateChanged += Window_StateChanged;
                Window_StateChanged(this, new EventArgs());

                if (Window.ResizeMode == ResizeMode.NoResize)
                {
                    BtnMinimize.Visibility = Visibility.Hidden;
                    BtnMaximize.Visibility = Visibility.Hidden;
                }
                else if (Window.ResizeMode == ResizeMode.CanMinimize)
                {
                    BtnMaximize.IsEnabled = false;
                }
            }

            base.EndInit();
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (Window.WindowState == WindowState.Normal)
                Maximize.Source = MaximizeIcon;
            else
                Maximize.Source = UnmaximizeIcon;
        }

        private void MinimizeWindow() => Window.WindowState = WindowState.Minimized;
        private void MaximizeWindow()
        {
            if (Window.WindowState == WindowState.Normal)
                Window.WindowState = WindowState.Maximized;
            else
                Window.WindowState = WindowState.Normal;
        }
        private void CloseWindow() => Window.Close();

        private void Minimize_Click(object sender, RoutedEventArgs e) => MinimizeWindow();
        private void Maximize_Click(object sender, RoutedEventArgs e) => MaximizeWindow();
        private void Close_Click(object sender, RoutedEventArgs e) => CloseWindow();
        private void DragBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount % 2 == 0 && BtnMaximize.IsEnabled && BtnMaximize.Visibility == Visibility.Visible)
                MaximizeWindow();
            else
                Window.DragMove();
        }
    }
}
