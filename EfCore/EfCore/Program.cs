using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            NorthwindContext context = new NorthwindContext();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine(context.Employees.Include(e => e.Orders).First().Orders.First().ShipName);
            Console.WriteLine(stopwatch.ElapsedMilliseconds);

        }
    }
}
