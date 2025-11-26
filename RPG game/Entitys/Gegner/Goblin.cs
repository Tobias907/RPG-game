using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_game
{
    internal class Goblin : Entity
    {
        public Goblin(string name = "Goblin") :base(name)
        {
            voll_HP = this.HP;
        }
    }
}