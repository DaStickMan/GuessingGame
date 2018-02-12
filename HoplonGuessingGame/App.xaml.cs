using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HoplonGuessingGame
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Animals.AnimalsList.Add(new Animal { Name = "monkey" });
            Animals.AnimalsList.Add(new Animal { Name = "shark", Behavior = "lives in water" });
        }
    }
}
