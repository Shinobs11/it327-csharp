using System;
using System.Collections.Generic;

namespace Intermediate_1
{
    public class BlackMage: Role, IMage
    {
        private List<string> _spells;
        
        //List of spells avaiable
        private readonly string[] _possibleSpells =
            {"", "Blaze", "Crack", "", "Woosh", "Buff", "", "BlazeMore", "Crackle", "Kabuff"};
        
        /// <summary>
        /// Constructor, calls base constructor Role
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="level">Level, default 1</param>
        /// <param name="weapon">Weapon, default None</param>
        public BlackMage(string name, int level = 1, Weapons weapon = Weapons.None) : base(name, level, weapon)
        {
            _spells = new List<string>();
        }
        
        /// <summary>
        /// Cast a spell, given the spell name
        /// </summary>
        /// <param name="spell"></param>
        public void CastSpell(string spell)
        {
            //If character has this spell
            if (_spells.Contains(spell))
            {
                Console.WriteLine(GetName() + " casted: " + spell);
            }
            else
            {
                Console.WriteLine(GetName() + " does not know "+spell);
            }
        }
        
        /// <summary>
        /// Prints spells currently learned
        /// </summary>
        public void ListSpells()
        {
            foreach (var spell in _spells)
            {
                Console.WriteLine(spell+"\n");
            }
        }
        /// <summary>
        /// Checks if current level has a new spell to learn, invoked when level is gained
        /// </summary>
        public void GainSpell()
        {
            //If current level has a new spell, then add it to current known list
            if (_possibleSpells[GetLevel()] != "")
            {
                _spells.Add(_possibleSpells[GetLevel()]);
                Console.WriteLine(GetName()+" learned "+_possibleSpells[GetLevel()]+"!");
            }
        }
        /// <summary>
        /// Overridden function, checks if character can grow a level, if so, checks
        /// if they gain a spell as well
        /// </summary>
        protected override void GrowLevel()
        {
            int temp = GetLevel();
            base.GrowLevel();
            //Checks if character gained a level
            //If so, check for new spell
            if (GetLevel() > temp)
            {
                GainSpell();
            }
        }
        
        /// <summary>
        /// Overridden function, calls base CharacterInfo() alongside known spells
        /// </summary>
        public override void CharacterInfo()
        {
            base.CharacterInfo();
            Console.WriteLine("Spells: ");
            ListSpells();
        }
    }
}