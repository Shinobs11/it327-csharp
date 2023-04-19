using System;

namespace Intermediate_1
{
    public class Role
    {
        private string _name;
        private int _level;
        private double _exp;
        private Weapons _weapon;
        //EXP needed to level up, max level 10
        private readonly int[] _expNeeded = {0,10,25,40,60,75,90,100,125,150};
        
        /// <summary>
        /// Constructor for Role, EXP always starts at 0.0
        /// </summary>
        /// <param name="name">Name of character</param>
        /// <param name="level">Starting level</param>
        /// <param name="weapon">Starting weapon, default is none</param>
        protected Role(string name, int level = 1, Weapons weapon = Weapons.None)
        {
            _name = name;
            _level = level;
            _exp = 0.0;
            _weapon = weapon;
        }
        
        /// <summary>
        /// Getter for level
        /// </summary>
        /// <returns>Returns level</returns>
        public int GetLevel()
        {
            return _level;
        }
        
        /// <summary>
        /// Getter for name
        /// </summary>
        /// <returns>Returns name</returns>
        public string GetName()
        {
            return _name;
        }
        
        /// <summary>
        /// Getter for exp
        /// </summary>
        /// <returns>Returns exp</returns>
        public double GetExp()
        {
            return _exp;
        }
        
        /// <summary>
        /// Getter for weapon
        /// </summary>
        /// <returns>Returns weapon</returns>
        public Weapons GetWeapon()
        {
            return _weapon;
        }
        
        /// <summary>
        /// Increment level(s) if EXP is high enough
        /// </summary>
        protected virtual void GrowLevel()
        {
            while(_exp >= _expNeeded[_level] && _level<10)
            {
                _level++;
                Console.WriteLine(_name+" grew to level "+_level+"!");
            }
        }
        
        /// <summary>
        /// Add exp to counter equal to the input, check if character can grow level
        /// </summary>
        public void GainExp(double addition)
        {
            _exp += addition;
            GrowLevel();
        }
        
        /// <summary>
        /// Change weapon to input string
        /// </summary>
        /// <param name="newWeapon">New weapon</param>
        public void ChangeWeapon(Weapons newWeapon)
        {
            _weapon = newWeapon;
            Console.WriteLine("Equipped "+_weapon+"!");
        }
        
        /// <summary>
        /// Prints info about the current character
        /// </summary>
        public virtual void CharacterInfo()
        {
            Console.WriteLine("Name: "+_name);
            Console.WriteLine("Class: "+GetType().Name);
            Console.WriteLine("Level: "+_level);
            Console.WriteLine("EXP: "+_exp);
            Console.WriteLine("Current Weapon: "+_weapon);
        }
    }
}