# XenionDark
A dark theme for WPF applications.

**Table of contents**
1. [Preview](#preview)
2. [How to install](#how-to-install)
3. [How to use](#how-to-use)
   1. [Main Window](#main-window)
   2. [Basic Controls](#basic-controls)
4. [Controls TODO](#controls-todo)
5. [Issues, bugs, suggestions](#issues-bugs-suggestions)

## Preview

![Preview](README/XenionDark_v1.0.0_Preview.gif)

## How to install

1. Download the latest release [here](https://github.com/wRadion/XenionDark/releases).
2. Add the reference to the dll in your projet:

![Import DLL](README/XenionDark_HowToUse_ImportDll.gif)

3. Add the namespace reference in your xaml file:

```xml
  xmlns:xd="clr-namespace:XenionDark;assembly=XenionDark"
```

Example:
```xml
<Window x:Class="MyWPFApplication.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:MyWPFApplication"
        xmlns:xd="clr-namespace:XenionDark;assembly=XenionDark"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
  <Grid>
  <Grid>
</Window>
```

## How to use

### Main Window

To have the custom XenionDark window, your window has to inherit the `XenionDark.Window` class
instead of the default `System.Windows.Window`:

```csharp
// ...
// usings

namespace MyWPFApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : XenionDark.Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
```

And you have to change the `Window` control to `xd:Window` in the .xaml file:

```xml
<xd:Window x:Class="MyWPFApplication.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:MyWPFApplication"
        xmlns:xd="clr-namespace:XenionDark;assembly=XenionDark"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
    <!-- content ... -->
</xd:Window>
```

Don't forget the namespace declaration!

```xml
  xmlns:xd="clr-namespace:XenionDark;assembly=XenionDark"
```

And, add the `Generic.xaml` resource file in your `App.xaml`:

```xml
<Application x:Class="MyWPFApplication.App"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:local="clr-namespace:MyWPFApplication"
             StartupUri="MainWindow.xaml">
    <Application.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="/XenionDark;component/Themes/Generic.xaml" />
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Application.Resources>
</Application>
```

If you run your application, you should see this:

![MainWindow](README/XenionDark_MainWindow.png)

### Basic Controls

The current XenionDark version has the following controls implemented:
- `xd:Button`
- `xd:CheckBox`
- `xd:ComboBox`
  - `ComboBoxItem`
- `xd:ContextMenu` and `xd.Menu`
  - `xd:MenuItem`
  - **Separator** is implemented but it's tricky to override, so you have to use
  an empty `xd:MenuItem` to display a separator: `<xd:MenuItem />`
- `xd:ListBox`
  - `ListBoxItem`
- `xd:RadioButton`
- `xd:ScrollViewer`
  - `xd:ScrollBar`
- `xd:Switch`
    - A custom control that inherits `ToggleButton`. The **boolean value**
    is stored in the property `IsChecked` (like a `CheckBox` or `RadioButton`).
- `xd:TextBlock`
- `xd:TextBox`
    - A custom property `Placeholder` was added to display a text inside the
    box. It disappears when the TextBox has focus or when there's a text inside.
- `xd:Window`

All the custom controls inherit the basic Windows control. So you can
use any properties you want as if the control was the default one.

## Controls TODO

Here is the list of some controls that I plan to do in the future:

- ~~Button~~ **(v1.0.0)**
- Calendar
    - CalendarButton
    - CalendarDayButton
    - CalendarItem
- ~~CheckBox~~ **(v1.0.0)**
- ~~ComboBox~~ **(v1.0.0)**
  - ~~ComboBoxItem~~ **(v1.0.0)**
- ~~ContextMenu~~ **(v1.0.0)**
  - ~~MenuItem~~ **(v1.0.0)**
- DatePicker
  - DatePickerTextBox
- GroupBox
- ~~ListBox~~ **(v1.0.0)**
  - ~~ListBoxItem~~ **(v1.0.0)**
- ListView
  - ListViewItem
- ~~Menu~~ **(v1.0.0)**
  - ~~MenuItem~~ **(v1.0.0)**
- MessageBox
- PasswordBox
- ProgressBar
- ~~RadioButton~~ **(v1.0.0)**
- RichTextBox
- ~~ScrollViewer~~ **(v1.0.0)**
  - ~~ScrollBar~~ **(v1.0.0)**
- Slider
- StatusBar
  - StatusBarItem
- ~~Switch~~ **(Custom, v1.0.0)**
- TabControl
  - TabItem
  - TabPanel
- ~~TextBlock~~ **(v1.0.0)**
- ~~TextBox~~ **(v1.0.0)**
- ToggleButton (see Switch)
- ToolBar
  - ToolBarPanel
  - ToolBarTray
- TreeView
  - TreeViewItem
- ~~Window~~ **(v1.0.0)**

I also plan to make this theme customizable (the colors for example)
and some other stuff. Hope you'll like it!

## Issues, bugs, suggestions

This project is at a very early development stage. If you have any questions, issues
or requests for this theme please feel free to create a Github issue or you
can contact me at **`wradion@gmail.com`**.
