using System;
using System.Threading;

namespace RendezoAlgoritmusok
{
    internal class Program
    {
        static int[] TombFeltoltes(int elemszam)
        {
            int[] szamok = new int[elemszam];
            Random rnd = new Random();
            for (int i = 0; i < szamok.Length; i++)
            {
                szamok[i] = rnd.Next(1, elemszam + 1);
            }
            return szamok;
        }
        static int[] BeszuroRendezes(int[] szamok)
        {
            int[] rendezett = new int[szamok.Length];
            szamok.CopyTo(rendezett, 0);

            for (int i = 1; i < rendezett.Length; i++)
            {
                int kulcs = rendezett[i];
                int j = i - 1;
                while (j >= 0 && kulcs < rendezett[j])
                {
                    rendezett[j + 1] = rendezett[j];
                    j -= 1;
                }
                rendezett[j + 1] = kulcs;
            }
            return rendezett;
        }
        static int[] BeszuroRendezesAdatok(int[] szamok)
        {
            int[] rendezett = new int[szamok.Length];
            szamok.CopyTo(rendezett, 0);

            int[] adatok = new int[2];
            int lepesek = 0;
            int cserek = 0;

            for (int i = 1; i < rendezett.Length; i++)
            {
                int kulcs = rendezett[i];
                int j = i - 1;
                while (j >= 0 && rendezett[j] > kulcs)
                {
                    rendezett[j + 1] = rendezett[j];
                    lepesek++;
                    cserek++;
                    j--;
                }
                rendezett[j + 1] = kulcs;
                cserek++;
            }
            adatok[0] = lepesek;
            adatok[1] = cserek;

            return adatok;
        }

        static int[] MinKivalasztasosRendezes(int[] szamok)
        {
            int[] rendezett = new int[szamok.Length];
            szamok.CopyTo(rendezett, 0);

            for (int i = 0; i < rendezett.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < rendezett.Length; j++)
                {
                    if (rendezett[j] < rendezett[minIndex])
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    int temp = rendezett[i];
                    rendezett[i] = rendezett[minIndex];
                    rendezett[minIndex] = temp;
                }
            }
            return rendezett;
        }

