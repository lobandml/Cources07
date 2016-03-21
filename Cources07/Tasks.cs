using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cources07
{
     class Tasks
    {
        delegate double Average(int number1, int number2,int number3);
        delegate double RND();
        delegate double DelegateAverage(RND[] dels);

        delegate double SomeMethod(double first, double second);
        

        public static void Task1()
        {
            Average avg = delegate(int number1, int number2,int number3)
            {
                double result=0;
                result += Convert.ToDouble(number1) / 3.0;
                result += Convert.ToDouble(number2) / 3.0;
                result += Convert.ToDouble(number3) / 3.0;
                return result;
            };

           Console.WriteLine( avg(1,2,3).ToString());
           Console.WriteLine(avg(12, 13, 15).ToString());
           Console.WriteLine(avg(1, -1, 0).ToString());
        }
        public static void Task2()
        {
            SomeMethod Add = (x, y) => { return x + y; };
            SomeMethod Sub = (x, y) => { return x - y; };
            SomeMethod Mul = (x, y) => { return x * y; };
            SomeMethod Div = (x, y) => 
            {
                if (y != 0)
                {
                    return x / y;
                }
                else

                {
                    return double.NaN;
                }
            };

            Console.WriteLine(Add(34, 2));
            Console.WriteLine(Sub(34, 2));
            Console.WriteLine(Mul(34, 2));
            Console.WriteLine(Div(34, 2));
        }
        public static void Task3()
        {
            DelegateAverage avg = delegate(RND[] dels)
            {
                double result = 0;
                for (int i = 0; i < dels.Length; i++)
                {
                    result += dels[i]();
                }
                return result;
            };

            RND[] ddd = new RND[3];
            Random randomgen=new Random();
            
            ddd[0] = delegate()
            {
                return randomgen.NextDouble(); //randov value
            };
            ddd[1] = ddd[0];
            ddd[2]=ddd[1];

            Console.WriteLine(avg(ddd));
        }
    }
}
