using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_game
{
    internal class Inventar
    {
        private int maxInventarGroesse;
        private List<IInventarItem> container;
        private int currentInventarPlatz;

        public Inventar(int groesse = 24)
        {
            this.maxInventarGroesse = groesse;
            this.container = new List<IInventarItem>();
        }
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
        public IInventarItem getItem(int index)
        {
            return container[index];
        }
        public void deleteItem(int index)
        {
            container.RemoveAt(index);
        }
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
        public List<IInventarItem> getContainer()
        {
            return container;
        }
    }
}