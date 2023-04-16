using System;
using System.Collections.Generic;

namespace Intermediate_1
{
    internal class Program2
    {
        private List<Role> _characters = new List<Role>();
        public void Main(string[] args)
        {
            Program2 p = new Program2();
            p.Menu();
        }
        /// <summary>
        /// Driver menu for program
        /// </summary>
        private void Menu()
        {
            Console.Out.WriteLine("What do you want to do?");
            Console.Out.WriteLine("1 - Create new character\n" +
                                  "2 - Check stats of character\n" +
                                  "3 - Delete character\n" +
                                  "4 - Developer Mode\n" +
                                  "5 - Change class\n" +
                                  "6 - Exit\n");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    CreateClass();
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    break;
                case "6":
                    Console.WriteLine("Exiting application");
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }
        
        /// <summary>
        /// Gets user input and creates a new character
        /// </summary>
        private void CreateClass()
        {
            //TODO: Add check for existing name
            Console.WriteLine("Input name:");
            string name = Console.ReadLine();
            Console.WriteLine("\nInput class(Black Mage=0, White Mage = 1:");
            string role = Console.ReadLine();
            switch (role)
            {
                case "0":
                    BlackMage bm = new BlackMage(name);
                    _characters.Add(bm);
                    break;
                case "1":
                    WhiteMage wm = new WhiteMage(name);
                    _characters.Add(wm);
                    break;
                default:
                    Console.WriteLine("Invalid class");
                    break;
            }
        }
    }
}