using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;
using System;
using System.Collections.Generic;
using PaymentContext.Domain.Queries;
using System.Linq;

namespace PaymentContext.Tests
{
    [TestClass]
    public class StudentQueriesTests
    {
        private IList<Student> _students;

        public StudentQueriesTests()
        {
            for(var i=0;i<= 10;i++)
            {
                _students.Add(new Student(
                    new Name("Aluno", i.ToString()),
                    new Document("11111111111" + i.ToString(),EDocumentType.CPF),
                    new Email(i.ToString() + "balta.io")
                    ));
            }
        }

        [TestMethod]
        public void ShouldReturnNullWhenDocumentNotExists()
        {
           var exp = StudentQueries.GetStudentInfo("12345678911");
           var studn = _students.AsQueryable().Where(exp).FirstOrDefault();

           Assert.AreEqual(null,studn);
        }

         [TestMethod]
        public void ShouldReturnStudentWhenDocumentExists()
        {
           var exp = StudentQueries.GetStudentInfo("12345678911");
           var studn = _students.AsQueryable().Where(exp).FirstOrDefault();

           Assert.AreNotEqual(null,studn);
        }
    }
}