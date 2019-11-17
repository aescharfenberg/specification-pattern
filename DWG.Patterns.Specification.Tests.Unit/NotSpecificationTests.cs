using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DWG.Patterns.Specification.Tests.Unit
{
    [TestClass]
    public class NotSpecificationTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NotSpecification_Constructor_SpecificationNull_Exception()
        {
            // ReSharper disable ObjectCreationAsStatement
            new NotSpecification<string>(null);
            // ReSharper restore ObjectCreationAsStatement
        }

        [TestMethod]
        public void NotSpecification_IsSatisfiedBy_SpecificationTrue_False()
        {
            var mockRepository = new MockRepository(MockBehavior.Strict);
            var singleSpecification = mockRepository.CreateSpecificationMock<string>(true);
            var specification = new NotSpecification<string>(singleSpecification);
            Assert.AreEqual(false, specification.IsSatisfiedBy("test"));
            mockRepository.VerifyAll();
        }

        [TestMethod]
        public void NotSpecification_IsSatisfiedBy_SpecificationFalse_True()
        {
            var mockRepository = new MockRepository(MockBehavior.Strict);
            var singleSpecification = mockRepository.CreateSpecificationMock<string>(false);
            var specification = new NotSpecification<string>(singleSpecification);
            Assert.AreEqual(true, specification.IsSatisfiedBy("test"));
            mockRepository.VerifyAll();
        }
    }
}
