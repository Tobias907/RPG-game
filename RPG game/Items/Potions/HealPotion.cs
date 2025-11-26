using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_game
{
    internal class HealPotion : Potion
    {
        double HP;
        public HealPotion(int ItemGroesse = 1, string Name = "HealPotion", double HP = 50) : base(ItemGroesse, Name)
        {
            this.HP = HP;
        }
        public override bool useItem(Entity entity)
        {
            return entity.Heal(HP * InventarGroesse);
        }
    }
}