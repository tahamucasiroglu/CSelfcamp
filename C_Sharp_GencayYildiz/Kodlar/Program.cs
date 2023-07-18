internal class Program
{
    struct CustomType2
    {
        int a;
        string b;
        double c;
        public CustomType2(int a, string b, double c)
        {
            this.a = a; 
            this.b = b; 
            this.c = c;
        }
    }
    private static void Main(string[] args)
    {
        #region Region Anlatım Kodu
        #region ekrana 100 e kadar sayı yazan kod
        //for (int i = 0; i < 100; i++)
        //{
        //    Console.WriteLine(i);
        //}
        #endregion
        #endregion



        #region IsPrimitive Anlatımı
        //Console.WriteLine(typeof(decimal).IsPrimitive);
        //Console.WriteLine(typeof(int).IsPrimitive);
        //Console.WriteLine(typeof(byte).IsPrimitive);
        #endregion

        #region Tuple
        //(int a, string b, double c) customType = (1, "ahmet", 3.14);

        //Console.WriteLine(customType);
        //Console.WriteLine(customType.a);
        //Console.WriteLine(customType.b);
        //Console.WriteLine(customType.c);

        //customType = (2, "taha", 2.72);

        //Console.WriteLine(customType);
        //Console.WriteLine(customType.a);
        //Console.WriteLine(customType.b);
        //Console.WriteLine(customType.c);
        #endregion

        #region dynamic tip
        //dynamic tip = 3;
        //Console.WriteLine(tip.ToString() + " " + tip.GetType());
        //tip = "Ahmet";
        //Console.WriteLine(tip.ToString() + " " + tip.GetType());
        #endregion

        #region switch - case property pattern
        //Student student = new Student() { name = "Taha", surname = "Mücasiroğlu", alan = "Sayısal" };
        //string anadersi = student switch
        //{
        //    { alan: "Sayısal" } => "Matematik",
        //    { alan: "Sözel" } => "Tükçe",
        //    { alan: "Eşit-Ağırlık" } => "Matematik ve Türkçe"
        //};
        #endregion

        #region for döngüsü
        //for (int i = 0; i < 100; i++)
        //{
        //    for (int j = 0; j < 100; j++)
        //    {
        //        Console.WriteLine(i.ToString() + " - " + j.ToString());
        //    }
        //}

        //for (int k = 0; k < 10000; k++)
        //{
        //    int i = k / 100;
        //    int j = k % 100;
        //    Console.WriteLine(i.ToString() + " - " + j.ToString());
        //}

        //for (int k = 0, i=k/100, j= k % 100; k < 10000; k++, i = k / 100, j = k % 100)
        //{
        //    Console.WriteLine(i.ToString() + " - " + j.ToString());
        //}


        #endregion


        #region Checked

        //Point p1 = new Point(X: 2_147_483_646, Y: 2_147_483_646);
        //Point p2 = new Point(X:5, Y:5);
        //Point p3 = new Point();
        //p3 = unchecked(p1 + p2);
        //Console.WriteLine(p3);
        //p3 = checked(p1 + p2);
        //Console.WriteLine(p3);
        #endregion


        #region nint ve nuint
        //nint a = nint.MaxValue;

        //Console.WriteLine(a);
        //Console.WriteLine(Int64.MaxValue);

        //Console.WriteLine(a.GetType());
        //Console.WriteLine(Int64.MaxValue.GetType());
        #endregion


        #region finalizers
        //using (B b = new B())
        //{
        //    Console.WriteLine("using" + b.ToString());
        //}
        //    Console.WriteLine(1);

        //Console.WriteLine(2);

        //Console.WriteLine(3);
        //GC.Collect();
        //Console.WriteLine(4);
        //GC.WaitForPendingFinalizers();
        //Console.WriteLine(5);
        #endregion

        #region Yield

        //foreach (var arg in new YieldTest().GetFib(15))
        //{
        //    Console.WriteLine(arg);
        //}

        #endregion








    }
    public class Student
    {
        public string name { get; set; } = "";
        public string surname { get; set; } = "";
        public string alan { get; set; } = "";
    }

    public record struct Point(int X, int Y)
    {
        public static Point operator checked +(Point left, Point right)
        {
            checked
            {
                Console.WriteLine("Checked çalıştı");
                return new Point(left.X + right.X, left.Y + right.Y);
            }
        }
        public static Point operator +(Point left, Point right)
        {
            Console.WriteLine("Normal çalıştı");
            return new Point(left.X + right.X, left.Y + right.Y);
        }
    }
    //public record Person(int Id, string Name, bool IsActive);

    public record Person
    {
        int Id { get; init; }
        string Name { get; init; }
        bool IsActive { get; init; }
        public Person(int ıd, string name, bool ısActive)
        {
            Id = ıd;
            Name = name;
            IsActive = ısActive;
        }
    }

    class A
    {
        ~A()
        {
            Console.WriteLine("A's finalizer");
        }
    }

    class B : A, IDisposable
    {
        ~B()
        {
            Console.WriteLine("B's finalizer");
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }

    public record struct TESTA
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public TESTA(int Id, string Name)
        {
            this.Name = Name;
            this.Id = Id;
        }

        public static explicit operator TESTA(string name) => new TESTA() { Id = 0, Name = name };
    }


    public class YieldTest
    {
        int a=1,b=1;
        public IEnumerable<int> GetFib(int len)
        {
            for (int i = 0; i < len; i++)
            {
                yield return a + b;
                int temp = a;
                a += b;
                b = temp;
            }
        }
    }
}

