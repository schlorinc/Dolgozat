namespace Dolgozat
{
    internal class Program
    {
        static string[] huto = new string[10];

        static void elhelyezes() 
        {
            bool c = false;
            int i = 1;
            Console.Write("Mivel szeretné feltölteni a hűtőt: ");
            do 
            {
                if (huto[i] == null)
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
            return;
        }

        static void KeresEtel(string etelNeve)
        {
            for (int i = 0; i < huto.Length; i++)
            {
                if (huto[i] == etelNeve)
                {
                    Console.WriteLine($"A hűtőben van {etelNeve} (a(z) {i}. helyen)");
                    return;
                }
            }
            Console.WriteLine("A hűtőben nincs " + etelNeve);
            return;
        }

        static void Main(string[] args)
        {
            char valasz;
            
            do {
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
                    KeresEtel(etelNeve);
                }
            }
            while (valasz != 'k');
        }
    }
}
