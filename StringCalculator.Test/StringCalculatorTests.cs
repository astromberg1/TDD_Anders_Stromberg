using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using StringCalculator;

namespace StringCalculator.Test
{
    [TestFixture]
    public    class StringCalculatorTests
    {
        private Calculator sut;

        [SetUp]
        public void Setup()
        {
            sut = new Calculator();
        
        }

        [TearDown]
        public void Teardown()
        {
            sut = null;

        }


        [Test]

        public void StringCalculatorShouldReturnZeroIfNullString()
        {
            int result = sut.Add(null);

            Assert.That(result,Is.EqualTo(0));



        }
        [Test]
        public void StringCalculatorShouldReturnZeroIfEmptyString()
        {
            int result = sut.Add(string.Empty);

            Assert.That(result, Is.EqualTo(0));

        }

        [TestCase("1",1)]
        [TestCase("2", 2)]
        public void StringCalculatorShouldReturnValueIfOneValueString(string valuestring, int result)
        {
            int res = sut.Add(valuestring);

            Assert.That(res, Is.EqualTo(result));
         }

        [TestCase("111", 111)]
        [TestCase("222", 222)]
        public void StringCalculatorShouldReturnValueWithManyDigitsInOneValueString(string valuestring, int result)
        {
            int res = sut.Add(valuestring);

            Assert.That(res, Is.EqualTo(result));
        }



        [TestCase("1,2", 3)]
        [TestCase("2,5", 7)]
        public void StringCalculatorShouldReturnSumWithCommaDelimiterString(string valuestring, int result)
        {
            int res = sut.Add(valuestring);

            Assert.That(res, Is.EqualTo(result));
        }
        [TestCase("1,2,", 3)]
        [TestCase("2,5,", 7)]
        
        public void StringCalculatorShouldReturnSumWithCommaDelimiterAndExtraCommaString(string valuestring, int result)
        {
            int res = sut.Add(valuestring);

            Assert.That(res, Is.EqualTo(result));
        }
        [TestCase("2,5,3,3,3,3,3,3,3,3,120,999,99", 1249)]
        public void StringCalculatorShouldReturnSumWithMultipleValues(string valuestring, int result)
        {
            int res = sut.Add(valuestring);

            Assert.That(res, Is.EqualTo(result));
        }

        [TestCase("1\n2,3x§", 6)]
        [TestCase("1,\n", 1)]
        public void StringCalculatorShouldReturnSumWithAnotherCharDelimersString(string valuestring, int result)
        {
            int res = sut.Add(valuestring);

            Assert.That(res, Is.EqualTo(result));
        }

        [TestCase("2,1001", 2)]
        public void StringCalculatorShouldIgnoreValuesBiggerThan1000(string valuestring, int result)
        {
            int res = sut.Add(valuestring);

            Assert.That(res, Is.EqualTo(result));
        }

        // 5.	Calling Add with a negative number will throw an exception “negatives not allowed” 
        //- and the negative that was passed. if there are multiple negatives, show all of them in the exception message
        [Test]
        public void StringCalculatorAddShouldThrowExceptionIfValuesAreNegative()
        {

            Assert.That(() => sut.Add("-10")
                , Throws.TypeOf<StringCalculatorException>());
            

        }

        [Test]
        public void StringCalculatorAddShouldThrowExceptionWithMessageIfValuesAreNegative()
        {
            var ex = Assert.Throws<StringCalculatorException>(() =>
                sut.Add("-10"));
            Assert.That(ex.Message, Is.EqualTo("negatives not allowed -10"));
        }

        [Test]
        public void StringCalculatorAddShouldThrowExceptionWithMessageIfManyValuesAreNegative()
        {
            var ex = Assert.Throws<StringCalculatorException>(() =>
                sut.Add("-10,-20,10,-5"));
            Assert.That(ex.Message, Is.EqualTo("negatives not allowed -10,-20,-5"));
        }
    }
}
