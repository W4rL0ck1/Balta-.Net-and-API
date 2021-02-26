using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaltaStore.Tests
{
    [TestClass]

    public class DocumentTests
    {
        private Document validDocument;
        private Document invalidDocument;

        public DocumentTests()
        {
            validDocument = new Document("28659170377");
            invalidDocument = new Document("12345678910");
        }

        [TestMethod]
        public void ShouldReturnNotificationWhenDocumentIsNotValid()
        {
            Assert.AreEqual(false, invalidDocument.Valid);
            Assert.AreEqual(1, invalidDocument.Notifications.Count);
        }
        [TestMethod]
        public void ShouldNotReturnNotificationWhenDocumentIsValid()
        {
            Assert.AreEqual(true, validDocument.Valid);
            Assert.AreEqual(0, validDocument.Notifications.Count);
        }
    }
}
