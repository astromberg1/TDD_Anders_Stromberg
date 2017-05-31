using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates1
{
    public delegate double CalcDelegate(double a, double b);

    public class Calculator
    {
        public CalcDelegate CalcLogic { get; set; }

        public void PrintCalculation(double a, double b)
        {
             CalcLogic(a, b);

        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {



        }
    }
}
