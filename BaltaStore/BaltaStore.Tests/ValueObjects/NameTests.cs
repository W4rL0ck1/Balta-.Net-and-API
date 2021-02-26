using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaltaStore.Tests.ValueObjects
{
    [TestClass]
    public class NameTests
    {
        [TestMethod]
        public void ShouldReturnNotificationWhenNameIsNotValid()
        {
            /*Assert.AreEqual(false, invalidDocument.IsValid);
            Assert.AreEqual(1, invalidDocument.Notifications.Count);*/
        }
        [TestMethod]
        public void ShouldNotReturnNotificationWhenIsValid()
        {
            /*Assert.AreEqual(true, validDocument.IsValid);
            Assert.AreEqual(0, validDocument.Notifications.Count);*/
        }
    }
}
