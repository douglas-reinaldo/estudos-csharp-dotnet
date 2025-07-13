using System;
using System.Linq;
using ConsoleApp1.Entities;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ConsoleApp1
{
    class Program
    {

        public static void Print<T>(string message, IEnumerable<T> collection) 
        {
            Console.WriteLine(message);
            foreach (T obj in collection) 
            {
                Console.WriteLine(obj);
            }
            Console.WriteLine();
        }
        public static void Main(string[] args)
        {
            Category c1 = new Category() { Id = 1, Name = "Tools", Tier = 2 };
            Category c2 = new Category() { Id = 1, Name = "Computers", Tier = 1 };
            Category c3 = new Category() { Id = 1, Name = "Eletronics", Tier = 1 };

            List<Product> products = new List<Product>()
            {
                new Product() { Id = 1, Name = "Computer", Price = 1100.0, Category = c2},
                new Product() { Id = 2, Name = "Hammer", Price = 90.0, Category = c1},
                new Product() { Id = 3, Name = "TV", Price = 1700.0, Category = c3},
                new Product() { Id = 4, Name = "Notebook", Price = 1300.0, Category = c2},
                new Product() { Id = 5, Name = "Saw", Price = 80.0, Category = c1},
                new Product() { Id = 6, Name = "Tablet", Price = 700.0, Category = c2},
                new Product() { Id = 7, Name = "Camera", Price = 700.0, Category = c3},
                new Product() { Id = 8, Name = "Printer", Price = 350.0, Category = c3},
                new Product() { Id = 9, Name = "MacBook", Price = 1800.0, Category = c2},
                new Product() { Id = 10, Name = "Sound Bar", Price = 700.0, Category = c3},
                new Product() { Id = 11, Name = "Level", Price = 70.0, Category = c1},
                
            };

            
            var v1 = products.Where(n => n.Category.Tier == 1 && n.Price < 900);
            Print("TIER 1 AND PRICE < 900; ", v1);

            var v2 = products.Where(n => n.Category.Name == "Tools").Select(n => n.Name);
            Print("NAME OF PRODUCTS FROM TOOLS", v2);

            var v3 = products.Where(n => n.Name.StartsWith("C")).Select(n => new { n.Name, n.Price, CategoryName = n.Category.Name});
            Print("NAMES STARTED WITH 'C' AND ANONYMOUS OBJECT", v3);

            var v4 = products.Where(n => n.Category.Tier == 1).OrderBy(n => n.Price).ThenBy(n => n.Name);
            Print("TIER 1 ORDER BY PRICE THEN BY NAME", v4);

            var v5 = v4.Skip(2).Take(4);
            Print("TIER 1 ORDER BY PRICE THEN BY NAME SKIP 2 TAKE 4", v5);

            var v6 = products.First();
            Console.WriteLine("First test1" + v6);

            var v7 = products.FirstOrDefault(n => n.Id == 1);
            Console.WriteLine($"First of default test2: {v7}");

            var v8 = products.Where(p => p.Id == 30).SingleOrDefault();
            Console.WriteLine($"First of default test2: {v8}");


        }




    }


}
