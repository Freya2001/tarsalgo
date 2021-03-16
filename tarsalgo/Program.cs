using System;
using System.Collections.Generic;
using System.IO;


namespace tarsalgo
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader ajto = new StreamReader(@"..\..\..\ajto.txt");
            bool readlinesuccesful = true;
            List<int> ora = new List<int>();
            List<int> perc = new List<int>();
            List<int> azon = new List<int>();
            List<string> allapot = new List<string>();
            SortedDictionary<int, int> athaladasok = new SortedDictionary<int, int>();
            while (readlinesuccesful)
            {
                string line = ajto.ReadLine();
                if (line == null)
                {
                    readlinesuccesful = false;
                    break;
                }
                string[] tordeltsor = line.Split(' ');
                ora.Add(Int32.Parse(tordeltsor[0]));
                perc.Add(Int32.Parse(tordeltsor[1]));
                int aktAzon = Int32.Parse(tordeltsor[2]);
                azon.Add(aktAzon);
                allapot.Add(tordeltsor[3]);

                // harmadik feladathoz beolvasas
                if (athaladasok.ContainsKey(aktAzon))
                {
                    athaladasok[aktAzon] ++;
                }
                else
                {
                    athaladasok.Add(aktAzon, 1);
                }
            }
            ajto.Close();
            #region 2.feladat
            Console.WriteLine("2. feladat");
            int utolso = 0;
            for (int i = allapot.Count - 1; i > -1 ; i--)
            {
                if (allapot[i] == "ki")
                {
                    utolso = azon[i];
                    break;
                }
            }
            Console.WriteLine($"Az első belépő: {azon[0]}");
            Console.WriteLine($"Az utolsó kilépő: {utolso}");
            Console.Write('\n');
            #endregion
            #region 3.feladat
            StreamWriter athaladas = new StreamWriter(@"..\..\..\athaladas.txt");
            foreach (var item in athaladasok)
            {
                athaladas.WriteLine(item.Key + " " + item.Value);
            }

            athaladas.Close();
            #endregion
            #region 4.feladat

            #endregion
            #region 5.feladat

            #endregion
            #region 6.feladat

            #endregion
            #region 7.feladat

            #endregion
            #region 8.feladat

            #endregion
        }
    }
}
