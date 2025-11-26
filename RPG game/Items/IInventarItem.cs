using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_game
{
    /// <summary>
    /// Schnittstelle für Items, die im Inventar gespeichert werden können.
    /// </summary>
    internal interface IInventarItem
    {
        /// <summary>
        /// Platzbedarf des Items im Inventar.
        /// </summary>
        int InventarGroesse {  get; }

        /// <summary>
        /// Anzeigename des Items.
        /// </summary>
        string ItemName {  get; }

        /// <summary>
        /// Verwendet das Item auf der angegebenen Entität.
        /// </summary>
        /// <param name="entity">Zielentität, auf die das Item angewendet wird.</param>
        /// <returns>true, wenn das Item erfolgreich verwendet wurde; andernfalls false.</returns>
        bool useItem(Entity entity);
    }
}