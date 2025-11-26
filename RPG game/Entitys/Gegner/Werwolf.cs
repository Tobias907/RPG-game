using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_game
{
    /// <summary>
    /// Stärkerer Gegner-Typ Werwolf mit erhöhten Lebenspunkten und Schaden.
    /// </summary>
    internal class Werwolf : Entity
    {
        /// <summary>
        /// Erstellt einen neuen Werwolf mit erhöhten Lebenspunkten.
        /// </summary>
        /// <param name="name">Anzeigename des Gegners.</param>
        public Werwolf(string name = "Werwolf") : base(name)
        {
            HP = 600;
            voll_HP = this.HP;
        }

        /// <summary>
        /// Gibt den dreifachen Basisangriffsschaden des Werwolfs zurück.
        /// </summary>
        /// <returns>Modifizierter Angriffsschaden des Werwolfs.</returns>
        public override double getAttack_damage()
        {
            return Attack_damage * 3;
        }

        /// <summary>
        /// Gibt die aktuellen Lebenspunkte des Werwolfs zurück.
        /// </summary>
        /// <returns>Aktuelle Lebenspunkte.</returns>
        public new double getHP()
        {
            return HP;
        }
    }
}