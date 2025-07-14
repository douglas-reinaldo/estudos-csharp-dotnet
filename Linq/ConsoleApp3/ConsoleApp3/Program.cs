using ConsoleApp3.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Diagnostics.Contracts;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the full file path: ");
            string sourcePath = Console.ReadLine();
            List<Employee> employees = new List<Employee>();
            try
            {
                if (!File.Exists(sourcePath)) 
                {
                    Console.WriteLine("File path not found! ");
                    return;
                }

                
                using(StreamReader sr = new StreamReader(sourcePath)) 
                { 
                    while (!sr.EndOfStream) 
                    {
                        string[] data = sr.ReadLine().Split(',');
                        string employeeName = data[0];
                        string employeeEmail = data[1];
                        double employeeSalary = double.Parse(data[2], CultureInfo.InvariantCulture);

                        employees.Add(new Employee(employeeName, employeeEmail, employeeSalary));
                    }
                }

                Console.WriteLine("Enter salary: ");
                double salary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                // Utilizando Syntax Methods do Linq
                var emailsEmployee = employees.Where(n => n.Salary > salary).OrderBy(n => n.Email).Select(n => n.Email);
                Console.WriteLine($"Email of people whose salary is more than {salary}");
                foreach (var item in emailsEmployee)
                {
                    Console.WriteLine(item);
                }
                double sumSalary = employees.Where(n => n.Name.StartsWith("M")).Sum(n => n.Salary);
                Console.WriteLine("Sum of salary of people whose name start with 'M': " + sumSalary);




                // Utilizano Syntax Query do Linq
                var emailsEmployee2 = from e in employees
                                     where e.Salary > salary
                                     orderby e.Email
                                     select e.Email;

                var sumSalary2 = (from e in employees
                                  where e.Name.StartsWith("M")
                                  select e.Salary).Sum();

            }

            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
