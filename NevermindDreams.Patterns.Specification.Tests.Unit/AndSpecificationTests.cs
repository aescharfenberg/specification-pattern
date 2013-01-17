using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace NevermindDreams.Patterns.Specification.Tests.Unit
{
    [TestClass]
    public class AndSpecificationTests
    {
        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public void AndSpecification_Constructor_SpecificationsNull_Exception()
        {
            // ReSharper disable ObjectCreationAsStatement
            new AndSpecification<string>(null);
            // ReSharper restore ObjectCreationAsStatement
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AndSpecification_Constructor_SpecificationsSingleNull_Exception()
        {
            // ReSharper disable ObjectCreationAsStatement
            new AndSpecification<string>(new ISpecification<string>[] { null });
            // ReSharper restore ObjectCreationAsStatement
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AndSpecification_Constructor_SpecificationsMultipleWithNull_Exception()
        {
            var mockRepository = new MockRepository(MockBehavior.Strict);
            var specification1 = mockRepository.CreateSpecificationMock<string>();
            // ReSharper disable ObjectCreationAsStatement
            new AndSpecification<string>(new[] { specification1, null });
            // ReSharper restore ObjectCreationAsStatement
        }

        [TestMethod]
        public void AndSpecification_Constructor_SpecificationsEmpty_SpecificationsEmpty()
        {
            var specification = new AndSpecification<string>(new ISpecification<string>[0]);
            Assert.IsNotNull(specification.Specifications);
            Assert.AreEqual(0, specification.Specifications.Count());
        }

        [TestMethod]
        public void AndSpecification_Constructor_SpecificationsSingle_SpecificationsContainsOneAndOnlyOneSpecification()
        {
            var mockRepository = new MockRepository(MockBehavior.Strict);
            var singleSpecification = mockRepository.CreateSpecificationMock<string>();
            var specification = new AndSpecification<string>(new[] {singleSpecification});
            Assert.IsNotNull(specification.Specifications);
            Assert.AreEqual(1, specification.Specifications.Count());
            Assert.AreEqual(singleSpecification, specification.Specifications.ElementAt(0));
            mockRepository.VerifyAll();
        }

        [TestMethod]
        public void AndSpecification_Constructor_SpecificationsMultiple_SpecificationsContainsAll()
        {
            var mockRepository = new MockRepository(MockBehavior.Strict);
            var specification1 = mockRepository.CreateSpecificationMock<string>();
            var specification2 = mockRepository.CreateSpecificationMock<string>();
            var specification3 = mockRepository.CreateSpecificationMock<string>();
            var specification = new AndSpecification<string>(new[] { specification1, specification2, specification3 });
            Assert.IsNotNull(specification.Specifications);
            Assert.AreEqual(3, specification.Specifications.Count());
            Assert.IsTrue(specification.Specifications.Contains(specification1));
            Assert.IsTrue(specification.Specifications.Contains(specification2));
            Assert.IsTrue(specification.Specifications.Contains(specification3));
            mockRepository.VerifyAll();
        }

        [TestMethod]
        public void AndSpecification_IsSatisfiedBy_SpecificaitionsEmpty_True()
        {
            var specification = new AndSpecification<string>(new ISpecification<string>[0]);
            Assert.AreEqual(true, specification.IsSatisfiedBy("test"));
        }

        [TestMethod]
        public void AndSpecification_IsSatisfiedBy_SpecificationsSingleTrue_True()
        {
            var mockRepository = new MockRepository(MockBehavior.Strict);
            var singleSpecification = mockRepository.CreateSpecificationMock<string>(true);
            var specification = new AndSpecification<string>(new[] { singleSpecification });
            Assert.AreEqual(true, specification.IsSatisfiedBy("test"));
            mockRepository.VerifyAll();
        }

        [TestMethod]
        public void AndSpecification_IsSatisfiedBy_SpecificationsSingleFalse_False()
        {
            var mockRepository = new MockRepository(MockBehavior.Strict);
            var singleSpecification = mockRepository.CreateSpecificationMock<string>(false);
            var specification = new AndSpecification<string>(new[] { singleSpecification });
            Assert.AreEqual(false, specification.IsSatisfiedBy("test"));
            mockRepository.VerifyAll();
        }

        [TestMethod]
        public void AndSpecification_IsSatisfiedBy_SpecificationsMultipleAllTrue_True()
        {
            var mockRepository = new MockRepository(MockBehavior.Strict);
            var specification1 = mockRepository.CreateSpecificationMock<string>(true);
            var specification2 = mockRepository.CreateSpecificationMock<string>(true);
            var specification3 = mockRepository.CreateSpecificationMock<string>(true);
            var specification = new AndSpecification<string>(new[] { specification1, specification2, specification3 });
            Assert.AreEqual(true, specification.IsSatisfiedBy("test"));
            mockRepository.VerifyAll();
        }

        [TestMethod]
        public void AndSpecification_IsSatisfiedBy_SpecificationsMultipleFirstFalse_False()
        {
            var mockRepository = new MockRepository(MockBehavior.Strict);
            var specification1 = mockRepository.CreateSpecificationMock<string>(false);
            var specification2 = mockRepository.CreateSpecificationMock<string>(); // will not be checked
            var specification3 = mockRepository.CreateSpecificationMock<string>(); // will not be checked
            var specification = new AndSpecification<string>(new[] { specification1, specification2, specification3 });
            Assert.AreEqual(false, specification.IsSatisfiedBy("test"));
            mockRepository.VerifyAll();
        }

        [TestMethod]
        public void AndSpecification_IsSatisfiedBy_SpecificationsMultipleLastFalse_False()
        {
            var mockRepository = new MockRepository(MockBehavior.Strict);
            var specification1 = mockRepository.CreateSpecificationMock<string>(true);
            var specification2 = mockRepository.CreateSpecificationMock<string>(true);
            var specification3 = mockRepository.CreateSpecificationMock<string>(false);
            var specification = new AndSpecification<string>(new[] { specification1, specification2, specification3 });
            Assert.AreEqual(false, specification.IsSatisfiedBy("test"));
            mockRepository.VerifyAll();
        }
    }
}