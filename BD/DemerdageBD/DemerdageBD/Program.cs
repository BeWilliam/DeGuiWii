using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DemerdageBD
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            //Pour importer les users
            StreamReader sr = new StreamReader(@"C:\Users\Guillaume\OneDrive - Cégep de La Pocatière\Documents\Test.txt", Encoding.UTF8);

            while (!sr.EndOfStream)
            {
                string[] champs = new string[17];
                string line = sr.ReadLine();
                champs = line.Split(',');

                StreamWriter sw = new StreamWriter(@"C:\Users\Guillaume\OneDrive - Cégep de La Pocatière\Documents\output.txt", true);

                int idChampCourriel = 14;
                Console.Clear();
                Console.WriteLine("12 : " + champs[12] + " - 13: " + champs[13] + " - 14: " + champs[14] + " - 15: " + champs[15]);
                idChampCourriel = int.Parse(Console.ReadLine());

                sw.WriteLine("(" + champs[1] + ", " + champs[2] + ", 1, " + champs[idChampCourriel] + ", 1),");
                sw.Close();
                sw.Dispose();

            }
            sr.Close();
            sr.Dispose();
            Console.ReadKey();
            */

            /*
            StreamReader sr = new StreamReader(@"C:\Users\Guillaume\OneDrive - Cégep de La Pocatière\Documents\Test.txt", Encoding.UTF8);
            
            while (!sr.EndOfStream)
            {
                string[] champs = new string[100];
                string line = sr.ReadLine();
                champs = line.Split(',');
                StreamWriter sw = new StreamWriter(@"C:\Users\Guillaume\OneDrive - Cégep de La Pocatière\Documents\output.txt", true);

                Console.WriteLine(champs[0]);

                sw.WriteLine(champs[0] + ", " + champs[2] + ", " + champs[3] + ", " + champs[10] + ", " + champs[11] + ", 1),");

                sw.Close();
                sw.Dispose();
            }
            sr.Close();
            sr.Dispose();
            Console.ReadKey();*/


            StreamReader sr = new StreamReader(@"C:\Users\Guillaume\OneDrive - Cégep de La Pocatière\Documents\Test.txt", Encoding.UTF8);

            while (!sr.EndOfStream)
            {
                string[] champs = new string[100];
                string line = sr.ReadLine();
                champs = line.Split(',');

                StreamWriter sw = new StreamWriter(@"C:\Users\Guillaume\OneDrive - Cégep de La Pocatière\Documents\output.txt", true);

                sw.WriteLine(champs[0] + ", " + champs[1] + ", " + champs[3] + ", 1),");

                sw.Close();
                sw.Dispose();
            }
            sr.Close();
            sr.Dispose();
            Console.ReadKey();
        }
    }
}
