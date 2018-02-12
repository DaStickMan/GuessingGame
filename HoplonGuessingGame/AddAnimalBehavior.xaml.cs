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
    /// Interaction logic for AddAnimalBehavior.xaml
    /// </summary>
    public partial class AddAnimalBehavior : Window
    {
        private Animal animal;
        private bool returnMainMenu = true;

        public AddAnimalBehavior(Animal animal)
        {
            this.animal = animal;
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            animal.Behavior = textBoxBehavior.Text;
            Animals.AnimalsList.Add(animal);
            var mainWindow = new MainWindow();
            mainWindow.Show();
            returnMainMenu = false;
            Close();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (returnMainMenu)
            {
                var mainWindow = new MainWindow();
                mainWindow.Show();
            }
        }
    }
}
