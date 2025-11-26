using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_game
{
    internal interface IInventarItem
    {
        int InventarGroesse {  get; }
        string ItemName {  get; }
        bool useItem(Entity entity);
    }
}