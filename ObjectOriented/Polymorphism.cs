using System;

namespace GeekForGeek.OO
{
    public static class Polymorphism
    {
        public static void Difference()
        {
            // Output: Child Class Print Method
            BaseClass overriding = new OverridingClass();
            overriding.Print();

            // Output: Base Class Print Method
            BaseClass overhiding = new OverhidingClass();
            overhiding.Print();

            // Output: Child Class Print Method
            OverhidingClass overhiding2 = new OverhidingClass();
            overhiding2.Print();
        }
    }

    public abstract class BaseClass
    {
        public virtual void Print()
        {
            Console.WriteLine("Base Class Print Method");
        }
    }

    /// <summary>
    /// Overriding means a base class reference variable pointing to a child class object, will invoke the overridden method in the Child class.
    /// </summary>
    public class OverridingClass : BaseClass
    {
        public override void Print()
        {
            //base.Print();
            Console.WriteLine("Child Class Print Method");
        }
    }

    /// <summary>
    /// means a base class reference variable pointing to a child class object, will invoke the hidden method in the Base class
    /// </summary>
    public class OverhidingClass : BaseClass
    {
        public new void Print()
        {
            Console.WriteLine("Child Class Print Method");
        }
    }
}
