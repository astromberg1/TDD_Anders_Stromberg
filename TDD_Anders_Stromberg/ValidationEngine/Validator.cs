using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ValidationEngine
{
public class Validator
{
    

        private string _emailadress;

   public bool ValidateEmailAddress(string emailadress)
    {
        if (string.IsNullOrEmpty(emailadress))
            return false;

       
        int pos1 = emailadress.IndexOf('@');
        if (!(pos1 > 0))
            return false;
        string del1 = emailadress.Substring(0,pos1);
        string dl2 = emailadress.Substring(pos1+1);
            int pos2 = dl2.IndexOf('.');
        if (!(pos2 > 0))
            return false;
        string del2 = emailadress.Substring(pos1+1, pos2);

       string del3 = dl2.Substring(pos2+1);

        if (!((Regex.IsMatch(del1, @"^[a-zA-Z]+$"
        ))))
            return false;
        if (!((Regex.IsMatch(del2, @"^[a-zA-Z]+$"
        ))))
            return false;

        if (!((Regex.IsMatch(del3, @"^[a-zA-Z]+$"
        ))))
            return false;

            return true;
        //A - Z)@(A - Z).(A - Z)


    }



}
}
