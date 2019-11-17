using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DWG.Patterns.Specification.Tests.Unit
{
    [TestClass]
    public class SpecificationExtensionsTests
    {
        [TestMethod]
        public void SpecificationExtensions_And_AndSpecificationProduced()
        {
            var mockRepository = new MockRepository(MockBehavior.Strict);
            var specification1 = mockRepository.CreateSpecificationMock<string>();
            var specification2 = mockRepository.CreateSpecificationMock<string>();
            var andSpecification = specification1.And(specification2) as AndSpecification<string>;
            Assert.IsNotNull(andSpecification);
            Assert.AreEqual(specification1, andSpecification.LeftSpecification);
            Assert.AreEqual(specification2, andSpecification.RightSpecification);
        }

        [TestMethod]
        public void SpecificationExtensions_Or_OrSpecificationProduced()
        {
            var mockRepository = new MockRepository(MockBehavior.Strict);
            var specification1 = mockRepository.CreateSpecificationMock<string>();
            var specification2 = mockRepository.CreateSpecificationMock<string>();
            var orSpecification = specification1.Or(specification2) as OrSpecification<string>;
            Assert.IsNotNull(orSpecification);
            Assert.AreEqual(specification1, orSpecification.LeftSpecification);
            Assert.AreEqual(specification2, orSpecification.RightSpecification);
        }

        [TestMethod]
        public void SpecificationExtensions_Not_NotSpecificationProduced()
        {
            var mockRepository = new MockRepository(MockBehavior.Strict);
            var specification = mockRepository.CreateSpecificationMock<string>();
            var notSpecification = specification.Not() as NotSpecification<string>;
            Assert.IsNotNull(notSpecification);
            Assert.AreEqual(specification, notSpecification.Specification);
        }
    }
}
