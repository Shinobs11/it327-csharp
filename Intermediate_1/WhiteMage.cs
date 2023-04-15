using System;
using System.Collections.Generic;

namespace Intermediate_1
{
    public class WhiteMage: Role, IMage
    {
        private List<string> _spells;

        private readonly string[] _possibleSpells =
            {"", "Heal", "Squelch", "", "Sap", "HealMore", "", "Zoom", "Insulatle", "Zing"};
        public WhiteMage(string name, int level = 1, Weapons weapon = Weapons.None) : base(name, level, weapon)
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
    }
}