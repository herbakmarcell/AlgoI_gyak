using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Keresoalgoritmusok
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //------------------------------------------------
            int elemszam = 10000;
            int[] vektor = RandFeltoltes(elemszam);
            Console.Write("Tömb elemei:\t[ ");
            for (int i = 0; i < vektor.Length - 1; i++)
            {
                Console.Write(vektor[i]+ ", ");
            }
            Console.Write(vektor[vektor.Length-1]+ " ]");


            int t = 6;
            Console.WriteLine("\n\nTulajdonság: {0}",t);

            double msStart = DateTime.Now.Millisecond;
            int[] linEredmeny = LinearisKereses(vektor,elemszam,t);
            double msEnd = DateTime.Now.Millisecond;

            Console.WriteLine("\nFutási idő: {0} ms",msEnd-msStart);

            Console.WriteLine("\n\tPozíció: {0} - Lépésszám: {1}", linEredmeny[0], linEredmeny[1]);


            //------------------------------------------------
            if (false)
            {
                int lefutas = 10000;

                int poziciok = 0;
                int poziciokDB = lefutas;
                int lepesszamok = 0;

                int jelenleg = 0;
                while (jelenleg < lefutas)
                {
                    int[] vektorTemp = RandFeltoltes(elemszam);

                    int[] linEredmenyTemp = LinearisKereses(vektorTemp, elemszam, t);
                    // Thread.Sleep(200);
                    if (linEredmenyTemp[0] == -1)
                    {
                        poziciokDB--;
                        lepesszamok += linEredmenyTemp[1];
                    }
                    else
                    {
                        poziciok += linEredmenyTemp[0];
                        lepesszamok += linEredmenyTemp[1];
                    }
                    jelenleg++;
                    Console.Write(jelenleg);
                }
                double pozAtlag = (double)poziciok / poziciokDB;
                double lepesAtlag = (double)lepesszamok / lefutas;

                Console.WriteLine("\nPozíciók átlaga: {0} - Lépések átlaga: {1}", pozAtlag, lepesAtlag);
            }
            if (true)
            {
                int lefutas = 1000;

                int jelenleg = 0;

                int futasIdok = 0;
                int futasIdokDB = lefutas;
                while (jelenleg < lefutas)
                {
                    int[] vektorTemp = RandFeltoltes(elemszam);
                    int startTemp = DateTime.Now.Millisecond;
                    Thread.Sleep(1);
                    int[] linEredmenyTemp = LinearisKereses(vektorTemp, elemszam, t);
                    int endTemp = DateTime.Now.Millisecond;
                    if ((endTemp - startTemp) <= 0)
                    {
                        futasIdokDB--;
                    }
                    else
                    {
                        futasIdok += (endTemp - startTemp);
                    }
                    Console.WriteLine("{0}. - {1} ms",jelenleg+1, (endTemp - startTemp)/2);
                    jelenleg++;
                }
                Console.WriteLine("\nFutásidők átlaga: {0} ms",((double)futasIdok/lefutas)/2);
            }
            Console.ReadKey();
        }
        public static int[] LinearisKereses(int[] vektor, int elemszam, int tulajdonsag)
        {
            int i = 0;
            int lepesszam = 1;
            int[] visszateres = new int[2];
            while (i < elemszam && vektor[i] != tulajdonsag)
            {
                lepesszam++;
                i++;
            }
            if (i < elemszam)
            {
                visszateres[0] = i + 1;
                visszateres[1] = lepesszam;
                return visszateres;
            }
            visszateres[0] = -1;
            visszateres[1] = lepesszam;
            return visszateres;
        }
        public static int[] RandFeltoltes(int elemszam)
        {
            Random rnd = new Random();
            int[] vektor = new int[elemszam];
            for (int elem = 0; elem < elemszam; elem++)
            {
                vektor[elem] = rnd.Next(1, elemszam + 1);
            }
            Thread.Sleep(1);
            return vektor;
        }
    }
}
