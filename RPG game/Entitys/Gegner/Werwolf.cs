using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_game
{
    internal class Werwolf : Entity
    {
        public Werwolf(string name = "Werwolf") : base(name)
        {
            HP = 600;
            voll_HP = this.HP;
        }

        public override double getAttack_damage()
        {
            return Attack_damage * 3;
        }
        public new double getHP()
        {
            return HP;
        }
    }
}