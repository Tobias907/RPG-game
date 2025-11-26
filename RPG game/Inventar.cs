using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_game
{
    /// <summary>
    /// Repräsentiert das Inventar eines Charakters und verwaltet die abgelegten Items.
    /// </summary>
    internal class Inventar
    {
        private int maxInventarGroesse;
        private List<IInventarItem> container;
        private int currentInventarPlatz;

        /// <summary>
        /// Erstellt ein neues Inventar mit einer optionalen Maximalgröße.
        /// </summary>
        /// <param name="groesse">Maximale Inventargröße in Slots.</param>
        public Inventar(int groesse = 24)
        {
            this.maxInventarGroesse = groesse;
            this.container = new List<IInventarItem>();
        }
        /// <summary>
        /// Fügt ein Item zum Inventar hinzu, sofern noch genug Platz vorhanden ist.
        /// </summary>
        /// <param name="item">Item, das eingelagert werden soll.</param>
        /// <returns>true, wenn das Item erfolgreich hinzugefügt wurde; andernfalls false.</returns>
        public bool addItem(IInventarItem item)
        {
            if ((currentInventarPlatz + item.InventarGroesse) > maxInventarGroesse)
            {
                return false; //Exception
            }
            currentInventarPlatz += item.InventarGroesse;
            container.Add(item);
            return true;
        }
        /// <summary>
        /// Gibt ein Item an einem bestimmten Index im Inventar zurück.
        /// </summary>
        /// <param name="index">Index des gewünschten Items.</param>
        /// <returns>Das Item am angegebenen Index.</returns>
        public IInventarItem getItem(int index)
        {
            return container[index];
        }
        /// <summary>
        /// Entfernt ein Item an einem bestimmten Index aus dem Inventar.
        /// </summary>
        /// <param name="index">Index des Items, das entfernt werden soll.</param>
        public void deleteItem(int index)
        {
            container.RemoveAt(index);
        }
        /// <summary>
        /// Gibt den aktuellen Inhalt des Inventars formatiert in der Konsole aus.
        /// </summary>
        public void displayItems()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Dein Inventar ({currentInventarPlatz}/{maxInventarGroesse}) :");
            Console.ForegroundColor = ConsoleColor.White;
            int counter = 0;
            foreach (IInventarItem item in container)
            {
                Console.Write($"[{counter++}] {item.ItemName} - {item.InventarGroesse}");
                if (container.Last() == item)
                {
                    Console.WriteLine();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" | ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
        /// <summary>
        /// Gibt die interne Liste aller Inventar-Items zurück.
        /// </summary>
        /// <returns>Liste mit allen Items im Inventar.</returns>
        public List<IInventarItem> getContainer()
        {
            return container;
        }
    }
}