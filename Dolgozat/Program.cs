namespace Dolgozat
{
    internal class Program
    {
        static Random r = new Random();

        static string[] huto = new string[10];

        static int[] szamok = new int[10];

        static void elhelyezes()
        {
            bool c = false;
            int i = 0;
            Console.Write("Mivel szeretné feltölteni a hűtőt: ");
            do
            {
                if (huto[i] == null || huto[i] == "")
                {
                    huto[i] = Console.ReadLine();
                    c = true;
                }
                else if (i == 10)
                {
                    Console.WriteLine("A hűtő megtelt!");
                    c = true;
                }
                i++;
            }
            while (c == false);
        }

        static void Takarit()
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
                }
                if (huto[i] != null || huto[i] != "")
                {
                    db++;
                }

            }
            huto = seged;
            Console.WriteLine($"{db} élelmiszer van a hűtőben.");
        }

        static int KeresEtel(string etelNeve)
        {
            for (int i = 0; i < huto.Length; i++)
            {
                if (huto[i] == etelNeve)
                {
                    return i;
                }
            }
            return -1;

        }

        static void FeltoltEgyediekkel(int min, int max)
        {
            for (int i = 0; i < huto.Length; i++)
            {
                int szam = r.Next(min, max + 1);
                szamok[i] = szam;
            }
        }

        static void LeghosszabbNovekvo()
        {
            
            int maxHossz = 0;
            int jelenlegiHossz = 1;
            int kezdIndex = 0;
            int vegIndex = 0;
            for (int i = 1; i < szamok.Length; i++)
            {
                if (szamok[i] > szamok[i - 1])
                {
                    jelenlegiHossz++;
                }
                else
                {
                    if (jelenlegiHossz > maxHossz)
                    {
                        maxHossz = jelenlegiHossz;
                        vegIndex = i - 1;
                        kezdIndex = vegIndex - maxHossz + 1;
                    }
                    jelenlegiHossz = 1;
                }
            }
            if (jelenlegiHossz > maxHossz)
            {
                maxHossz = jelenlegiHossz;
                vegIndex = szamok.Length - 1;
                kezdIndex = vegIndex - maxHossz + 1;
            }
            Console.WriteLine("A leghosszabb növekvő sorozat hossza: " + maxHossz);
            
            for (int i = kezdIndex; i <= vegIndex; i++)
            {
                
                Console.Write(szamok[i] + " ");
            }
        }

        static void AtlagAlattiDuplazas()
        {
           int atlag = 0;
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
        }

        static void Main(string[] args)
        {
            char valasz;

            do
            {
                Console.WriteLine();
                Console.Write("Elhelyezés - e\nTakarítás - t\nFeltöltés üres elemekkel - f\nKilépés - k\nKeresés - a\nKérem adja meg, hogy mit szeretne csinálni: ");
                valasz = Convert.ToChar(Console.ReadLine());
                if (valasz == 'e')
                {
                    elhelyezes();
                    for (int i = 0; i < huto.Length; i++)
                    {
                        Console.WriteLine(huto[i]);
                    }
                }
                else if (valasz == 't')
                {
                    Takarit();
                    for (int i = 0; i < huto.Length; i++)
                    {
                        Console.WriteLine(huto[i]);
                    }
                }
                else if (valasz == 'f')
                {
                    for (int i = 0; i < huto.Length; i++)
                    {
                        if (huto[i] == null)
                        {
                            huto[i] = "";
                        }
                    }
                    for (int i = 0; i < huto.Length; i++)
                    {
                        Console.WriteLine(huto[i]);
                    }
                }
                else if (valasz == 'a')
                {
                    Console.Write("Kérem adja meg az étel nevét: ");
                    string etelNeve = Console.ReadLine();
                    int index = KeresEtel(etelNeve);
                    if (index != -1)
                    {
                        Console.WriteLine($"Az étel a hűtőben található, indexe: {index}");
                    }
                    else
                    {
                        Console.WriteLine("Az étel nem található a hűtőben.");
                    }
                }
            }
            while (valasz != 'k');


            FeltoltEgyediekkel(1, 100);
            for (int i = 0; i < szamok.Length; i++)
            {
                Console.Write(szamok[i] + " ");
            }
            LeghosszabbNovekvo();
            AtlagAlattiDuplazas();
            for (int i = 0; i < szamok.Length; i++)
            {
                Console.Write(szamok[i] + " ");
            }
        }
    }
}
