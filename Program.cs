using System;
using System.IO;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string strline = "";
            string[] _values = null;
            int x = 0;
            var sum = 0;
            var counter = 0;
            float total = 0;
            float average = 0;
            List<takeTheColums> listOfColumns = new List<takeTheColums>();
            string filePath = @"path_of_the_file\BlackFriday1.csv";

            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    x++;
                    strline = sr.ReadLine();
                    _values = strline.Split(',');

                    if (x >= 2)
                    {
                        listOfColumns.Add(new takeTheColums { ages = _values[3], productsSold = int.Parse(_values[8]), purchases = int.Parse(_values[11]) });
                    }
                }

                sum = findTheSum(sum, listOfColumns);
                Console.WriteLine("The total products are: " + sum);

                findTheAverage(ref counter, ref total, ref average, listOfColumns);
                Console.WriteLine("Finished!");
                Console.ReadKey();
                sr.Close();
            }
        }

        private static void findTheAverage(ref int counter, ref float total, ref float average, List<takeTheColums> listOfColumns)
        {
            for (int z = 0; z < listOfColumns.Count - 1; z++)
            {
                var previousAge = listOfColumns[z].ages;
                float theFirtsElement = listOfColumns[z].purchases;
                total = theFirtsElement;
                counter = 1;
                for (int j = z + 1; j < listOfColumns.Count;)
                {
                    var nextAge = listOfColumns[j].ages;
                    if (previousAge.Equals(nextAge))
                    {
                        counter += 1;
                        total += listOfColumns[j].purchases;
                        listOfColumns.RemoveAt(j);
                    }
                    else { j++; }
                }
                average = total / counter;
                Console.WriteLine("The average of ages between {0} is: {1}", previousAge, average);
            }
        }

        private static int findTheSum(int sum, List<takeTheColums> listOfColumns)
        {
            for (int y = 0; y < listOfColumns.Count; y++)
            {
                sum += listOfColumns[y].productsSold;
            }

            return sum;
        }

        class takeTheColums{
            public string ages;
            public int purchases;
            public int productsSold;
            } 
    }
}
//string filePath = @"path_of_the_file\BlackFriday1.csv";
