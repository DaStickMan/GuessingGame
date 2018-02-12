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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HoplonGuessingGame
{
    /// <summary>
    /// Interaction logic for AskBehavior.xaml
    /// </summary>
    public partial class AskBehavior : Window
    {
        private bool allowClosing = false;

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("user32.dll")]
        private static extern bool EnableMenuItem(IntPtr hMenu, uint uIDEnableItem, uint uEnable);

        private const uint MF_BYCOMMAND = 0x00000000;
        private const uint MF_GRAYED = 0x00000001;

        private const uint SC_CLOSE = 0xF060;

        private const int WM_SHOWWINDOW = 0x00000018;
        private const int WM_CLOSE = 0x10;

        private Animal animal;

        public AskBehavior(Animal animal)
        {
            InitializeComponent();
            this.animal = animal;
        }

        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            var askName = new AskName(animal);
            askName.textName.Text += animal.Name + "?";
            askName.Show();
            allowClosing = true;
            Close();
        }

        private void No_Click(object sender, RoutedEventArgs e)
        {
            var index = Animals.AnimalsList.IndexOf(animal);

            var actualIndex = index + 1;

            if(Animals.AnimalsList.Count <= actualIndex)
            {
                var askName = new AskName(Animals.AnimalsList.FirstOrDefault());
                askName.textName.Text += Animals.AnimalsList.FirstOrDefault().Name + "?";
                askName.Show();
                allowClosing = true;
                Close();
            }
            else
            {
                var askBehavior = new AskBehavior(Animals.AnimalsList.ElementAt(actualIndex));
                askBehavior.textBehavior.Text += Animals.AnimalsList.ElementAt(actualIndex).Behavior + "?";
                askBehavior.Show();
                allowClosing = true;
                Close();
            }
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);

            HwndSource hwndSource = PresentationSource.FromVisual(this) as HwndSource;

            if (hwndSource != null)
            {
                hwndSource.AddHook(HwndSourceHook);
            }
        }

        private IntPtr HwndSourceHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch (msg)
            {
                case WM_SHOWWINDOW:
                    {
                        IntPtr hMenu = GetSystemMenu(hwnd, false);
                        if (hMenu != IntPtr.Zero)
                        {
                            EnableMenuItem(hMenu, SC_CLOSE, MF_BYCOMMAND | MF_GRAYED);
                        }
                    }
                    break;
                case WM_CLOSE:
                    if (!allowClosing)
                    {
                        handled = true;
                    }
                    break;
            }
            return IntPtr.Zero;
        }
    }
}
