using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ValidationEngine
{
public class Validator
{
    

      

   public bool ValidateEmailAddress(string emailadress)
    {
        if (string.IsNullOrEmpty(emailadress))
            return false;

       
        int atSignIndex = emailadress.IndexOf('@');
        if (!(atSignIndex > 0))
            return false;

        string emailAdressBeforeAtSign = emailadress.Substring(0,atSignIndex);
        string emailAdressRestPart = emailadress.Substring(atSignIndex+1);
            int atSignDot = emailAdressRestPart.IndexOf('.');
        if (!(atSignDot > 0))
            return false;
        string emailAdressAfterAtSignAndBeforeDotSign = emailadress.Substring(atSignIndex+1, atSignDot);

       string emailAdressAfterDotSign = emailAdressRestPart.Substring(atSignDot+1);

       return EmailAddressIsOk(emailAdressBeforeAtSign, emailAdressAfterAtSignAndBeforeDotSign, emailAdressAfterDotSign);
        


    }

    bool EmailAddressIsOk(string adressBeforeAtSign, string adressBetweenAtSignAndDotSign, string adressAfterDotSign)
    {
        if (CheckStringContainOtherSignThanAtoZ(adressBeforeAtSign) && CheckStringContainOtherSignThanAtoZ(adressBetweenAtSignAndDotSign) && CheckStringContainOtherSignThanAtoZ(adressAfterDotSign))
                return true;
        else
        {
            return false;
        }



    }


    bool CheckStringContainOtherSignThanAtoZ(string expression)
    {

        if (Regex.IsMatch(expression, @"^[a-zA-Z]+$"))
        return true;
        else
        return false;


     }




    }
}
