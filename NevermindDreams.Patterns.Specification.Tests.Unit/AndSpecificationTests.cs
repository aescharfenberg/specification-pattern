using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace NevermindDreams.Patterns.Specification.Tests.Unit
{
    [TestClass]
    public class AndSpecificationTests
    {
        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public void AndSpecification_Constructor_LeftSpecificationNull_Exception()
        {
            var mockRepository = new MockRepository(MockBehavior.Strict);
            var specification = mockRepository.CreateSpecificationMock<string>();
            // ReSharper disable ObjectCreationAsStatement
            new AndSpecification<string>(null, specification);
            // ReSharper restore ObjectCreationAsStatement
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AndSpecification_Constructor_RightSpecificationNull_Exception()
        {
            var mockRepository = new MockRepository(MockBehavior.Strict);
            var specification = mockRepository.CreateSpecificationMock<string>();
            // ReSharper disable ObjectCreationAsStatement
            new AndSpecification<string>(specification, null);
            // ReSharper restore ObjectCreationAsStatement
        }

        [TestMethod]
        public void AndSpecification_IsSatisfiedBy_TruthTable()
        {
            AssertIsSatisfiedBy(true, true, true);
            AssertIsSatisfiedBy(true, false, false);
            AssertIsSatisfiedBy(false, true, false);
            AssertIsSatisfiedBy(false, false, false);
        }

        private void AssertIsSatisfiedBy(bool leftSpecificationIsSatisfiedBy, bool rightSpecificationIsSatisfiedBy,
                                         bool expected)
        {
            var mockRepository = new MockRepository(MockBehavior.Strict);
            var leftSpecification = mockRepository.CreateSpecificationMock<string>(leftSpecificationIsSatisfiedBy);
            var rightSpecification = !leftSpecificationIsSatisfiedBy
                                         ? mockRepository.CreateSpecificationMock<string>()
                                         : mockRepository.CreateSpecificationMock<string>(
                                             rightSpecificationIsSatisfiedBy);
            var specification = new AndSpecification<string>(leftSpecification, rightSpecification);
            Assert.AreEqual(expected, specification.IsSatisfiedBy("test"));
            mockRepository.VerifyAll();
        }
    }
}