using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RPG_game
{
    /// <summary>
    /// Repräsentiert den spielergesteuerten Charakter mit Inventar, Namen und Spezialattacke.
    /// </summary>
    internal class Charakter : Entity
    {
        /// <summary>
        /// Inventar des Charakters.
        /// </summary>
        public Inventar inventar { get; }

        private string vorname;
        private string player_tag;
        private int alter;
        private double Damage_Multiplier;
        private double SpecialAttack_damage;
        Random random;

        /// <summary>
        /// Wahrscheinlichkeit für eine erfolgreiche Spezialattacke.
        /// Der Wert wird als obere Grenze für Random.Next verwendet (z. B. 5 = Chance 1/5).
        /// </summary>
        public double SpecialAttack_Probability;

        /// <summary>
        /// Erstellt einen neuen Charakter mit Namen, Spieler-Tag, Alter und Inventargröße.
        /// </summary>
        /// <param name="vorname">Vorname des Spielers.</param>
        /// <param name="player_tag">Spieler-Tag des Charakters.</param>
        /// <param name="alter">Alter des Spielers.</param>
        /// <param name="invSize">Maximale Inventargröße.</param>
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

        /// <summary>
        /// Gibt den Vornamen des Charakters zurück.
        /// </summary>
        /// <returns>Vorname des Charakters.</returns>
        public string getVorname()
        {
            return this.vorname;
        }

        /// <summary>
        /// Gibt den Spieler-Tag des Charakters zurück.
        /// </summary>
        /// <returns>Spieler-Tag des Charakters.</returns>
        public string getplayer_tag()
        {
            return this.player_tag;
        }

        /// <summary>
        /// Gibt das Alter des Charakters zurück.
        /// </summary>
        /// <returns>Alter in Jahren.</returns>
        public int getAlter()
        {
            return this.alter;
        }

        /// <summary>
        /// Berechnet den aktuellen Schaden der Spezialattacke.
        /// </summary>
        /// <returns>Schaden der Spezialattacke basierend auf Angriffsschaden und Multiplikator.</returns>
        public double getSpecialAttack_dmg()
        {
            this.SpecialAttack_damage = this.Attack_damage * this.Damage_Multiplier;
            return this.SpecialAttack_damage;
        }

        /// <summary>
        /// Bestimmt zufällig, ob eine Spezialattacke ausgelöst wird.
        /// </summary>
        /// <returns>true, wenn die Spezialattacke ausgelöst wird; andernfalls false.</returns>
        public bool SpecialAttack()
        {
            double drandom = this.random.Next((int)SpecialAttack_Probability);
            if (drandom == 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Gibt den aktuellen Multiplikator für die Spezialattacke zurück.
        /// </summary>
        /// <returns>Multiplikator, mit dem der Angriffsschaden multipliziert wird.</returns>
        public double getdmg_Multiplier()
        {
            return this.Damage_Multiplier;
        }

        /// <summary>
        /// Setzt den Multiplikator für die Spezialattacke.
        /// </summary>
        /// <param name="Damage_Multiplier">Neuer Multiplikator.</param>
        public void setdmg_Multiplier(double Damage_Multiplier)
        {
            this.Damage_Multiplier = Damage_Multiplier;
        }
    }
}