        static int[] MinKivalasztasosRendezesAdatok(int[] szamok)
        {
            int[] rendezett = new int[szamok.Length];
            szamok.CopyTo(rendezett, 0);

            int[] adatok = new int[2];
            int cserek = 0;
            int lepesek = 0;

            for (int i = 0; i < rendezett.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < rendezett.Length; j++)
                {
                    lepesek++;
                    if (rendezett[j] < rendezett[minIndex])
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    int temp = rendezett[i];
                    rendezett[i] = rendezett[minIndex];
                    rendezett[minIndex] = temp;
                    cserek++;
                }
            }
            adatok[0] = lepesek;
            adatok[1] = cserek;
            return adatok;
        }

        static int[] BuborekRendezes(int[] szamok)
        {
            int[] rendezett = new int[szamok.Length];
            szamok.CopyTo(rendezett, 0);

            for (int j = 0; j < rendezett.Length; j++)
            {
                for (int i = 0; i < rendezett.Length - j - 1; i++)
                {
                    if (rendezett[i] > rendezett[i + 1])
                    {
                        int temp = rendezett[i];
                        rendezett[i] = rendezett[i + 1];
                        rendezett[i + 1] = temp;
                    }
                }
            }

            return rendezett;
        }

        static int[] BuborekRendezesAdatok(int[] szamok)
        {
            int[] rendezett = new int[szamok.Length];
            szamok.CopyTo(rendezett, 0);

            int[] adatok = new int[2];
            int lepesek = 0;
            int cserek = 0;

            for (int j = 0; j < rendezett.Length; j++)
            {
                for (int i = 0; i < rendezett.Length - j - 1; i++)
                {
                    lepesek++;
                    if (rendezett[i] > rendezett[i + 1])
                    {
                        cserek++;
                        int temp = rendezett[i];
                        rendezett[i] = rendezett[i + 1];
                        rendezett[i + 1] = temp;
                    }
                }
            }

            adatok[0] = lepesek;
            adatok[1] = cserek;
            return adatok;
        }

        static int[] BuborekRendezesJav1(int[] szamok)
        {
            int[] rendezett = new int[szamok.Length];
            szamok.CopyTo(rendezett, 0);

            for (int j = 0; j < rendezett.Length - 1; j++)
            {
                bool voltE = false;
                int i = 0;

                while (i < rendezett.Length - j - 1 && !voltE)
                {
                    if (rendezett[i] > rendezett[i + 1])
                    {
                        voltE = true;
                        int temp = rendezett[i];
                        rendezett[i] = rendezett[i + 1];
                        rendezett[i + 1] = temp;
                    }
                    i++;
                }

                if (!voltE)
                {
                    return rendezett;
                }
            }
            return rendezett;
        }

        static int[] BuborekRendezesJav1Adatok(int[] szamok)
        {
            int[] rendezett = new int[szamok.Length];
            szamok.CopyTo(rendezett, 0);

            int[] adatok = new int[2];

            int lepesek = 0;
            int cserek = 0;

            for (int j = 0; j < rendezett.Length - 1; j++)
            {
                bool voltE = false;
                int i = 0;

                while (i < rendezett.Length - j - 1 && !voltE)
                {
                    lepesek++;

                    if (rendezett[i] > rendezett[i + 1])
                    {
                        voltE = true;
                        cserek++;
                        int temp = rendezett[i];
                        rendezett[i] = rendezett[i + 1];
                        rendezett[i + 1] = temp;
                    }
                    i++;
                }
                if (!voltE)
                {
                    adatok[0] = lepesek;
                    adatok[1] = cserek;
                    return adatok;
                }
            }
            adatok[0] = lepesek;
            adatok[1] = cserek;
            return adatok;
        }

        static int[] BuborekRendezesJav2(int[] szamok)
        {
            int[] rendezett = new int[szamok.Length];
            szamok.CopyTo(rendezett, 0);

            int hossz = rendezett.Length;
            int n = hossz;
            int j = 1;
            int utolsoCsereH = 0;

            while (j <= hossz - 1)
            {
                utolsoCsereH = 0;
                for (int i = 0; i < n - j; i++)
                {
                    if (rendezett[i] > rendezett[i + 1])
                    {
                        int temp = rendezett[i];
                        rendezett[i] = rendezett[i + 1];
                        rendezett[i + 1] = temp;
                        utolsoCsereH = i;
                    }
                }
                j = n - utolsoCsereH;
            }
            return rendezett;
        }
        static int[] BuborekRendezesJav2Adatok(int[] szamok)
        {
            int[] rendezett = new int[szamok.Length];
            szamok.CopyTo(rendezett, 0);

            int hossz = rendezett.Length;
            int n = hossz;
            int j = 1;
            int utolsoCsereH = 0;

            int[] adatok = new int[2];

            int lepesek = 0;
            int cserek = 0;

            while (j <= hossz - 1)
            {
                utolsoCsereH = 0;
                lepesek++;
                for (int i = 0; i < n - j; i++)
                {
                    if (rendezett[i] > rendezett[i + 1])
                    {
                        cserek++;
                        int temp = rendezett[i];
                        rendezett[i] = rendezett[i + 1];
                        rendezett[i + 1] = temp;
                        utolsoCsereH = i;
                    }
                }
                j = n - utolsoCsereH;
            }
            adatok[0] = lepesek;
            adatok[1] = cserek;
            return adatok;
        }

        static int[] KoktelRendezes(int[] szamok)
        {
            int[] rendezett = new int[szamok.Length];
            szamok.CopyTo(rendezett, 0);

            int hossz = rendezett.Length;
            int start = 0;
            int veg = hossz - 1;

            for (int j = 0; j < hossz; j++)
            {
                for (int i = start; i < veg; i++)
                {
                    if (rendezett[i] > rendezett[i + 1])
                    {
                        int temp = rendezett[i];
                        rendezett[i] = rendezett[i + 1];
                        rendezett[i + 1] = temp;
                    }
                }
                veg = veg - 1;

                for (int i = veg; i > start; i--)
                {
                    if (rendezett[i] < rendezett[i - 1])
                    {
                        int temp = rendezett[i];
                        rendezett[i] = rendezett[i - 1];
                        rendezett[i - 1] = temp;
                    }
                }
                start = start + 1;
            }
            return rendezett;
        }

        static int[] KoktelRendezesAdatok(int[] szamok)
        {
            int[] rendezett = new int[szamok.Length];
            szamok.CopyTo(rendezett, 0);

            int hossz = rendezett.Length;
            int start = 0;
            int veg = hossz - 1;

            int[] adatok = new int[2];
            int lepesek = 0;
            int cserek = 0;

            for (int j = 0; j < hossz; j++)
            {
                for (int i = start; i < veg; i++)
                {
                    lepesek++;
                    if (rendezett[i] > rendezett[i + 1])
                    {
                        cserek++;
                        int temp = rendezett[i];
                        rendezett[i] = rendezett[i + 1];
                        rendezett[i + 1] = temp;
                    }
                }
                veg = veg - 1;

                for (int i = veg; i > start; i--)
                {
                    lepesek++;
                    if (rendezett[i] < rendezett[i - 1])
                    {
                        cserek++;
                        int temp = rendezett[i];
                        rendezett[i] = rendezett[i - 1];
                        rendezett[i - 1] = temp;
                    }
                }
                start = start + 1;
            }
            adatok[0] = lepesek;
            adatok[1] = cserek;
            return adatok;
        }


        //------------------------
        static int elemszam = 50000;
        static int lefutas = 100;
        //------------------------
        static void Main(string[] args)
        {

            // Tömb feltöltése
            int[] rendezetlen = TombFeltoltes(elemszam);
            Console.Write("Alap: ");
            foreach (int szam in rendezetlen)
            {
                Console.Write(szam + " ");
            }
            Console.Write("\nRendezett: ");

            int[] rendezett = BeszuroRendezes(rendezetlen);
            foreach (int szam in rendezett)
            {
                Console.Write(szam + " ");
            }
            Console.WriteLine("\n\nAdatok: ");

            int[] adatok = new int[2];
            double[] atlagAdatok = new double[2];

            Console.WriteLine("\nBeszúró rendezés: ");
            adatok = BeszuroRendezesAdatok(rendezetlen);
            Console.WriteLine("Lépések száma: " + adatok[0]);
            Console.WriteLine("Cserék száma: " + adatok[1]);

            Console.WriteLine("\nMinimumkiválasztásos rendezés: ");
            adatok = MinKivalasztasosRendezesAdatok(rendezetlen);
            Console.WriteLine("Lépések száma: " + adatok[0]);
            Console.WriteLine("Cserék száma: " + adatok[1]);

            Console.WriteLine("\nBuborékrendezés: ");
            adatok = BuborekRendezesAdatok(rendezetlen);
            Console.WriteLine("Lépések száma: " + adatok[0]);
            Console.WriteLine("Cserék száma: " + adatok[1]);

            Console.WriteLine("\nJavított Buborékrendezés: ");
            adatok = BuborekRendezesJav1Adatok(rendezetlen);
            Console.WriteLine("Lépések száma: " + adatok[0]);
            Console.WriteLine("Cserék száma: " + adatok[1]);

            Console.WriteLine("\nMásodik Javított Buborékrendezés: ");
            adatok = BuborekRendezesJav2Adatok(rendezetlen);
            Console.WriteLine("Lépések száma: " + adatok[0]);
            Console.WriteLine("Cserék száma: " + adatok[1]);

            Console.WriteLine("\nKoktélrendezés: ");
            adatok = KoktelRendezesAdatok(rendezetlen);
            Console.WriteLine("Lépések száma: " + adatok[0]);
            Console.WriteLine("Cserék száma: " + adatok[1]);

            atlagAdatok = AtlagAdatok(elemszam, lefutas);
            Console.WriteLine(atlagAdatok[0] + " " + atlagAdatok[1]);

            Console.ReadKey();
        }
        static double[] AtlagAdatok(int elemszam, int lefutas)
        {
            double atlagLepes = 0;
            double atlagCsere = 0;
            double[] atlagAdatok = new double[2];
            for (int i = 0; i < lefutas; i++)
            {
                int[] rendezetlen = TombFeltoltes(elemszam);
                // Néha kell, néha nem xd
                Thread.Sleep(1);
                int[] adatok = KoktelRendezesAdatok(rendezetlen);
                // Console.WriteLine(adatok[0] + " " + adatok[1]);
                atlagLepes += adatok[0];
                atlagCsere += adatok[1];
            }


            atlagAdatok[0] = atlagLepes / (double)lefutas;
            atlagAdatok[1] = atlagCsere / (double)lefutas;
            return atlagAdatok;
        }
    }
}
