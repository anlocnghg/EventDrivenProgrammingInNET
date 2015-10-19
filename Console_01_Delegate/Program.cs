/*
 * Event-driven Programming in .NET
 * Learn delegate-event by simplest examples
 * Article URL: http://www.codeproject.com/Articles/1008553/Event-Driven-Programing-in-NET
 * 
 * By: Lộc Nguyễn
 * URL: http://locnguyen.us/
 * Email: loc.nguyen.st.louis[at]Gmail[dot]com
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_01_Delegate
{
    delegate void MyDelegate(int x, int y);
    class Program
    {
        static void Main(string[] args)
        {
            MyClass myClass = new MyClass();

            MyDelegate myDelegate;

            // Instantiate the delegates
            MyDelegate addDelegate = myClass.Add;
            MyDelegate multiplyDelegate = myClass.Multiply;
            MyDelegate subtractDelegate = myClass.Subtract;

            // 'Point' to Add() method
            myDelegate = myClass.Add;

            myDelegate(2, 1); // Call the delegate / invoke Add()
            System.Console.WriteLine();

            // Add Add() and Multiply() method to invocation list
            myDelegate = addDelegate + multiplyDelegate;

            myDelegate(4, 3); // Invoke Add(), then Multiply()
            System.Console.WriteLine();

            // Add Subtract() method to invocation list
            myDelegate += myClass.Subtract;

            myDelegate(6, 5); // Invoke Add(), then Multiply(), then Subtract()
            System.Console.WriteLine();

            // Remove Multiply() method from invocation list
            myDelegate -= myClass.Multiply;

            myDelegate(8, 7); // Invoke Add(), then Subtract()

            System.Console.ReadKey();
        }
    }

    class MyClass
    {
        public void Add(int a, int b)
        {
            System.Console.WriteLine("{0} adds {1} = " + (a + b), a, b);
        }

        public void Multiply(int a, int b)
        {
            System.Console.WriteLine("{0} multiplies {1} = " + (a * b), a, b);
        }

        public void Subtract(int a, int b)
        {
            System.Console.WriteLine("{0} subtracts {1} = " + (a - b), a, b);
        }
    }
}