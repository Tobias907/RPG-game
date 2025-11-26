using RPG_game.Items.Potions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RPG_game
{
    /// <summary>
    /// Einstiegspunkt der Anwendung und zentrale Spiellogik (Menü, Kämpfe, Inventar).
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Einstiegspunkt des RPG-Spiels. Initialisiert Spieler und Gegner
        /// und führt die Haupt-Spielschleife mit Menüauswahl aus.
        /// </summary>
        /// <param name="args">Optionale Kommandozeilenargumente (werden nicht verwendet).</param>
        static void Main(string[] args)
        {
            Konsolengroesse();

            string Vorname = "";
            string Player_tag = "";
            string sAlter = "";
            int iAlter = 0;
            string sInventargroesse = "";
            int iInventargroesse = 0;
            bool Konvertiert = false;
            bool Werwolf_tot = false;
            bool Goblin_tot = false;
            bool Elfe_tot = false;
            bool Charakter_tot = false;

            bool SpecialAttack = false;
            string Admin_Passwort = "123";

            //stattdessen:
            Vorname = "Tobi";
            Player_tag = "Tobender50";
            iAlter = 20;
            iInventargroesse = 15;

            Console.WriteLine("Hallo!\nBitte geben Sie nacheinander Vorname, player_tag und Alter ein.");
            Console.Write("Vorname: ");
            Vorname = Console.ReadLine();
            Console.Write("player_tag: ");
            Player_tag = Console.ReadLine();
            do
            {
                Console.Write("Alter: ");
                sAlter = Console.ReadLine();
                Konvertiert = int.TryParse(sAlter, out iAlter);
                if (!Konvertiert)
                {
                    Console.WriteLine("Kein gültiges Alter!");
                }
            } while (!Konvertiert);
            Konvertiert = false;
            do
            {
                Console.Write("Inventargröße festlegen: ");
                sInventargroesse = Console.ReadLine();
                Konvertiert = int.TryParse(sInventargroesse, out iInventargroesse);
                if (!Konvertiert)
                {
                    Console.WriteLine("Keine gültige Inventargröße!");
                }
            } while (!Konvertiert);
            Konvertiert = false;
            Charakter charakter = new Charakter(Vorname, Player_tag, iAlter, iInventargroesse);
            Werwolf werwolf = new Werwolf();
            Goblin goblin = new Goblin();
            Elfe elfe = new Elfe();
            bool playing = true;
            do
            {
                Console.Clear();
                SpecialAttack = false;
                AnfangsText(charakter);
                Console.Write("Eingabe: ");
                ConsoleKeyInfo taste = Console.ReadKey(intercept: true);
                Console.WriteLine();
                switch (taste.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Console.WriteLine();
                        charakter.inventar.displayItems();
                        ENTER();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        if (Goblin_tot)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Der Goblin ist bereits besiegt!");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Zum Bestätigen ENTER drücken...");
                            Console.ReadLine();
                        }
                        else if (Charakter_tot && charakter.getHP() == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Du wurdest besiegt!");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Zum Bestätigen ENTER drücken...");
                            Console.ReadLine();
                        }
                        else
                        {
                            SpecialAttack = charakter.SpecialAttack();
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Deine Leben: " + charakter.getHP() + " / " + charakter.getVollHP());
                            Console.WriteLine("Goblin Leben: " + goblin.getHP() + " / " + goblin.getVollHP());
                            Console.WriteLine();
                            if (SpecialAttack)
                            {
                                Goblin_tot = goblin.getDamage(charakter.getSpecialAttack_dmg());
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("SPEZIALATTACKE x" + charakter.getdmg_Multiplier() + " DAMAGE!!!");
                            }
                            else
                            {
                                Goblin_tot = goblin.getDamage(charakter.getAttack_damage());
                            }
                            Charakter_tot = charakter.getDamage(goblin.getAttack_damage());
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            if (SpecialAttack)
                            { Console.WriteLine("Du hast " + charakter.getSpecialAttack_dmg() + " Schaden gemacht!"); }
                            else
                            { Console.WriteLine("Du hast " + charakter.getAttack_damage() + " Schaden gemacht!"); }
                            Console.WriteLine("Der Goblin hat " + goblin.getAttack_damage() + " Schaden gemacht!");
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Deine Leben: " + charakter.getHP() + " / " + charakter.getVollHP());
                            Console.WriteLine("Goblin Leben: " + goblin.getHP() + " / " + goblin.getVollHP());
                            Console.ForegroundColor = ConsoleColor.White;
                            ENTER();
                        }
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        if (Elfe_tot)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Die Elfe ist bereits besiegt!");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Zum Bestätigen ENTER drücken...");
                            Console.ReadLine();
                        }
                        else if (Charakter_tot && charakter.getHP() == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Du wurdest besiegt!");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Zum Bestätigen ENTER drücken...");
                            Console.ReadLine();
                        }
                        else
                        {
                            SpecialAttack = charakter.SpecialAttack();
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Deine Leben: " + charakter.getHP() + " / " + charakter.getVollHP());
                            Console.WriteLine("Elfe Leben: " + elfe.getHP() + " / " + elfe.getVollHP());
                            Console.WriteLine();
                            if (SpecialAttack)
                            {
                                Elfe_tot = elfe.getDamage(charakter.getSpecialAttack_dmg());
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("SPEZIALATTACKE x" + charakter.getdmg_Multiplier() + " DAMAGE!!!");
                            }
                            else
                            {
                                Elfe_tot = elfe.getDamage(charakter.getAttack_damage());
                            }
                            Charakter_tot = charakter.getDamage(elfe.getAttack_damage());
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            if (SpecialAttack)
                            { Console.WriteLine("Du hast " + charakter.getSpecialAttack_dmg() + " Schaden gemacht!"); }
                            else
                            { Console.WriteLine("Du hast " + charakter.getAttack_damage() + " Schaden gemacht!"); }
                            Console.WriteLine("Der Elfe hat " + elfe.getAttack_damage() + " Schaden gemacht!");
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Deine Leben: " + charakter.getHP() + " / " + charakter.getVollHP());
                            Console.WriteLine("Elfe Leben: " + elfe.getHP() + " / " + elfe.getVollHP());
                            Console.ForegroundColor = ConsoleColor.White;
                            ENTER();
                        }
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        if (Werwolf_tot)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Der Werwolf ist bereits besiegt!");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Zum Bestätigen ENTER drücken...");
                            Console.ReadLine();
                        }
                        else if (Charakter_tot && charakter.getHP() == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Du wurdest besiegt!");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Zum Bestätigen ENTER drücken...");
                            Console.ReadLine();
                        }
                        else
                        {
                            SpecialAttack = charakter.SpecialAttack();
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Deine Leben: " + charakter.getHP() + " / " + charakter.getVollHP());
                            Console.WriteLine("Werwolf Leben: " + werwolf.getHP() + " / " + werwolf.getVollHP());
                            Console.WriteLine();
                            if (SpecialAttack)
                            {
                                Werwolf_tot = werwolf.getDamage(charakter.getSpecialAttack_dmg());
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("SPEZIALATTACKE x" + charakter.getdmg_Multiplier() + " DAMAGE!!!");
                            }
                            else
                            {
                                Werwolf_tot = werwolf.getDamage(charakter.getAttack_damage());
                            }
                            Charakter_tot = charakter.getDamage(werwolf.getAttack_damage());
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            if (SpecialAttack)
                            { Console.WriteLine("Du hast " + charakter.getSpecialAttack_dmg() + " Schaden gemacht!"); }
                            else
                            { Console.WriteLine("Du hast " + charakter.getAttack_damage() + " Schaden gemacht!"); }
                            Console.WriteLine("Der Werwolf hat " + werwolf.getAttack_damage() + " Schaden gemacht!");
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Deine Leben: " + charakter.getHP() + " / " + charakter.getVollHP());
                            Console.WriteLine("Werwolf Leben: " + werwolf.getHP() + " / " + werwolf.getVollHP());
                            Console.ForegroundColor = ConsoleColor.White;
                            ENTER();
                        }
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        Console.Clear();
                        //Überschrift
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Potion verwenden\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        charakter.inventar.displayItems();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nWelche Potion möchtest du verwenden?");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("(1) HealPotion\n(2) PoisonPotion");
                        taste = Console.ReadKey();
                        Console.WriteLine(); Console.WriteLine();
                        switch (taste.Key)
                        {
                            case ConsoleKey.D1:
                            case ConsoleKey.NumPad1:
                                UsePotion(charakter, "HealPotion");
                                break;
                            case ConsoleKey.D2:
                            case ConsoleKey.NumPad2:
                                var ziel = ChooseTarget(goblin, elfe, werwolf);
                                if (ziel != null)
                                    UsePotion(charakter, "PoisonPotion", ziel);  // Ziel-Entity übergeben!
                                break;
                            default:
                                break;
                        }
                        ENTER();
                        break;
                    case ConsoleKey.D9:
                    case ConsoleKey.NumPad9:
                        AdminMenu(Admin_Passwort, charakter);
                        break;
                    case ConsoleKey.Escape:
                        playing = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Das war keine gültige Eingabe!");
                        Console.ForegroundColor = ConsoleColor.White;
                        ENTER();
                        break;
                }
            } while (playing);
        }

        /// <summary>
        /// Öffnet ein Administrationsmenü, in dem Charakterwerte (HP, Max-HP,
        /// Angriffsschaden, Spezial-Multiplikator, Spezialwahrscheinlichkeit)
        /// angepasst und Potions dem Inventar hinzugefügt werden können.
        /// </summary>
        /// <param name="Admin_Passwort">Erwartetes Passwort für den Adminzugriff.</param>
        /// <param name="charakter">Der Charakter, dessen Werte angepasst werden.</param>
        public static void AdminMenu(string Admin_Passwort, Charakter charakter)
        {
            bool PasswortCheck = false;
            bool Konvertiert = false;
            bool menu = true;
            Console.Clear();
            PasswortCheck = PasswordCheck(Admin_Passwort);
            if (PasswortCheck)
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Hallo Tobi!\n");
                    Console.WriteLine("Health Points: " + charakter.getHP() + "\nMax. Health: " + charakter.getVollHP() +
                    "\nAttack damage: " + charakter.getAttack_damage() + "\nMultiplikator (Special Attack): " +
                    charakter.getdmg_Multiplier() + "x\nSpecial Attack damage: " +
                    charakter.getSpecialAttack_dmg() + "\nWahrscheinlichkeit (Special Attack): " + charakter.SpecialAttack_Probability);
                    Console.WriteLine("\n(1) HP anpassen\n(2) voll_HP anpassen\n(3) Attack_dmg anpassen\n(4) dmg_Multi anpassen\n" +
                        "(5) spec_prob anpassen\n(6) Item hinzufügen\n(9) HP auffüllen\n(F1) Admin-Menü verlassen");
                    ConsoleKeyInfo taste2 = Console.ReadKey(intercept: true);
                    Console.WriteLine();
                    Console.Clear();
                    switch (taste2.Key)
                    {
                        case ConsoleKey.D1:
                        case ConsoleKey.NumPad1:
                            Console.Write("HP: ");
                            double dHP = EinlesenUndKonvertieren();
                            if (Konvertiert && dHP <= charakter.getVollHP() && dHP > 0)
                            { charakter.setHP(dHP); }
                            break;
                        case ConsoleKey.D2:
                        case ConsoleKey.NumPad2:

                            Console.Write("voll_HP: ");
                            double dvoll_HP = EinlesenUndKonvertieren();
                            if (Konvertiert && dvoll_HP >= charakter.getHP() && dvoll_HP > 0)
                            { charakter.setVollHP(dvoll_HP); }
                            else if (Konvertiert && dvoll_HP > 0 && dvoll_HP < charakter.getHP())
                            {
                                charakter.setVollHP(dvoll_HP);
                                charakter.setHP(dvoll_HP);
                            }
                            break;
                        case ConsoleKey.D3:
                        case ConsoleKey.NumPad3:
                            Console.Write("Attack_dmg: ");
                            double dAttack_damage = EinlesenUndKonvertieren();
                            if (Konvertiert)
                            { charakter.setAttack_dmg(dAttack_damage); }
                            break;
                        case ConsoleKey.D4:
                        case ConsoleKey.NumPad4:
                            Console.Write("dmg_Multi: ");
                            double dDamage_Multiplier = EinlesenUndKonvertieren();
                            if (Konvertiert)
                            { charakter.setdmg_Multiplier(dDamage_Multiplier); }
                            break;
                        case ConsoleKey.D5:
                        case ConsoleKey.NumPad5:
                            Console.Write("spec_prob: ");
                            double dSpecialAttack_Probability = EinlesenUndKonvertieren();
                            if (Konvertiert)
                            { charakter.SpecialAttack_Probability = dSpecialAttack_Probability; }
                            break;
                        case ConsoleKey.D6:
                        case ConsoleKey.NumPad6:
                            int iPotionLevel = 0;
                            bool Einlagern = false;
                            Konvertiert = false;
                            string sPotionLevel = "";
                            do
                            {
                                Console.WriteLine("Welches Item möchtest du hinzufügen?\n(1) HealPotion\n(2) PoisonPotion");
                                taste2 = Console.ReadKey();
                                Console.WriteLine();
                                switch (taste2.Key)
                                {
                                    case ConsoleKey.D1:
                                    case ConsoleKey.NumPad1:
                                        Console.WriteLine("Wie stark soll die Potion sein?");
                                        do
                                        {
                                            sPotionLevel = Console.ReadLine();
                                            Konvertiert = int.TryParse(sPotionLevel, out iPotionLevel);
                                            if (!Konvertiert)
                                            {
                                                Console.WriteLine("Fehlerhafte Eingabe");
                                            }
                                        } while (!Konvertiert);
                                        Einlagern = charakter.inventar.addItem(new HealPotion(ItemGroesse: iPotionLevel));
                                        if (!Einlagern)
                                        {
                                            Console.WriteLine("Inventar ist voll!");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Erfolgreich!");
                                        }
                                        break;
                                    case ConsoleKey.D2:
                                    case ConsoleKey.NumPad2:
                                        Console.WriteLine("Wie stark soll die Potion sein?");
                                        do
                                        {
                                            sPotionLevel = Console.ReadLine();
                                            Konvertiert = int.TryParse(sPotionLevel, out iPotionLevel);
                                            if (!Konvertiert)
                                            {
                                                Console.WriteLine("Fehlerhafte Eingabe");
                                            }
                                        } while (!Konvertiert);
                                        Einlagern = charakter.inventar.addItem(new PoisonPotion(ItemGroesse: iPotionLevel));
                                        if (!Einlagern)
                                        {
                                            Console.WriteLine("Inventar ist voll!");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Erfolgreich!");
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            } while (!Konvertiert);
                            Konvertiert = false;
                            ENTER();
                            break;
                        case ConsoleKey.D9:
                        case ConsoleKey.NumPad9:
                            charakter.setHP(charakter.getVollHP());
                            break;
                        case ConsoleKey.Escape:
                            menu = false;
                            break;
                        default:
                            break;
                    }
                } while (menu);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Falsches Passwort!");
                Console.ForegroundColor = ConsoleColor.White;
                ENTER();
            }
        }

        /// <summary>
        /// Liest eine Zeile von der Konsole ein und versucht, sie in einen double-Wert umzuwandeln.
        /// </summary>
        /// <returns>Den eingegebenen Wert als double. Bei ungültiger Eingabe ist der Wert 0.</returns>
        public static double EinlesenUndKonvertieren()
        {
            bool Konvertiert = false;
            string Einlesen = Console.ReadLine();
            Konvertiert = double.TryParse(Einlesen, out double WertKonvertiert);
            return WertKonvertiert;
        }

        /// <summary>
        /// Fragt ein Passwort verdeckt (mit Sternchen) in der Konsole ab und vergleicht es
        /// mit dem übergebenen Administrator-Passwort.
        /// </summary>
        /// <param name="adm_password">Passwort, das zum erfolgreichen Login benötigt wird.</param>
        /// <returns>true, wenn das eingegebene Passwort korrekt ist; andernfalls false.</returns>
        public static bool PasswordCheck(string adm_password)
        {
            //von ChatGPT ersteller Code
            Console.Write("Passwort eingeben: ");
            string passwort = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(intercept: true); // intercept = true = nicht anzeigen
                if (key.Key == ConsoleKey.Backspace && passwort.Length > 0)
                {
                    passwort = passwort.Substring(0, passwort.Length - 1);
                    Console.Write("\b \b"); // löscht das letzte *
                }
                else if (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Backspace)
                {
                    passwort += key.KeyChar;
                    Console.Write("*"); // Sternchen anzeigen
                }
            } while (key.Key != ConsoleKey.Enter);
            Console.WriteLine();
            if (passwort == adm_password)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Versucht, die Konsolenfenster- und Buffergröße auf einen sinnvollen Wert
        /// zu setzen, sofern das Betriebssystem und die Umgebung dies zulassen.
        /// </summary>
        public static void Konsolengroesse()
        {
            try
            {
            #if NET5_0_OR_GREATER
                if (!OperatingSystem.IsWindows())
                {
                    Console.WriteLine("Konsole kann nur unter Windows programmgesteuert vergrößert werden.");
                    return;
                }
            #endif

                // Wenn Ausgabe umgeleitet ist (z. B. in Datei/VS-Ausgabefenster), nicht versuchen zu resizen
                if (Console.IsOutputRedirected)
                {
                    Console.WriteLine("Ausgabe ist umgeleitet – Fenstergröße kann nicht gesetzt werden.");
                    return;
                }

                // Optional: Erkennen von Windows Terminal (nicht 100% zuverlässig, aber praktisch)
                bool isWindowsTerminal = Environment.GetEnvironmentVariable("WT_SESSION") != null;
                if (isWindowsTerminal)
                {
                    // In Windows Terminal greifen einige Console-APIs teils nicht.
                    // Weiter versuchen – aber sauber abfangen.
                }

                int curW = Console.WindowWidth;
                int curH = Console.WindowHeight;

                // Vergrößerungsfaktor anpassen
                double factor = 1.5;
                int targetW = (int)Math.Round(curW * factor);
                int targetH = (int)Math.Round(curH * factor);

                // Auf zulässige Maxima clampen
                targetW = Math.Max(1, Math.Min(targetW, Console.LargestWindowWidth));
                targetH = Math.Max(1, Math.Min(targetH, Console.LargestWindowHeight));

                // Reihenfolge je nach Richtung
                bool increasing = targetW > curW || targetH > curH;

                if (increasing)
                {
                    // 1) Buffer >= Ziel
                    int bufW = Math.Max(Console.BufferWidth, targetW);
                    int bufH = Math.Max(Console.BufferHeight, targetH);
                    Console.SetBufferSize(bufW, bufH);

                    // 2) Fenster setzen
                    Console.SetWindowSize(targetW, targetH);
                }
                else
                {
                    // Verkleinern: erst Window, dann Buffer (falls gewünscht)
                    Console.SetWindowSize(targetW, targetH);
                    int bufW = Math.Max(targetW, 1);
                    int bufH = Math.Max(targetH, 1);
                    if (Console.BufferWidth != bufW || Console.BufferHeight != bufH)
                        Console.SetBufferSize(bufW, bufH);
                }

                //Console.WriteLine($"Neu: {Console.WindowWidth} x {Console.WindowHeight} (Zeichen x Zeilen)");
            }
            catch (IOException)
            {
                Console.WriteLine("Konsole konnte nicht vergrößert werden (Terminal/Redirected Output).");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Gewünschte Größe überschreitet die erlaubten Grenzen.");
            }
        }

        /// <summary>
        /// Gibt die aktuellen Werte des Charakters (HP, Schaden, Spezialwerte)
        /// sowie das Hauptmenü mit den möglichen Aktionen aus.
        /// </summary>
        /// <param name="charakter">Der aktuell gesteuerte Charakter.</param>
        public static void AnfangsText(Charakter charakter)
        {
            Console.WriteLine("Playertag: " + charakter.getplayer_tag());
            Console.WriteLine("Alter: " + charakter.getAlter() + "\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Health Points: " + charakter.getHP() + "\nMax. Health: " + charakter.getVollHP() +
                "\nAttack damage: " + charakter.getAttack_damage() + "\nMultiplikator (Special Attack): " +
                charakter.getdmg_Multiplier() + "x\nSpecial Attack damage: " +
                charakter.getSpecialAttack_dmg() + "\nWahrscheinlichkeit (Special Attack): " + charakter.SpecialAttack_Probability);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nWas möchten Sie tun?");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("(1) Inventar anzeigen\n(2) Goblin angreifen\n(3) Elfe angreifen" +
                "\n(4) Werwolf angreifen\n(5) Potion verwenden\n(9) Admin Menü öffnen\n(ESC) Spiel verlassen");
        }

        /// <summary>
        /// Zeigt eine ENTER-Aufforderung an und wartet auf eine Bestätigung per Eingabetaste.
        /// </summary>
        public static void ENTER()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nZum Bestätigen ENTER drücken...");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }

        /// <summary>
        /// Lässt den Spieler ein Ziel (Goblin, Elfe oder Werwolf) auswählen.
        /// </summary>
        /// <param name="goblin">Goblin-Instanz, die als Ziel gewählt werden kann.</param>
        /// <param name="elfe">Elfen-Instanz, die als Ziel gewählt werden kann.</param>
        /// <param name="werwolf">Werwolf-Instanz, die als Ziel gewählt werden kann.</param>
        /// <returns>
        /// Die ausgewählte Ziel-Entität oder null, wenn der Vorgang mit ESC abgebrochen wurde.
        /// </returns>
        static Entity ChooseTarget(Entity goblin, Entity elfe, Entity werwolf)
        {
            while (true)
            {
                Console.WriteLine("Ziel wählen: (1) Goblin  (2) Elfe  (3) Werwolf   (ESC) Abbrechen");
                var k = Console.ReadKey(intercept: true);
                Console.WriteLine();
                switch (k.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1: return goblin;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2: return elfe;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3: return werwolf;
                    case ConsoleKey.Escape: return null;
                }
            }
        }

        /// <summary>
        /// Verwendet eine Potion aus dem Inventar des Charakters.
        /// Je nach Potion-Typ wird entweder der Charakter selbst geheilt
        /// oder ein ausgewählter Gegner beschädigt.
        /// </summary>
        /// <param name="charakter">Charakter, dessen Inventar durchsucht wird.</param>
        /// <param name="itemName">Name des Potion-Typs, der verwendet werden soll.</param>
        /// <param name="targetIfAny">
        /// Optionales Ziel für angreifende Potions (z. B. PoisonPotion). Für Heiltränke kann null übergeben werden.
        /// </param>
        static void UsePotion(Charakter charakter, string itemName, Entity targetIfAny = null)
        {
            var inventar = charakter.inventar.getContainer();

            // Falls dein Container Item-Basisobjekte hält, aber alle Potions von Potion erben:
            var potions = inventar
                .OfType<Potion>()                      // nur Potions
                .Where(p => p.ItemName == itemName)
                .ToList();

            if (potions.Count == 0)
            {
                Console.WriteLine($"Keine {itemName}s vorhanden!");
                return;
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Welche {itemName} möchtest du benutzen?");
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < potions.Count; i++)
                Console.WriteLine($"[{i}] {potions[i].ItemName} - Stärke {potions[i].InventarGroesse}");

            Console.WriteLine();
            int idx;
            while (true)
            {
                Console.Write("Bitte Index eingeben: ");
                if (int.TryParse(Console.ReadLine(), out idx) && idx >= 0 && idx < potions.Count)
                    break;
                Console.WriteLine("Ungültige Eingabe!");
            }

            var potion = potions[idx];

            // Ziel bestimmen:
            // - HealPotion → standardmäßig den Charakter
            // - PoisonPotion → ein Gegner muss angegeben/gewählt sein
            Entity target = targetIfAny;
            if (itemName == "HealPotion")
                target = charakter;                 // heilt den Charakter
            else if (itemName == "PoisonPotion" && target == null)
            {
                Console.WriteLine("Kein Ziel angegeben – wähle ein Ziel:");
                // Hier musst du deine Instanzen übergeben (z. B. goblin/elfe/werwolf)
                // target = ChooseTarget(goblin, elfe, werwolf);   // <- Aufruf an passender Stelle
                // In dieser Methodensignatur haben wir keinen Zugriff – targetIfAny im Switch setzen!
                Console.WriteLine("Abbruch: Ziel fehlt.");
                return;
            }

            // Wirken lassen – die eigentliche Heilung/Verletzung steckt in deiner Potion-Klasse!
            bool used = potion.useItem(target);

            // Wenn useItem erfolgreich war → aus Inventar entfernen
            if (used)
            {
                inventar.Remove(potion);

                // Kleines Feedback
                if (itemName == "HealPotion")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Heilung angewendet. HP: {(target as Charakter)?.getHP()}/{(target as Charakter)?.getVollHP()}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{target.GetType().Name} wurde vergiftet.");
                }
            }
        }
    }
}