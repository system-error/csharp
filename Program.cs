using System;
using System.IO;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string filePath = @"path_of_the_file\BlackFriday1.csv";
            using (StreamReader sr = new StreamReader(filePath))
            {
                string strline = "";
                string[] _values = null;
                int x = 0;
                var sum = 0;
                //List<int> listOfProductsSold = new List<int>();
                List<takeTheColums> listOfColumns = new List<takeTheColums>();
                //Dictionary<string, int> listOfAges = new Dictionary<string, int>();
                while (!sr.EndOfStream)
                {
                    x++;
                    strline = sr.ReadLine();
                    _values = strline.Split(',');
                    
                    if (x >= 2)
                    {
                        //listOfProductsSold.Add();
                        listOfColumns.Add(new takeTheColums { ages = _values[3], productsSold = int.Parse(_values[8]), purchases = int.Parse(_values[11]) });     
                    }
                }
                //string gaes = listOfAges[0].ages;

                //Console.WriteLine(gaes);

                for (int y = 0; y<listOfColumns.Count; y++)
                {
                    //Console.WriteLine(listOfColumns[y].productsSold);
                    sum += listOfColumns[y].productsSold;
                }
                /*foreach (int z in listOfColumns[].productsSold)
                {
                    sum += z;
                }*/
                
                Console.WriteLine("The total products are: " + sum);

                //for (int y=0; y<listOfProductsSold.count; y++)
                //{
                //    sum += listOfProductsSold[y];                  works with for loop too  
                //}
                //console.writeline("the total products are: " + sum);

                Console.ReadKey();
                sr.Close();
            }
            //Console.WriteLine(sum);*/
        }
        class takeTheColums{
            public string ages;
            public int purchases;
            public int productsSold;
            }
        
        
    }
}
