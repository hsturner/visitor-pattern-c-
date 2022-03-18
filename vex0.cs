using System;

// extend the following visitor pattern with an additional city class 
// without changing existing code except main.

interface city  // visitees
{
   void accept(visitor v);
}

interface visitor
{
   void visit(NY n);
   void visit(LA n);
}

class NY : city
{
  public void accept(visitor v) { v.visit(this); }
}

//new city boston
class Boston : city
{
   public void accept(visitor v)
   {
      if (v is Ibettervisitor)
      {
         return v.visit(this);
      }
   }
}

class LA : city
{
  public void accept(visitor v) { v.visit(this); }
}

//// sample visitor
class tourist : visitor
{
   public void visit(NY n)
   {
       Console.WriteLine("goto statue of liberty");
   }
   public void visit(LA n)
   {
       Console.WriteLine("goto hollywood");
   }
}//tourist

/// another visitor
class collegestudent : visitor
{
   public void visit(NY ny) {Console.WriteLine("goto NYU");}
   public void visit(LA ca) {Console.WriteLine("gogo UCLA");}
}

//new visitor to visit boston

interface Ibettervisitor : visitor
{
   void visit(Boston b);
}


//new visitor class that can visit all three cities
class bettervisitor : Ibettervisitor
{
   public  void visit(NY ny) {Console.WriteLine("better visiting ny");}
   public void visit(LA ca) {Console.WriteLine("better visiting la");}

   public void visit(Boston b)
   {Console.WriteLine("better visiting boston");}
}

//problem 1: food visitor
class foodvisitor : visitor
{
   public  void visit(NY ny) {Console.WriteLine("better visiting ny");}
   public void visit(LA ca) {Console.WriteLine("better visiting la");}  
}

public class vex2
{
  public static void Main()
  {
     city[] Cs = {new NY(), new LA()};
     visitor you = new tourist();
     foreach(city c in Cs) {c.accept(you); c.accept(new collegestudent());}

     Boston b = new Boston();
     b.accept(new bettervisitor());
  }//Main
}


/* /////////// Problem 1:

Explain what, if anything is wrong with the following code.  If there's
something wrong, how can you fix it?

public class sportsfan : visitor
{
   public void visit(NY x)
   { Console.WriteLine("go to a yankees game"); }
   public void visit(LA x)
   { Console.WriteLine("go to a dodgers game"); }

   public static void Main()
   {
     sportsfan baseballfan = new sportsfan();
     city[] Cities = {new NY(), new LA()};
     foreach(city c in Cities) baseballfan.visit(c);
   }
}

Problem 2. Add a foodvisitor class that eats a different type of local food in
each city.

Problem 3: Add an additional city class to the design, WITHOUT
TOUCHING THE EXISTING CLASSES AND INTERFACES.  All additions must be
done via subclasses or extended interfaces.  That is, imagine that you
don't have access to this source code, only a .dll.

Problem 3b.
Extend the tourist, collegestudent, sportsfan, and foodvisitor classes to visit your new city.


4. Modify the program so that the accept method can return a generic argument:
(write a different program - modify all code you've written for the previous
 program - instead of printing, you can return a string, for example)

interface city  // visitees
{
   T accept<T>(visitor v);
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
*/
