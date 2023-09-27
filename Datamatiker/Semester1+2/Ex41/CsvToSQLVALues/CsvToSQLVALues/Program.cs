using System;
using System.IO;

namespace CsvToSQLVALues
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(@"../../../movies.csv");

            string line = sr.ReadLine();
            string[] splitRow;
            string sqlValueStr;

            while (line != null)
            {
                splitRow = line.Split(";");

                if (splitRow[0] != "Biograf")
                {
                    int Moviedur;
                    string[] splitMovieDur = splitRow[5].Split(":");
                    Moviedur = int.Parse(splitMovieDur[0]) * 60 + int.Parse(splitMovieDur[1]);

                    sqlValueStr = $"('{splitRow[0]}', '{splitRow[1]}', '{DateTime.Parse(splitRow[2]):yyyy-MM-dd HH:mm}', '{splitRow[3]}', '{splitRow[4].TrimEnd()}', '{Moviedur}', '{splitRow[6]}', '{DateTime.Parse(splitRow[7]):yyyy-MM-dd}', '{splitRow[8]}', '{splitRow[9]}'),";

                    Console.WriteLine(sqlValueStr);
                }

                line = sr.ReadLine();
            }

            sr.Close();
        }
    }
}
