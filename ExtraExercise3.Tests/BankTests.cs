using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using ExtraExercise3;

namespace ExtraExercise3.Tests
{
    [TestFixture]
    [Category("ExtraExercise3")]
    public class BankTests
    {

        private Bank sut;
        private IAuditLogger _auditlogger;

        [SetUp]

        public void Setup()
        {
            _auditlogger = Substitute.For<IAuditLogger>(); //Create
            sut = new Bank(_auditlogger);


        }


        [Test]

        public void CanCreateBankAccount()
        {
            var account = new Account() {Balance = 0, Name = "Kalle", Number = "9999999"};

            sut.CreateAccount(account);
            var result = sut.GetAccount("9999999");
            Assert.That(result, Is.EqualTo(account));



        }

        [Test]
        public void CanNotCreateDuplicateAccounts()
        {
            //When creating two accounts with the same account number, then a DuplicateAccount exception should be thrown

            var accountA = new Account() {Balance = 0, Name = "Kalle", Number = "9999999"};
            var accountB = new Account() {Balance = 0, Name = "Kalle", Number = "9999999"};
            sut.CreateAccount(accountA);

            Assert.Throws<DuplicateAccount>(() =>
                sut.CreateAccount(accountB));


        }

        [Test]
        public void WhenCreatingAnAccount_AMessageIsWrittenToTheAuditLog()
        {

            //Each time we create an account, we need to verify that the written message to the audit log contains both the name and account number of the newly created account.

            var account = new Account() {Balance = 0, Name = "Kalle", Number = "9999999"};

            sut.CreateAccount(account);
            _auditlogger.Received(1).AddMessage(Arg.Is<string>(x => x.Contains("Kalle") && x.Contains("9999999")));
            //Kollar så att addmessage blev anropad på min Mock med namn och nummer

        }


        [Test]
        public void WhenCreatingAnValidAccount_OneMessageAreWrittenToTheAuditLog()
        {
            var account = new Account() {Balance = 0, Name = "Kalle", Number = "9999999"};

            sut.CreateAccount(account);
            _auditlogger.Received(1).AddMessage(Arg.Any<string>());
        }

        [Test]
        public void WhenCreatingAnInvalidAccount_TwoMessagesAreWrittenToTheAuditLog()
        {
            var account = new Account() {Balance = 0, Name = "Kalle", Number = "999j9999"};

            Assert.Throws<InvalidAccount>(() =>
                sut.CreateAccount(account));

            _auditlogger.Received(2).AddMessage(Arg.Any<string>());

        }



        [Test]
        public void VerifyThat_GetAuditLog_GetsTheLogFromTheAuditLogger()

        {
            _auditlogger.GetLog().Returns(new List<string>{"A","B","C"});

            var logg = sut.GetAuditLog();



            Assert.AreEqual(3, logg.Count());

        }



    

    public void WhenCreatingAnInvalidAccount_AWarn12AndErro45MessageIsWrittenToAuditLog()
            //Each time we create an invalid account, the two messages written to the audit log must either contain Warn12: or Error45:
        {
            var account = new Account() { Balance = 0, Name = "Kalle", Number = "999j9999" };

            Assert.Throws<InvalidAccount>(() =>
                sut.CreateAccount(account));
            _auditlogger.Received(2).AddMessage(Arg.Is<string>(x => x.Contains("Warn12") || x.Contains("Error45")));
        }






    }
}
