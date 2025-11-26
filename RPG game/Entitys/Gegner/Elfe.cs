using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_game
{
    internal class Elfe : Entity
    {
        public Elfe(string name = "Elfe"): base(name)
        {
            //Name = "Elfe";
            HP = 400;
            voll_HP = this.HP;
        }
        public new double getHP()
        {
            return HP;
        }
    }
}