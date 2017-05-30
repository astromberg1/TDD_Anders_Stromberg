using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
   public class Calculator
   {
     

       public int Add(string numbers)
       {
           int res;
           bool isdecimal;
           List<int> tallista = new List<int>();

            int summa = 0;
            if (string.IsNullOrEmpty(numbers))
               return 0;
           string sum = "";

           foreach (char ch in numbers)
           {

               if (Char.IsNumber(ch)|| ch.Equals('-'))
               {
                   sum = sum + ch;
               }
               else
               {
                   
                   isdecimal = int.TryParse(sum, out res);
                    
                   if (isdecimal)
                   {

                       if (res > 1000)
                           res = 0;
                       tallista.Add(res);
                       //if (res < 0)
                       //    throw new StringCalculatorException(res.ToString());

                        summa = summa + res;

                   }
                   sum = "";

               }





           }

           
           isdecimal = int.TryParse(sum, out res);
           if (isdecimal)
           {
               if (res > 1000)
                   res = 0;
               tallista.Add(res);

            }

            //check if any numbers are negative
           List<int> negtallista = new List<int>();
           string strnegtal = "";
           int i = 0;
           foreach (int tal in tallista)
           {
               if (tal < 0)
               {
                   i++;
                    if ((i <tallista.Count()-1))
                       strnegtal = strnegtal+ tal.ToString() + ",";
                   else
                       strnegtal = strnegtal+ tal.ToString();
                
                }

           }
           if (strnegtal.Length > 0)
           {
               throw new StringCalculatorException("negatives not allowed "+strnegtal);

           }

           summa = tallista.Sum();

            return summa;



        }


    }
}
