using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DWG.Patterns.Specification.Tests.Unit
{
    [TestClass]
    public class OrSpecificationTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void OrSpecification_Constructor_LeftSpecificationNull_Exception()
        {
            var mockRepository = new MockRepository(MockBehavior.Strict);
            var specification = mockRepository.CreateSpecificationMock<string>();
            // ReSharper disable ObjectCreationAsStatement
            new OrSpecification<string>(null, specification);
            // ReSharper restore ObjectCreationAsStatement
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void OrSpecification_Constructor_RightSpecificationNull_Exception()
        {
            var mockRepository = new MockRepository(MockBehavior.Strict);
            var specification = mockRepository.CreateSpecificationMock<string>();
            // ReSharper disable ObjectCreationAsStatement
            new OrSpecification<string>(specification, null);
            // ReSharper restore ObjectCreationAsStatement
        }

        [TestMethod]
        public void OrSpecification_IsSatisfiedBy_TruthTable()
        {
            AssertIsSatisfiedBy(true, true, true);
            AssertIsSatisfiedBy(true, false, true);
            AssertIsSatisfiedBy(false, true, true);
            AssertIsSatisfiedBy(false, false, false);
        }

        private void AssertIsSatisfiedBy(bool leftSpecificationIsSatisfiedBy, bool rightSpecificationIsSatisfiedBy,
                                         bool expected)
        {
            var mockRepository = new MockRepository(MockBehavior.Strict);
            var leftSpecification = mockRepository.CreateSpecificationMock<string>(leftSpecificationIsSatisfiedBy);
            var rightSpecification = leftSpecificationIsSatisfiedBy
                                         ? mockRepository.CreateSpecificationMock<string>()
                                         : mockRepository.CreateSpecificationMock<string>(rightSpecificationIsSatisfiedBy);
            var specification = new OrSpecification<string>(leftSpecification, rightSpecification);
            Assert.AreEqual(expected, specification.IsSatisfiedBy("test"));
            mockRepository.VerifyAll();
        }
    }
}