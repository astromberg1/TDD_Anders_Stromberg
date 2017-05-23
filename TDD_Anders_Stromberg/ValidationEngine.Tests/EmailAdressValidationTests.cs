using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using ValidationEngine;

namespace ValidationEngine.Tests
{

    [TestFixture]
    public class EmailAdressValidationTests
    {
        private Validator sut = new ValidationEngine.Validator();
        //System Under Test =sut

        [Test]
        public void TrueForInValidAddress()
        {
           
      
     
           
          
          
            Assert.False(sut.ValidateEmailAddress("name@test2015.com"));


        }

        [Test]
        public void ReturnFalseforName2015TestComAdress()
        {
          
            Assert.False(sut.ValidateEmailAddress("Name2015@test.com"));

        }

        [Test]
        public void ReturnFalseforEmptyAdress()
        {
          
            Assert.False(sut.ValidateEmailAddress(""));

        }

        [Test]
        public void ReturnFalseforTestComAdress()
        {
          
            Assert.False(sut.ValidateEmailAddress("test.com"));

        }
        [Test]
        public void ReturnFalsefornametestAdress()
        {
            Assert.False(sut.ValidateEmailAddress("name@test"));

        }

        [Test]
        public void ReturnFalseforNullAdress()
        {
            
            Assert.False(sut.ValidateEmailAddress(null));

        }


        [Test]
    public void TrueForValidAddress()
        {
           
        
           
                  
            Assert.True(sut.ValidateEmailAddress("mike@edument.se"));


        }

        [Test]
        public void TrueForJoeAppleAddress()
        {
           


            Assert.True(sut.ValidateEmailAddress("joe@apple.com"));

        }



    }
    }
