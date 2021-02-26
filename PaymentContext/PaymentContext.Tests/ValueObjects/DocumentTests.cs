using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests
{
    [TestClass]

    public class DocumentTests
    {
        [TestMethod]
        public void AdicionarAssinatura()
        {
            // Red, Green, Refactor

        }

        [TestMethod]
        public void ShouldReturnErrorWhenCNPJIsInvalid()
        {
            var doc = new Document("123", EDocumentType.CNPJ);
            Assert.IsTrue(doc.Invalid);
        }
        [TestMethod]
         public void ShouldReturnSucessWhenCNPJIsValid()
        {
            var doc = new Document("34110468000150", EDocumentType.CNPJ);
            Assert.IsTrue(doc.Valid);
        }
        [TestMethod]
        public void ShouldReturnErrorWhenCPFIsInvalid()
        {
            var doc = new Document("123", EDocumentType.CPF);
            Assert.IsTrue(doc.Invalid);
        }
        [TestMethod]
        [DataTestMethod]
        [DataRow("54209721077")]
        [DataRow("63830444001")]
        [DataRow("97933877001")]
        [DataRow("16218996085")]
         public void ShouldReturnSucessWhenCPFIsValid()
        {
            var doc = new Document("34225545806", EDocumentType.CPF);
            Assert.IsTrue(doc.Valid);
        }

    }
}