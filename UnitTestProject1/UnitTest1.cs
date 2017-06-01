using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValidationEngine;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private Validator sut = new ValidationEngine.Validator();
        [TestMethod]
        public void ReturnFalseforName2015TestComAdress()
        {

            Assert.IsFalse(sut.ValidateEmailAddress("Name2015@test.com"));

        }
    }
}
