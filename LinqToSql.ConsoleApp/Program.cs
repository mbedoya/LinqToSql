using LinqToSql.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToSql.ConsoleApp
{
    class Program
    {
       
        static void Main(string[] args)
        {
            LinqContext context = new LinqContext();

            var categories =
                from c in context.Categories 
                select c;

            Console.WriteLine("All categories");
            Console.WriteLine("{0, -10} {1, 10}", "Id", "Name");
            foreach (var item in categories)
            {
                Console.WriteLine("{0, -10} {1, 10}", item.CategoryId, item.Name);
            }

            
            var categoryWithProducts =
                from c in context.Categories
                join p in context.Products on c.CategoryId equals p.CategoryId
                select new { CategoryId = c.CategoryId, CategoryName = c.Name, ProductName = p.Name != null ? p.Name : "" };

            Console.WriteLine("Categories with products");
            Console.WriteLine("{0, -10} {1, 10} {2, 20}", "Id", "Name", "Product");
            foreach (var item in categoryWithProducts)
            {
                Console.WriteLine("{0, -10} {1, 10} {2, 20}", item.CategoryId, item.CategoryName, item.ProductName);
            }

            Console.WriteLine("All categories and their products");
            var categoryWithEmptyProducts =
                from c in context.Categories
                join p in context.Products on c.CategoryId equals p.CategoryId into cp
                from x in cp.DefaultIfEmpty()
                select new { CategoryId = c.CategoryId, CategoryName = c.Name, ProductName = x.Name != null ? x.Name : "" };

            Console.WriteLine("{0, -10} {1, 10} {2, 20}", "Id", "Name", "Product");
            foreach (var item in categoryWithEmptyProducts)
            {
                Console.WriteLine("{0, -10} {1, 10} {2, 20}", item.CategoryId, item.CategoryName, item.ProductName);
            }

            Console.WriteLine("Products by Category");
            var productsByCategory =
                from c in context.Categories
                join p in context.Products on c.CategoryId equals p.CategoryId into cp
                from x1 in cp
                group c by x1.Category.Name into g
                select new { CategoryId = g.Key, Count = g.Count() != null ? g.Count() : 0 };

            Console.WriteLine("{0, -10} {1, 10}", "Name", "Count");
            foreach (var item in productsByCategory)
            {
                Console.WriteLine("{0, -10} {1, 10}", item.CategoryId, item.Count);
            }
            
            Console.ReadKey();

        }
    }
}
