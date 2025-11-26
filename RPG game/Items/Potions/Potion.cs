using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_game
{
    /// <summary>
    /// Basisklasse für Tränke, die als Inventar-Items verwendet werden können.
    /// </summary>
    internal class Potion : IInventarItem
    {
        /// <summary>
        /// Platzbedarf des Tranks im Inventar.
        /// </summary>
        public int InventarGroesse { get; }

        /// <summary>
        /// Anzeigename des Tranks.
        /// </summary>
        public string ItemName { get; }

        /// <summary>
        /// Verwendet den Trank auf einer Entität.
        /// Die Basisklasse implementiert nur eine Platzhalter-Logik.
        /// </summary>
        /// <param name="entity">Zielentität, auf die der Trank angewendet wird.</param>
        /// <returns>Immer false, da der konkrete Effekt in den abgeleiteten Klassen implementiert wird.</returns>
        public virtual bool useItem(Entity entity)
        {
            Console.WriteLine("Potiontyp unbekannt");
            return false;
        }

        /// <summary>
        /// Erstellt einen neuen Trank mit Name und Inventargröße.
        /// </summary>
        /// <param name="ItemGroesse">Inventargröße des Tranks.</param>
        /// <param name="Name">Anzeigename des Tranks.</param>
        public Potion(int ItemGroesse, string Name)
        {
            this.ItemName = Name;
            this.InventarGroesse = ItemGroesse;
        }
    }
}