using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Evidence
{
    class Program
    {

        static void Main(string[] args)
        {

            DatabazePojistenych databazePojistencu = new DatabazePojistenych();

            while (true)
            {
                Console.WriteLine("------------------------------------");
                Console.WriteLine("Evidence pojištěných");
                Console.WriteLine("------------------------------------");
                Console.WriteLine();
                Console.WriteLine("1 - Přidat nového pojištěného klienta");
                Console.WriteLine("2 - Vypiš celkový záznam všech pojištěných osob");
                Console.WriteLine("3 - Vyhledat konkrétního pojištěného klienta");
                Console.WriteLine("4 - Ukončit aplikaci pojišťovny");
                Console.WriteLine("------------------------------------");
                Console.WriteLine("Jaké číslo možnosti chcete vybrat? ");

                string vybranaMoznostZeSeznamu = Console.ReadLine();
                int celkovySeznamAkci = 0;

                // vybraná možnost ze seznamu musí být čislo
                if (vybranaMoznostZeSeznamu.All(char.IsDigit))
                {
                    celkovySeznamAkci = int.Parse(vybranaMoznostZeSeznamu);
                }

                switch (celkovySeznamAkci)
                {
                    case 1:
                        try
                        {
                            // zadávání osobních informací o pojištěné osobě
                            PojistenaOsoba pojistenaOsoba = new PojistenaOsoba();
                            Console.WriteLine("Zadejte jméno pojištěného klienta:");
                            pojistenaOsoba.JmenoPojistence = Console.ReadLine();
                            if (pojistenaOsoba.JmenoPojistence.Length < 2)
                            {
                                Console.WriteLine("Chyba! Délka jména obsahuje minimálně dva znaky!");
                                break;
                            }
                            Console.WriteLine("Zadejte příjmení pojištěného klienta:");
                            pojistenaOsoba.PrijmeniPojistence = Console.ReadLine();
                            if (pojistenaOsoba.PrijmeniPojistence.Length < 2)
                            {
                                Console.WriteLine("Chyba! Délka příjmení obsahuje minimálně dva znaky!");
                                break;
                            }
                            Console.WriteLine("Zadejte věk pojištěného klienta:");
                            pojistenaOsoba.VekPojistence = int.Parse(Console.ReadLine());

                            Console.WriteLine("Zadejte telefonní číslo pojištěného klienta:");
                            pojistenaOsoba.TelefonPojistence = int.Parse(Console.ReadLine());
                            databazePojistencu.PridejPojistence(pojistenaOsoba);
                        }
                        catch (System.FormatException)
                        {
                            Console.WriteLine("Pojištěná osoba nebyla uložená z důvodu chybně uvedených údajů!");

                        }
                        break;
                    case 2:
                        // jedná se o variantu, která vypíše všechny pojistěné osoby z databáze
                        List<PojistenaOsoba> pojisteni = databazePojistencu.VypisSeznamPojistencu();
                        if (pojisteni.Count == 0)
                        {
                            Console.WriteLine("Nebyla nalezená žádná pojištěná osoba ze seznamu. Vyberte jinou volbu");
                        }
                        else
                        {
                            foreach (PojistenaOsoba pojistenyOs in databazePojistencu.VypisSeznamPojistencu())
                            {
                                Console.WriteLine(pojistenyOs);
                            }
                        }
                        break;
                    case 3:
                        // jedná se o variantu která vyhledá pojištěnou osobu v databázi
                        Console.WriteLine("Zadejte jméno pojištěného:");
                        string jmeno = Console.ReadLine();
                        Console.WriteLine("Zadejte příjmení pojištěného: ");
                        string prijmeni = Console.ReadLine();
                        List<PojistenaOsoba> vyhledani = databazePojistencu.NajdiPojistence(jmeno, prijmeni);
                        if (vyhledani.Count == 0)
                        {
                            Console.WriteLine("Pojištěný nebyl nalezen");
                        }
                        else
                        {
                            foreach (PojistenaOsoba po in vyhledani)
                            {
                                Console.WriteLine(po);
                            }
                        }
                        break;

                    case 4:
                        // ukončení aplikace pojištovny
                        Console.WriteLine("Aplikace pojištovny byla ukončená.Děkujeme za její použití");
                        System.Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Chyba, Opravdu bylo zadané číslo z uvedených možností správné?");
                        break;
                }
                Console.WriteLine("Zadejte prosím libovolnou klávesu a můžete opět pokračovat ve výběru možností ze seznamu");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}   