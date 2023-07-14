using EfCore;

internal class Program
{
    private static void Main(string[] args)
    {
        NorthwindContext northwindContext = new NorthwindContext();
        #region ToDictionary
        //foreach (var s in northwindContext.Categories.Where(c => c.CategoryId > 3).ToList()) Console.WriteLine(s);
        //foreach (var s in northwindContext.Categories.Where(c => c.CategoryId > 3).ToDictionary(u => u.CategoryName, u => u.Description)) Console.WriteLine(s);
        #endregion








    }
}