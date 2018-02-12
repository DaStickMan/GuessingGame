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
    /// Interaction logic for  AddAnimalName.xaml
    /// </summary>
    public partial class AddAnimalName : Window
    {
        private bool returnMainMenu = true;
        private Animal animal;

        public AddAnimalName(Animal animal)
        {
            this.animal = animal;
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var addAnimalBehavior = new AddAnimalBehavior(new Animal { Name = textBoxName.Text });
            addAnimalBehavior.label.Content = String.Format(addAnimalBehavior.label.Content.ToString(), textBoxName.Text, animal.Name);
            addAnimalBehavior.Show();
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
