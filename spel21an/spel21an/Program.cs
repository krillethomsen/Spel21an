using System;

namespace spel21an
{
    class Program
    {
        static void Main(string[] args)
        {
            //Deklarera slumpgenerator och skapa strängen senaste vinnaren.
            Random slump = new Random();
            string senasteVinnaren = "Ingen har vunnit än.";
            Console.WriteLine("Välkommen till 21:an!");
            string menyVal = "0";
            while (menyVal != "4")
            {
                Console.WriteLine("Välj ett alternativ:");
                Console.WriteLine("1: Spela 21:an");
                Console.WriteLine("2: Visa senaste vinnaren");
                Console.WriteLine("3: Spelets regler");
                Console.WriteLine("4: Avsluta programmet");
                menyVal = Console.ReadLine();

                Console.WriteLine();

                switch (menyVal)
                {
                    //spela 21:an
                    case "1":
                        int datornsPoäng = 0;
                        int spelarensPoäng = 0;
                        Console.WriteLine("Nu kommer två kort att dras per spelare");
                        datornsPoäng += slump.Next(1, 11);
                        datornsPoäng += slump.Next(1, 11);
                        spelarensPoäng += slump.Next(1, 11);
                        spelarensPoäng += slump.Next(1, 11);
                        //Låt användaren dra fler kort.
                        string kortVal = "";
                        while (kortVal != "n" && spelarensPoäng <= 21)
                        {
                            Console.WriteLine($"Din poäng: {spelarensPoäng}");
                            Console.WriteLine($"Datorns poäng: {datornsPoäng}");
                            Console.WriteLine("Vill du ha ett kort till? (j/n)");
                            kortVal = Console.ReadLine();

                            switch (kortVal)
                            {
                                case "j":
                                    int nyPoäng = slump.Next(1, 11);
                                    spelarensPoäng += nyPoäng;
                                    Console.WriteLine($"Ditt nya kort är värt: {nyPoäng} poäng.");
                                    Console.WriteLine($"Din totalpoäng är: {spelarensPoäng}");
                                    break;

                                case "n":
                                    while (datornsPoäng < spelarensPoäng && datornsPoäng <= 21)
                                    {
                                        int datornsNyaPoäng = slump.Next(1, 11);
                                        datornsPoäng += datornsNyaPoäng;
                                        Console.WriteLine($"Datorn drog ett kort värt {datornsNyaPoäng}");
                                    }
                                    Console.WriteLine($"Din poäng: {spelarensPoäng}");
                                    Console.WriteLine($"Datorns poäng: {datornsPoäng}");
                                    break;

                                default:
                                    Console.WriteLine("Du valde inte ett giltigt alternativ.");
                                    break;
                            }
                        }
                        //Gå tillbaka till huvudmenyn om användaren får över 21 poäng.
                        if (spelarensPoäng > 21)
                        {
                            Console.WriteLine("Du har mer än 21 poäng och har förlorat.");
                            break;
                        }
                        while(datornsPoäng < spelarensPoäng && datornsPoäng <= 21)
                        {
                            int datornsNyaPoäng = slump.Next(1, 11);
                            datornsPoäng += datornsNyaPoäng;
                            Console.WriteLine($"Datorn drog ett kort värt {datornsNyaPoäng}");
                        }
                        Console.WriteLine($"Din poäng: {spelarensPoäng}");
                        Console.WriteLine($"Datorns poäng: {datornsPoäng}");

                        if (datornsPoäng>21)
                        {
                            Console.WriteLine("Du har vunnit! Grattis!");
                            Console.WriteLine("Skriv ditt namn: ");
                            senasteVinnaren = Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Datorn har vunnit.");
                        }
                        break;
                    //Visa senaste vinnaren
                    case "2":
                        Console.WriteLine($"Senaste vinnaren är {senasteVinnaren}");
                        break;
                    // Visa spelets regler
                    case "3":
                        Console.WriteLine("Ditt mål är att tvinga datorn att få mer än 21 poäng.");
                        Console.WriteLine("Du får poäng genom att dra kort, varje kort har 1-10 poäng.");
                        Console.WriteLine("Om du får mer än 21 poäng har du förlorat.");
                        Console.WriteLine("Både du och datorn får två kort i början. Därefter får du");
                        Console.WriteLine("dra fler kort tills du är nöjd eller får över 21.");
                        Console.WriteLine("När du är färdig drar datorn kort till den har");
                        Console.WriteLine("mer poäng än dig eller över 21 poäng.");
                        break;
                    //Avsluta spelet
                    case "4":
                        break;

                    default:
                        Console.WriteLine("Du valde inget giltigt alternativ.");
                        break;
                }

                Console.WriteLine();

            }

        }
    }
}
