namespace Dolgozat
{
    internal class Program
    {
        static Random r = new Random();

        static string[] huto = { "alma", "", "körte", "", "", "sajt", "", "tej", "", "" };

        static int[] szamok = new int[10];

        static void Elhelyezes()
        {
            bool c = false;
            int i = 0;
            int teli = 0;
            Console.Write("\nMivel szeretné feltölteni a hűtőt: ");
            do
            {
                if (huto[i] == null || huto[i] == "")
                {
                    huto[i] = Console.ReadLine();
                    c = true;
                }
                else
                {
                    teli++;
                    if (teli == 10)
                    {
                        Console.WriteLine("\nA hűtő megtelt!");
                        c = true;
                    }
                }
                i++;
            }
            while (c == false);
        }

        static int Takarit()
        {
            string[] seged = new string[10];
            int j = 0;
            int db = 0;
            for (int i = 0; i < huto.Length; i++)
            {
                if (huto[i] != "")
                {
                    seged[j] = huto[i];
                    j++;
                    db++;
                }
            }
            huto = seged;
            return db;
        }

        static int KeresEtel(string etelNeve)
        {
            for (int i = 0; i < huto.Length; i++)
            {
                if (huto[i] == etelNeve)
                {
                    return i + 1;
                }
            }
            return 0;
        }

        static void MaganhangzovalKezd()
        {
            Console.WriteLine();
            for (int i = 0; i < huto.Length; i++)
            {
                if (huto[i] != null && huto[i] != "")
                {
                    char elsoBetu = huto[i][0];
                    if ("aeiouáéíóöőúüű".Contains(elsoBetu))
                    {
                        Console.WriteLine(huto[i]);
                    }
                }
            }
        }


        static void FeltoltEgyediekkel(int min, int max)
        {
            Console.WriteLine("------------------------------------------------------");
            for (int i = 0; i < szamok.Length; i++)
            {
                int szam;
                do
                {
                    szam = r.Next(min, max + 1);
                }
                while (szamok.Contains(szam));

                szamok[i] = szam;
            }
        }

        static int[] LeghosszabbNovekvo()
        {
            int maxHossz = 1;
            int jelenlegiHossz = 1;
            int kezdIndex = 0;
            int maxKezdIndex = 0;

            for (int i = 1; i < szamok.Length; i++)
            {
                if (szamok[i] > szamok[i - 1])
                {
                    jelenlegiHossz++;
                }
                else
                {
                    jelenlegiHossz = 1;
                    kezdIndex = i;
                }

                if (jelenlegiHossz > maxHossz)
                {
                    maxHossz = jelenlegiHossz;
                    maxKezdIndex = kezdIndex;
                }
            }

            int[] eredmeny = new int[maxHossz];

            for (int i = 0; i < maxHossz; i++)
            {
                eredmeny[i] = szamok[maxKezdIndex + i];
            }

            return eredmeny;
        }

        static void AtlagAlattiDuplazas()
        {
            Console.WriteLine();
            double atlag = 0;
            for (int i = 0; i < szamok.Length; i++)
            {
                atlag += szamok[i];
            }
            atlag /= szamok.Length;
            for (int i = 0; i < szamok.Length; i++)
            {
                if (szamok[i] < atlag)
                {
                    szamok[i] *= 2;
                }
            }

            for (int i = 0; i < szamok.Length; i++)
            {
                Console.Write(szamok[i] + "\n");
            }
        }

        static void Main(string[] args)
        {
            char valasz;

            do
            {
                Console.WriteLine();
                Console.Write("Elhelyezés - e\nTakarítás - t\nKilépés - k\nKeresés - a\nMagánhangzóval kezdődő élelmiszerek - m\nKérem adja meg, hogy mit szeretne csinálni: ");
                valasz = Convert.ToChar(Console.ReadLine());
                if (valasz == 'e')
                {
                    Elhelyezes();
                    for (int i = 0; i < huto.Length; i++)
                    {
                        Console.WriteLine(huto[i]);
                    }
                }
                else if (valasz == 't')
                {
                    int db = Takarit();
                    Console.WriteLine($"\nA hűtőben {db} élelmiszer található!");
                    for (int i = 0; i < huto.Length; i++)
                    {
                        Console.WriteLine(huto[i]);
                    }
                }
                else if (valasz == 'a')
                {
                    Console.Write("\nKérem adja meg az étel nevét: ");
                    string etelNeve = Console.ReadLine();
                    int index = KeresEtel(etelNeve);
                    if (index != 0)
                    {
                        Console.WriteLine($"Az étel a hűtőben található, indexe: {index}");
                    }
                    else
                    {
                        Console.WriteLine("\nAz étel nem található a hűtőben.");
                    }
                }
                else if (valasz == 'm')
                {
                    MaganhangzovalKezd();
                }
            }
            while (valasz != 'k');


            FeltoltEgyediekkel(1, 100);
            for (int i = 0; i < szamok.Length; i++)
            {
                Console.Write(szamok[i] + "\n");
            }
            int[] novekvo = LeghosszabbNovekvo();

            Console.WriteLine();
            Console.WriteLine("Leghosszabb növekvő sorozat:");

            for (int i = 0; i < novekvo.Length; i++)
            {
                Console.Write(novekvo[i] + " ");
            }
            Console.WriteLine();
            AtlagAlattiDuplazas();
        }
    }
}
