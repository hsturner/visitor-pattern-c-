using System;
interface city  // visitees
{
    T accept<T>(visitor<T> v);
}

interface visitor<out T>
{
    T visit(NY n);
    T visit(LA n);
}
class shopper : visitor<double> // each shopper spends $$$
{
    public double visit(LA ca) { return 1000.0; } // LA is expensive
    public double visit(NY ny) { return 10000.99; } // NY is more expensive
}

class NY : city
{
    public T accept<T>(visitor<T> v)
    {
        return v.visit(this);
      //  return (T)(object)v;
    }
}
class LA : city
{
    public T accept<T>(visitor<T> v)
    {
        return v.visit(this);
       // return (T)(object)v;
    }
}

public class vex1
{
    public static void Main()
    {
        visitor<double> v = new shopper();
        NY n = new NY();
        double a;
        a = n.accept<double>(v);
        Console.WriteLine("Printing now should be .99" + a);
    }
}