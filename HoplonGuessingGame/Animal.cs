using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoplonGuessingGame
{
    public class Animal
    {
        public string Name { get; set; }
        public string Behavior { get; set; }
    }

    public sealed class Animals
    {
        private static readonly List<Animal> List = new List<Animal>();

        public static List<Animal> AnimalsList
        {
            get
            {
                return List;
            }
        }
    }
}
