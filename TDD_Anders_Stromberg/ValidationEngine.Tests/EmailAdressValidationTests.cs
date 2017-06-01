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
    [Category("Exercise1")]
    public class EmailAdressValidationTests
    {
        private Validator sut = new ValidationEngine.Validator();
        //System Under Test =sut

        [Test]
      [Repeat(20)]
        [Category("Exercise1")]
        public void TrueForInValidAddress()
        {
           
      
     
           
          
          
            Assert.False(sut.ValidateEmailAddress("name@test2015.com"));


        }

        [Test]
        [Category("Exercise1")]
        [Ignore("behövs ej")]
        public void ReturnFalseforName2015TestComAdress()
        {
          
            Assert.False(sut.ValidateEmailAddress("Name2015@test.com"));

        }

        [Test]
        [MaxTime(40)]
        public void ReturnFalseforEmptyAdress()
        {
          
            Assert.False(sut.ValidateEmailAddress(""));

        }

        [Test]
        [Category("Exercise1")]
        public void ReturnFalseforTestComAdress()
        {
          
            Assert.False(sut.ValidateEmailAddress("test.com"));

        }
        [Test]
        [Category("Exercise1")]
        public void ReturnFalsefornametestAdress()
        {
            Assert.False(sut.ValidateEmailAddress("name@test"));

        }

        [Test]
        [Category("Exercise1")]
        public void ReturnFalseforNullAdress()
        {
            
            Assert.False(sut.ValidateEmailAddress(null));

        }


        [Test]
        [Category("Exercise1")]
        public void TrueForValidAddress()
        {
           
        
           
                  
            Assert.True(sut.ValidateEmailAddress("mike@edument.se"));


        }

        [Test]
        [Category("Exercise1")]
        public void TrueForJoeAppleAddress()
        {
           


            Assert.True(sut.ValidateEmailAddress("joe@apple.com"));

        }



    }
    }
