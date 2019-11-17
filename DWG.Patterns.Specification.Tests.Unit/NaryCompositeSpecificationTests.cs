using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DWG.Patterns.Specification.Tests.Unit
{
    [TestClass]
    public class NaryCompositeSpecificationTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NaryCompositeSpecification_Constructor_SpecificationsNull_Exception()
        {
            // ReSharper disable ObjectCreationAsStatement
            new NaryCompositeSpecificationFake<string>(null);
            // ReSharper restore ObjectCreationAsStatement
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NaryCompositeSpecification_Constructor_SpecificationsSingleNull_Exception()
        {
            // ReSharper disable ObjectCreationAsStatement
            new NaryCompositeSpecificationFake<string>(new ISpecification<string>[] { null });
            // ReSharper restore ObjectCreationAsStatement
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NaryCompositeSpecification_Constructor_SpecificationsMultipleWithNull_Exception()
        {
            var mockRepository = new MockRepository(MockBehavior.Strict);
            var specification1 = mockRepository.CreateSpecificationMock<string>();
            // ReSharper disable ObjectCreationAsStatement
            new NaryCompositeSpecificationFake<string>(new[] { specification1, null });
            // ReSharper restore ObjectCreationAsStatement
        }

        [TestMethod]
        public void NaryCompositeSpecification_Constructor_SpecificationsEmpty_SpecificationsEmpty()
        {
            var specification = new NaryCompositeSpecificationFake<string>(new ISpecification<string>[0]);
            Assert.IsNotNull(specification.Specifications);
            Assert.AreEqual(0, specification.Specifications.Count());
        }

        [TestMethod]
        public void NaryCompositeSpecification_Constructor_SpecificationsSingle_SpecificationsContainsOneAndOnlyOneSpecification()
        {
            var mockRepository = new MockRepository(MockBehavior.Strict);
            var singleSpecification = mockRepository.CreateSpecificationMock<string>();
            var specification = new NaryCompositeSpecificationFake<string>(new[] { singleSpecification });
            Assert.IsNotNull(specification.Specifications);
            Assert.AreEqual(1, specification.Specifications.Count());
            Assert.AreEqual(singleSpecification, specification.Specifications.ElementAt(0));
            mockRepository.VerifyAll();
        }

        [TestMethod]
        public void NaryCompositeSpecification_Constructor_SpecificationsMultiple_SpecificationsContainsAll()
        {
            var mockRepository = new MockRepository(MockBehavior.Strict);
            var specification1 = mockRepository.CreateSpecificationMock<string>();
            var specification2 = mockRepository.CreateSpecificationMock<string>();
            var specification3 = mockRepository.CreateSpecificationMock<string>();
            var specification = new NaryCompositeSpecificationFake<string>(new[] { specification1, specification2, specification3 });
            Assert.IsNotNull(specification.Specifications);
            Assert.AreEqual(3, specification.Specifications.Count());
            Assert.IsTrue(specification.Specifications.Contains(specification1));
            Assert.IsTrue(specification.Specifications.Contains(specification2));
            Assert.IsTrue(specification.Specifications.Contains(specification3));
            mockRepository.VerifyAll();
        }

        private class NaryCompositeSpecificationFake<TSubject> : NaryCompositeSpecification<TSubject>
        {
            public NaryCompositeSpecificationFake(IEnumerable<ISpecification<TSubject>> specifications)
                : base(specifications)
            {
                
            }

            public override bool IsSatisfiedBy(TSubject subject)
            {
                throw new NotImplementedException();
            }
        }
    }
}
