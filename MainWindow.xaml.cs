using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WindowsInput;
using WindowsInput.Native;

namespace WpfHorizPage
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    /// 
    


    public partial class MainWindow : Window
    {

        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
        public const int KEYEVENTF_EXTENDEDKEY = 0x0001; //Key down flag
        public const int KEYEVENTF_KEYUP = 0x0002; //Key up flag
        public const int VK_RCONTROL = 0xA3; //Right Control key code
        public const int VK_LCONTROL = 0xA2; //Left CONTROL key
        public const int VK_RIGHT = 0x27; //Right Arrow
        public const int VK_LEFT = 0x25; //Right Arrow
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainVM();
        }
        private void Send(Key key)
        {
            if (Keyboard.PrimaryDevice != null)
            {
                if (Keyboard.PrimaryDevice.ActiveSource != null)
                {
                    var e1 = new System.Windows.Input.KeyEventArgs(
                        Keyboard.PrimaryDevice, Keyboard.PrimaryDevice.ActiveSource, 0, key)
                    { RoutedEvent = Keyboard.KeyDownEvent };
                    bool b = InputManager.Current.ProcessInput(e1);
                }
            }
        }
        private void DataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.PageDown)
            {
                e.Handled = true;
                DataGrid dg = sender as DataGrid;
                if (dg != null && (dg.CurrentColumn.DisplayIndex + 1 < dg.Columns.Count))
                {
                    keybd_event(VK_LCONTROL, 0, KEYEVENTF_EXTENDEDKEY, 0);
                    keybd_event(VK_RIGHT, 0, KEYEVENTF_EXTENDEDKEY, 0);
                    keybd_event(VK_RIGHT, 0, KEYEVENTF_KEYUP, 0);
                    keybd_event(VK_LCONTROL, 0, KEYEVENTF_KEYUP, 0);
                    //var myInputSimulator = new InputSimulator();
                    //myInputSimulator.Keyboard.KeyDown(VirtualKeyCode.CONTROL);
                    //myInputSimulator.Keyboard.KeyPress(VirtualKeyCode.RIGHT);
                    //myInputSimulator.Keyboard.KeyUp(VirtualKeyCode.CONTROL);
                }
            }
            if (e.Key == Key.PageUp)
            {
                e.Handled = true;
                {
                    keybd_event(VK_LCONTROL, 0, KEYEVENTF_EXTENDEDKEY, 0);
                    keybd_event(VK_LEFT, 0, KEYEVENTF_EXTENDEDKEY, 0);
                    keybd_event(VK_LEFT, 0, KEYEVENTF_KEYUP, 0);
                    keybd_event(VK_LCONTROL, 0, KEYEVENTF_KEYUP, 0);
                    //var myInputSimulator = new InputSimulator();
                    //myInputSimulator.Keyboard.KeyDown(VirtualKeyCode.CONTROL);
                    //myInputSimulator.Keyboard.KeyPress(VirtualKeyCode.LEFT);
                    //myInputSimulator.Keyboard.KeyUp(VirtualKeyCode.CONTROL);
                }
            }
        }
    }
}
