using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_game
{
    /// <summary>
    /// Gegner-Typ Elfe mit mittleren Lebenspunkten. Erbt von <see cref="Entity"/>.
    /// </summary>
    internal class Elfe : Entity
    {
        /// <summary>
        /// Erstellt eine neue Elfe mit dem angegebenen Namen und setzt die Lebenspunkte.
        /// </summary>
        /// <param name="name">Anzeigename der Elfe.</param>
        public Elfe(string name = "Elfe"): base(name)
        {
            //Name = "Elfe";
            HP = 400;
            voll_HP = this.HP;
        }

        /// <summary>
        /// Gibt die aktuellen Lebenspunkte der Elfe zurück.
        /// </summary>
        /// <returns>Aktuelle Lebenspunkte der Elfe.</returns>
        public new double getHP()
        {
            return HP;
        }
    }
}