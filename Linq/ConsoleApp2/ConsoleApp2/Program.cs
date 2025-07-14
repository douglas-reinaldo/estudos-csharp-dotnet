using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Produto> products = new List<Produto>();
            Console.WriteLine("Enter the file path: ");
            string sourcePath = Console.ReadLine();

            if (File.Exists(sourcePath)) 
            {
                string[] data = File.ReadAllLines(sourcePath);
                foreach (string line in data) 
                {
                    string[] newLine = line.Split(',');
                    string nameProduct = newLine[0];
                    double priceProduct = double.Parse(newLine[1], CultureInfo.InvariantCulture);
                    products.Add(new Produto(nameProduct, priceProduct));
                }

                double averagePrice = products.Average(n => n.Price);
                Console.WriteLine($"Average Price: {averagePrice.ToString("F2", CultureInfo.InvariantCulture)}");

                // Utilizando Method Syntax do Linq
                var newProducts = products.Where(n => n.Price < averagePrice).OrderByDescending(n => n.Name).Select(n => n.Name);



                // Utilizando Query Syntax do Linq
                var newProducts2 = from p in products
                                   where p.Price < averagePrice
                                   orderby p.Name descending
                                   select p.Name;


                foreach (var item in newProducts2)
                {
                    Console.WriteLine(item);
                }
                foreach (var item in newProducts)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
