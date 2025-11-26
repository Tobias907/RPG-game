using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RPG_game
{
    internal class Charakter : Entity
    {
        public Inventar inventar { get; }
        private string vorname;
        private string player_tag;
        private int alter;
        private double Damage_Multiplier;
        private double SpecialAttack_damage;
        Random random;
        public double SpecialAttack_Probability;

        public Charakter(string vorname, string player_tag, int alter, int invSize):base(player_tag)
        {
            this.vorname = vorname;
            this.player_tag = player_tag;
            this.alter = alter;
            this.inventar = new Inventar(invSize);
            Attack_damage = 5;
            this.Damage_Multiplier = 5;
            this.SpecialAttack_damage = Attack_damage * Damage_Multiplier;
            urspruenglich_Attack_Damage = Attack_damage;
            this.SpecialAttack_Probability = 5;
            this.random = new Random();
        }
        public string getVorname()
        {
            return this.vorname;
        }
        public string getplayer_tag()
        {
            return this.player_tag;
        }
        public int getAlter()
        {
            return this.alter;
        }
        public double getSpecialAttack_dmg()
        {
            this.SpecialAttack_damage = this.Attack_damage * this.Damage_Multiplier;
            return this.SpecialAttack_damage;
        }
        public bool SpecialAttack()
        {
            double drandom = this.random.Next((int)SpecialAttack_Probability);
            if (drandom == 0)
            {
                return true;
            }
            return false;
        }
        public double getdmg_Multiplier()
        {
            return this.Damage_Multiplier;
        }
        public void setdmg_Multiplier(double Damage_Multiplier)
        {
            this.Damage_Multiplier = Damage_Multiplier;
        }
    }
}