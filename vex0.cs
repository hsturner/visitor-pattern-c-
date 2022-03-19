using System;

// extend the following visitor pattern with an additional city class 
// without changing existing code except main.

interface city  // visitees
{
   void accept(cityvisitor v);
}

interface cityvisitor
{
   void visit(NY n);
   void visit(LA n);
}

class NY : city
{
  public void accept(cityvisitor v) { v.visit(this); }
}

//new city boston
class Boston : city
{
   public void accept(cityvisitor v)
   {
      if (v is Ibettervisitor)
         ((Ibettervisitor)v).visit(this);
      else throw new Exception("Visitor can't visit Boston, lucky them");

   }
}

class LA : city
{
  public void accept(cityvisitor v) { v.visit(this); }
}

//// sample visitor
/// extended for problem 3b. to visit Boston
class tourist : bostonvisitor, cityvisitor 
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
// extended for problem 3b. to visit boston
class collegestudent : bostonvisitor, cityvisitor
{
   public void visit(NY ny) {Console.WriteLine("goto NYU");}
   public void visit(LA ca) {Console.WriteLine("gogo UCLA");}
}

//new visitor to visit boston

interface Ibettervisitor
{
   void visit(Boston b);
}

class bostonvisitor : Ibettervisitor {
   public void visit(Boston b)
   {Console.WriteLine((this) + " is visiting boston!");}
}


//new visitor class that can visit all three cities
class bettervisitor : Ibettervisitor, cityvisitor
{
   public virtual void visit(NY n) {Console.WriteLine("Better visiting NY");}
   public virtual void visit(LA l){Console.WriteLine("Better visiting LA");}
   public virtual void visit(Boston b) {Console.WriteLine("better visiting boston");}
   
}

//problem 2: food visitor -- also can visit boston
class foodvisitor : cityvisitor, Ibettervisitor
{
   public  void visit(NY ny) {Console.WriteLine("Eating a hotdog in ny");}
   public void visit(LA ca) {Console.WriteLine("Eating bad pizza in la");}

   public void visit(Boston b)
   {
      Console.WriteLine("Eating whatever you eat in boston");
   }
}

//Problem 1: fixed sports fan class
class sportsfan : bostonvisitor, cityvisitor
{
   public void visit(NY x)
   {
      Console.WriteLine("go to a yankees game");
   }

   public void visit(LA x)
   {
      Console.WriteLine("go to a dodgers game");
   }
}

public class vex2
{
  public static void Main()
  {
     city[] Cs = {new NY(), new LA()};
     cityvisitor you = new tourist();
     sportsfan baseballfan = new sportsfan();
     foreach(city c in Cs) {c.accept(you); c.accept(new collegestudent());c.accept(baseballfan);}

     cityvisitor food = new foodvisitor();
     

     Boston b = new Boston();
     b.accept(food);
     b.accept(new bettervisitor());
     b.accept(you);
  }//Main
}


 /////////// Problem 1:

/*
Explain what, if anything is wrong with the following code.  If there's
something wrong, how can you fix it?

//FIXED: the visitee must accept the visitor


public static void Main()
{
  sportsfan baseballfan = new sportsfan();
  city[] Cities = {new NY(), new LA()};
  foreach(city c in Cities) c.accept(baseballfan); 
}
}

Problem 2. Add a foodvisitor class that eats a different type of local food in
each city. --DONE

Problem 3: Add an additional city class to the design, WITHOUT
TOUCHING THE EXISTING CLASSES AND INTERFACES.  All additions must be
done via subclasses or extended interfaces.  That is, imagine that you
don't have access to this source code, only a .dll. --DONE

Problem 3b.
Extend the tourist, collegestudent, sportsfan, and foodvisitor classes to visit your new city.
--DONE


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
