using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_game.Items.Potions
{
    internal class PoisonPotion : Potion
    {
        double HP;
        public PoisonPotion(int ItemGroesse = 1, string Name = "PoisonPotion", double HP = 10) : base(ItemGroesse, Name)
        {
            this.HP = HP;
        }
        public override bool useItem(Entity entity)
        {
            if (entity == null)
                return false;

            // Optional: Wenn Ziel schon tot ist, nichts verbrauchen
            // Falls du IsAlive nicht hast: benutze getHP() > 0
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