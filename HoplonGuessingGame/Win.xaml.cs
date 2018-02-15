using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HoplonGuessingGame
{
    /// <summary>
    /// Interaction logic for Win.xaml
    /// </summary>
    public partial class Win : Window
    {
        private bool clickedOk = false;

        public Win()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            clickedOk = true;
            var mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (!clickedOk)
            {
                var mainWindow = new MainWindow();
                mainWindow.Show();
            }
        }
    }
}
