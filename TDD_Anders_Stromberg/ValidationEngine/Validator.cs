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
    //Refactoring is cleaning up a piece of code(e.g.improving the style, design, or algorithms), without changing(externally visible) behavior.You write tests not to make sure that the code before and after refactoring is the same, instead you write tests as an indicator that your application before and after refactoring behaves the same: The new code is compatible, and no new bugs were introduced.
    //    Your primary concern should be to write unit tests for the public interface of your software.This interface should not change, so the tests(that are an automated check for this interface) shouldn't change either

    //If the purpose of your refactoring is to clean up existing code without changing existing behavior, then writing tests before refactoring is how you ensure that you have not changed the behavior of the code, if you succeed, then the tests will succeed both before and after you refactor.
    //    The tests will help you ensure that your new work actually works.
    //    The tests will probably also uncover cases where the original work does not work.
    //    But how do you really do any significant refactoring without affecting behavior to some degree?

    //Here is a short list of a few things that might happen during refactoring:
    //rename variable
    //rename function
    //add function
    //delete function
    //split function into two or more functions
    //    combine two or more functions into one function
    //    split class
    //    combine classes
    //    rename class



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
