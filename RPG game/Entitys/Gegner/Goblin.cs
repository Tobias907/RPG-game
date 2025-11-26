using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_game
{
    /// <summary>
    /// Gegner-Typ Goblin mit Standardwerten für Lebenspunkte und Schaden.
    /// </summary>
    internal class Goblin : Entity
    {
        /// <summary>
        /// Erstellt einen neuen Goblin mit dem angegebenen Namen.
        /// </summary>
        /// <param name="name">Anzeigename des Gegners.</param>
        public Goblin(string name = "Goblin") :base(name)
        {
            voll_HP = this.HP;
        }
    }
}