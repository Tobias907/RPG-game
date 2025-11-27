using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_game
{
    /// <summary>
    /// Basisklasse für alle Einheiten im Spiel (Spieler und Gegner) mit Lebenspunkten
    /// und Angriffsschaden.
    /// </summary>
    internal class Entity
    {
        /// <summary>
        /// Anzeigename der Entität, der z. B. in der Konsolenausgabe verwendet wird.
        /// </summary>
        public string Name { get; set; }
        protected double voll_HP;
        protected double urspruenglich_Attack_Damage;
        protected double HP;
        protected double Attack_damage;
        /// <summary>
        /// Erstellt eine neue Entität mit Standardwerten für Lebenspunkte und Angriffsschaden.
        /// </summary>
        /// <param name="_namen">Name der Entität, der angezeigt werden soll.</param>
        public Entity(string _namen)
        {
            Name = _namen;
            HP = 200;
            voll_HP = HP;
            Attack_damage = 3;
            urspruenglich_Attack_Damage = Attack_damage;
        }

        /// <summary>
        /// Gibt die maximalen Lebenspunkte der Entität zurück.
        /// </summary>
        /// <returns>Aktueller Maximalwert der Lebenspunkte.</returns>
        public double getVollHP()
        {
            return this.voll_HP;
        }
        /// <summary>
        /// Setzt den Maximalwert der Lebenspunkte der Entität.
        /// </summary>
        /// <param name="HP">Neuer Maximalwert der Lebenspunkte.</param>
        public void setVollHP(double HP)
        {
            this.voll_HP = HP;
        }
        public double getUrspAttack_dmg()
        {
            return this.urspruenglich_Attack_Damage;
        }

        /// <summary>
        /// Setzt die aktuellen Lebenspunkte der Entität.
        /// </summary>
        /// <param name="current_HP">Neuer Lebenspunktewert.</param>
        public void setHP(double HP)
        {
            this.HP = HP;
        }

        /// <summary>
        /// Gibt die aktuellen Lebenspunkte der Entität zurück.
        /// </summary>
        /// <returns>Aktuelle Lebenspunkte (0 bis voll_HP).</returns>
        public double getHP()
        {
            return this.HP;
        }

        public void setAttack_dmg(double Attack_dmg)
        {
            this.Attack_damage = Attack_dmg;
        }

        /// <summary>
        /// Gibt den aktuellen Angriffsschaden der Entität zurück.
        /// </summary>
        /// <returns>Aktueller Angriffsschaden.</returns>
        public virtual double getAttack_damage()
        {
            return this.Attack_damage;
        }

        /// <summary>
        /// Wendet eingehenden Schaden auf die Entität an.
        /// </summary>
        /// <param name="damage">Höhe des Schadens, der abgezogen werden soll.</param>
        /// <returns>
        /// true, wenn die Lebenspunkte auf 0 fallen (Entität ist besiegt),
        /// andernfalls false.
        /// </returns>
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
        /// <summary>
        /// Heilt die Entität um einen bestimmten Wert.
        /// </summary>
        /// <param name="HP">Höhe der Heilung, die hinzugefügt werden soll.</param>
        /// <returns>
        /// true, wenn Heilung angewendet wurde; false, wenn bereits volle Lebenspunkte
        /// vorhanden sind und daher nichts verändert wurde.
        /// </returns>
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