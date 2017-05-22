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
    public class ValidationTests
    {

        [Test]
        public void TrueForInValidAddress()
        {
            var sut = new ValidationEngine.Validator();
      
       
           
            
       
          
          
            Assert.False(sut.ValidateEmailAddress("name@test2015.com"));


        }

        [Test]
        public void ReturnFalseforName2015TestComAdress()
        {
            var sut = new ValidationEngine.Validator();
            Assert.False(sut.ValidateEmailAddress("Name2015@test.com"));

        }

        [Test]
        public void ReturnFalseforEmptyAdress()
        {
            var sut = new ValidationEngine.Validator();
            Assert.False(sut.ValidateEmailAddress(""));

        }

        [Test]
        public void ReturnFalseforTestComAdress()
        {
            var sut = new ValidationEngine.Validator();
            Assert.False(sut.ValidateEmailAddress("test.com"));

        }
        [Test]
        public void ReturnFalsefornametestAdress()
        {
            var sut = new ValidationEngine.Validator();
            Assert.False(sut.ValidateEmailAddress("name@test"));

        }

        [Test]
        public void ReturnFalseforNullAdress()
        {
            var sut = new ValidationEngine.Validator();
            Assert.False(sut.ValidateEmailAddress(null));

        }


        [Test]
    public void TrueForValidAddress()
        {
            var sut = new ValidationEngine.Validator();
        
           
                  
            Assert.True(sut.ValidateEmailAddress("mike@edument.se"));


        }

        [Test]
        public void TrueForJoeAppleAddress()
        {
            var sut = new ValidationEngine.Validator();


            Assert.True(sut.ValidateEmailAddress("joe@apple.com"));

        }



    }
    }
