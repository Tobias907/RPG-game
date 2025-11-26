using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_game
{
    /// <summary>
    /// Heiltrank, der Lebenspunkte einer Entität wiederherstellt.
    /// </summary>
    internal class HealPotion : Potion
    {
        double HP;

        /// <summary>
        /// Erstellt eine neue Heilpotion mit optionaler Stärke und Itemgröße.
        /// </summary>
        /// <param name="ItemGroesse">Inventargröße des Items.</param>
        /// <param name="Name">Anzeigename der Potion.</param>
        /// <param name="HP">Heilwert pro Einheit der Inventargröße.</param>
        public HealPotion(int ItemGroesse = 1, string Name = "HealPotion", double HP = 50) : base(ItemGroesse, Name)
        {
            this.HP = HP;
        }

        /// <summary>
        /// Heilt die angegebene Entität um den konfigurierten Heilwert.
        /// </summary>
        /// <param name="entity">Entität, die geheilt werden soll.</param>
        /// <returns>
        /// true, wenn Heilung angewendet wurde; false, wenn bereits volle Lebenspunkte vorhanden sind.
        /// </returns>
        public override bool useItem(Entity entity)
        {
            return entity.Heal(HP * InventarGroesse);
        }
    }
}