using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_game.Items.Potions
{
    /// <summary>
    /// Schadenspotion, die einer Entität Lebenspunkte entzieht.
    /// </summary>
    internal class PoisonPotion : Potion
    {
        double HP;

        /// <summary>
        /// Erstellt eine neue Giftpotion mit optionaler Stärke und Itemgröße.
        /// </summary>
        /// <param name="ItemGroesse">Inventargröße des Items.</param>
        /// <param name="Name">Anzeigename der Potion.</param>
        /// <param name="HP">Basisschaden pro Einheit der Inventargröße.</param>
        public PoisonPotion(int ItemGroesse = 1, string Name = "PoisonPotion", double HP = 10) : base(ItemGroesse, Name)
        {
            this.HP = HP;
        }

        /// <summary>
        /// Fügt der angegebenen Entität Schaden zu.
        /// </summary>
        /// <param name="entity">Zielentität, die vergiftet werden soll.</param>
        /// <returns>
        /// true, wenn die Potion angewendet wurde; false, wenn kein gültiges Ziel
        /// vorhanden ist (z. B. null oder bereits 0 HP).
        /// </returns>
        public override bool useItem(Entity entity)
        {
            if (entity == null)
                return false;

            // Optional: Wenn Ziel schon tot ist, nichts verbrauchen
            if (entity.getHP() <= 0)
                return false;

            double Damage = HP * InventarGroesse;
            bool targetDied = entity.getDamage(Damage); // Info, aber NICHT der Rückgabewert

            // Hier bewusst IMMER true, weil die Potion angewendet/verbraucht wurde,
            // unabhängig davon, ob das Ziel gestorben ist.
            return true;
        }
    }
}