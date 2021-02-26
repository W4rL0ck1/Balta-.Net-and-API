using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;
using System;

namespace PaymentContext.Tests
{
    [TestClass]
    public class SubscriptionHandlerTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenNameIsInvalid()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand();

            command.FirstName = "Renato";
            command.LastName = "Santos";
            command.Document = "99999999999999999";
            command.Email = "hello@balta.io2";
            command.BarCode = "123456789";
            command.BoletoNumber = "123456789";
            command.PaymentNumber = "123121";
            command.PaidDate = DateTime.Now;
            command.ExpireDate = DateTime.Now.AddMonths(1);
            command.Total = 60;
            command.TotalPaid = 60;
            command.Payer = "O Brabo";
            command.PayerDocument = "12345678911";
            command.PayerDocumentType = EDocumentType.CPF;
            command.PayerEmail = "Renato@123.com";
            command.Street = "asdasdasd";
            command.Number = "123";
            command.City = "Cubatão";
            command.Neighborhood = "Bolsao brabo";
            command.State = "Sao Paulo";
            command.Country = "Brazil";
            command.ZipCodet = "1123311";

            handler.Handle(command);
            Assert.AreEqual(false, handler.Valid);
        }
    }
}