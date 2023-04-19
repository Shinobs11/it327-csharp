using System;
using System.Collections.Generic;
using System.Linq;

namespace Intermediate_1
{
    internal class Program2
    {
        private List<Role> _characters = new List<Role>();
        public static void Main(string[] args)
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
                                  "4 - Change class\n" +
                                  "5 - Add EXP\n" +
                                  "6 - Change weapon\n" +
                                  "7 - Exit\n");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    CreateClass();
                    break;
                case "2":
                    CheckChar();
                    break;
                case "3":
                    DeleteChar();
                    break;
                case "4":
                    ChangeClass();
                    break;
                case "5":
                    AddExpToChar();
                    break;
                case "6":
                    ChangeWeapon();
                    break;
                case "7":
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
            if (_characters.Any(c => c.GetName() == name))
            {
                Console.WriteLine("Name already taken");
            }
            else
            {
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
            Console.WriteLine("\n");
            Menu();
        }
        
        /// <summary>
        /// Gets name input, checks if that char exists, and prints its info
        /// </summary>
        private void CheckChar()
        {
            Console.WriteLine("Input character name:");
            string name = Console.ReadLine();
            //If any character has that matching name
            if (CheckName(name))
            {
                Role c = _characters.Find(x => x.GetName() == name);
                c.CharacterInfo();
            }
            Menu();
        }
        
        /// <summary>
        /// Deletes a character given their name
        /// </summary>
        private void DeleteChar()
        {
            Console.WriteLine("Input character name:");
            string name = Console.ReadLine();
            //If any character has that matching name
            if (CheckName(name))
            {
                Role c = _characters.Find(x => x.GetName() == name);
                _characters.Remove(c);
                Console.WriteLine("Deleted "+name+"\n");
            }
            Console.WriteLine("\n");
            Menu();
        }
        
        /// <summary>
        /// Given name of a character and new class, changes the class of that character
        /// </summary>
        private void ChangeClass()
        {
            Console.WriteLine("Input character name:");
            string name = Console.ReadLine();
            if (CheckName(name))
            {
                Role c = _characters.Find(x => x.GetName() == name);
                Console.WriteLine("Input new class");
                Console.WriteLine("\nInput class(Black Mage=0, White Mage = 1:");
                string role = Console.ReadLine();
                
                //TODO: CHeck if inputted character is already of that class type
                switch (role)
                {
                    case "0":
                        BlackMage bm = new BlackMage(c.GetName(),c.GetLevel(),c.GetWeapon());
                        bm.GainExp(c.GetExp());
                        _characters.Remove(c);
                        _characters.Add(bm);
                        break;
                    case "1":
                        WhiteMage wm = new WhiteMage(c.GetName(),c.GetLevel(),c.GetWeapon());
                        wm.GainExp(c.GetExp());
                        _characters.Remove(c);
                        _characters.Add(wm);
                        break;
                    default:
                        Console.WriteLine("Invalid class");
                        break;
                }
            }
            Console.WriteLine("\n");
            Menu();
        }
        
        /// <summary>
        /// Checks if the input name is associated with a character
        /// </summary>
        /// <param name="name">Name to check</param>
        /// <returns>T/F if char exists</returns>
        private bool CheckName(string name)
        {
            if (_characters.Any(c => c.GetName() == name))
            {
                return true;
            }
            Console.WriteLine("No character with that name");
            return false;
        }
        
        /// <summary>
        /// Adds specified EXP amount to the specified character
        /// </summary>
        private void AddExpToChar()
        {
            Console.WriteLine("Input character name:");
            string name = Console.ReadLine();
            if (CheckName(name))
            {
                Console.WriteLine("Input exp amount:");
                //TODO: Make sure value is a double
                double exp = Convert.ToDouble(Console.ReadLine());  
                Role c = _characters.Find(x => x.GetName() == name);
                c.GainExp(exp);
            }
            Console.WriteLine("\n");
            Menu();
        }
        
        /// <summary>
        /// Changes a character's equipped weapon given their name and the new weapon
        /// </summary>
        private void ChangeWeapon()
        {
            Console.WriteLine("Input character name:");
            string name = Console.ReadLine();
            if (CheckName(name))
            {
                Role c = _characters.Find(x => x.GetName() == name);
                Console.WriteLine("\nInput new weaon(None, Stick, Club, ShortSword, Axe, Broadsword\n");
                Console.WriteLine("Input new weapon name:");
                string weapon = Console.ReadLine();
                if (Enum.IsDefined(typeof(Weapons), weapon))
                {
                    Weapons w = (Weapons) Enum.Parse(typeof(Weapons), weapon);
                    c.ChangeWeapon(w);
                }
                else
                {
                    Console.WriteLine("Invalid weapon type\n");
                }
            }
            Console.WriteLine("\n");
            Menu();
        }
    }
}