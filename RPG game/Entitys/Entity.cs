using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_game
{
    internal class Entity
    {
     public string Name { get; set; }
        protected double voll_HP;
        protected double urspruenglich_Attack_Damage;
        protected double HP;
        protected double Attack_damage;

        public Entity(string _namen)
        {
            Name = _namen;
            HP = 200;
            voll_HP = HP;
            Attack_damage = 3;
            urspruenglich_Attack_Damage = Attack_damage;
        }

        public double getVollHP()
        {
            return this.voll_HP;
        }
        public void setVollHP(double HP)
        {
            this.voll_HP = HP;
        }
        public double getUrspAttack_dmg()
        {
            return this.urspruenglich_Attack_Damage;
        }
        
        public void setHP(double HP)
        {
            this.HP = HP;
        }

        public double getHP()
        {
            return this.HP;
        }

        public void setAttack_dmg(double Attack_dmg)
        {
            this.Attack_damage = Attack_dmg;
        }

        public virtual double getAttack_damage()
        {
            return this.Attack_damage;
        }

        public bool getDamage(double damage)
        {
            HP -= damage;
            if (HP <= 0)
            {
                HP = 0;
                return true;
            }
            return false;
        }
        public bool Heal(double HP)
        {
            if (this.HP == voll_HP)
            {
                Console.WriteLine("Du hast bereits volle Lebenspunkte! Die Potion wird nicht verbraucht.\n");
                return false;
            }
            this.HP += HP;
            if (this.HP > voll_HP)
            {
                this.HP = voll_HP;
            }
            return true;
        }
    }
}