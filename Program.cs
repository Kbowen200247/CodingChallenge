using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace CodingChallenge
{
    class Program
    {

        static void Main(string[] args)
        {

            string lines = File.ReadAllText(@"C:\\test.csv");
            
           
            var rows = lines.Count();
            

            Console.WriteLine("Total number of records = " + (rows-1));
            Console.WriteLine();
            TotalColumns(lines);
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        static void TotalColumns(IEnumerable<string> nums)
        {
            Console.WriteLine("Total Column Query:");

            IEnumerable<IEnumerable<int>> totalColQuery = from line in nums
                                                          let elements = line.Split(',')
                                                          let total = elements.Skip(0)
                                                          select (from str in total
                                                                  select Convert.ToInt32(str));

            var results = totalColQuery.ToList();

            int columnCount = results[0].Count();

            for (int column = 0; column < columnCount; column++)
            {
                var results2 = from row in results
                               select row.ElementAt(column);
                double sum = results2.Sum();

                Console.WriteLine("Record Row #{0} Total Sum: {1:###.##}", column + 1, sum);
            }
        }
    }
}
