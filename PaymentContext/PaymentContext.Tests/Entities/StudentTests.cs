using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests
{
    [TestClass]

    public class StudentTests
    {
        private readonly Name _name;
        private readonly Document _document;
        private readonly Email _email;
        private readonly Address _address;
        private readonly Student _student;
        private readonly Subscription _subscription;

        public StudentTests()
        {
            _name = new Name("Bruce", "Wayne");
            _document = new Document("35111507795", EDocumentType.CPF);
            _email = new Email("batman@dc.com");
            _address = new Address("Rua 1", "329", "Cubatón", "Bolsao 8", "Sao Paulo", "Brasil", "1115433");
            _student = new Student(_name, _document, _email);
            _subscription = new Subscription(null);
        }

        [TestMethod]
        public void ShoulReturnErrorWhenHadActiveSubscription()
        {
            /* var payment = new PaypalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "WAYNE CORP", _document, _address, _email);
            _subscription.AddPayment(payment); */
            _student.addSubscription(_subscription);
            _student.addSubscription(_subscription);
            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShoulReturnErrorWhenSubscriptionHasNoPayment()
        {
            var name = new Name("Bruce", "Wayne");
            var document = new Document("35111507795", EDocumentType.CPF);
            var email = new Email("batman@dc.com");
            var Student = new Student(name, document, email);

            Assert.Fail();
        }


       /*  [TestMethod]
         public void ShoulReturnSucessWhenHadActiveSubscription()
        {
            Assert.Fail();
        }  */
    }
}