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
            List<int> bentlev = new List<int>();
            SortedDictionary<int, int> athaladasok = new SortedDictionary<int, int>();
            int letszam = 0;
            int osszperc = 0;
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

                // 5. feladathoz kell
                if (tordeltsor[3] == "be")
                {
                    letszam += 1;
                    bentlev.Add(letszam);
                }
                else
                {
                    letszam -= 1;
                    bentlev.Add(letszam);
                }

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
            Console.WriteLine("4. feladat");
            string bentmaradtak = "";
            foreach (var item in athaladasok)
            {
                if (item.Value % 2 != 0)
                {
                    bentmaradtak += item.Key + " ";
                }

            }

            Console.WriteLine($"A végén a társalgóban voltak: {bentmaradtak}");
            Console.Write('\n');
            #endregion
            #region 5.feladat
            Console.WriteLine("5. feladat");
            int maxbentindex = 0;
            for (int i = 1; i < bentlev.Count; i++)
            {
                if (bentlev[i] > bentlev[maxbentindex])
                {
                    maxbentindex = i;
                }
            }
            Console.WriteLine($"{ora[maxbentindex]}:{perc[maxbentindex]}-kor voltak a legtöbben a társalgóban.");
            Console.Write('\n');
            #endregion
            #region 6.feladat
            Console.WriteLine("6. feladat");
            Console.Write("Adja meg a személy azonosítóját! ");
            int adottazon = Int32.Parse(Console.ReadLine());
            Console.Write('\n');
            #endregion
            #region 7.feladat
            Console.WriteLine("7. feladat");
            
            int bementora = 0;
            int bementperc = 0;
            for (int i = 0; i < azon.Count; i++)
            {
                if (azon[i] == adottazon)
                {
                    if (allapot[i] == "be")
                    {
                        Console.Write(ora[i] + ":" + perc[i] + "-");
                        bementora = ora[i]*60;
                        bementperc = perc[i];
                    }
                    else
                    {
                        Console.Write(ora[i] + ":" + perc[i] + '\n');
                        osszperc += ora[i] * 60 - bementora + perc[i] - bementperc;
                        bementora = 0;
                    }

                }
            }
            Console.Write('\n');
            #endregion
            #region 8.feladat
            Console.WriteLine("8. feladat");
            string helyzet = "nem volt a társalgóban";
            if (bementora != 0)
            {
                helyzet = "a társalgóban volt";
                osszperc += 15 * 60 - bementora - bementperc;
            }
            Console.WriteLine($"A(z) {adottazon}. személy összesen {osszperc} percet volt bent, a megfigyelés végén {helyzet}.");
            #endregion
        }
    }
}
