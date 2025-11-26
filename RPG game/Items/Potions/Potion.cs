using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_game
{
    internal class Potion : IInventarItem
    {
        public int InventarGroesse { get; }
        public string ItemName { get; }
        public virtual bool useItem(Entity entity)
        {
            Console.WriteLine("Potiontyp unbekannt");
            return false;
        }
        public Potion(int ItemGroesse, string Name)
        {
            this.ItemName = Name;
            this.InventarGroesse = ItemGroesse;
        }
    }
}