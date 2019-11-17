using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DWG.Patterns.Specification.Tests.Unit
{
    [TestClass]
    public class PredicateSpecificationTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PredicateSpecification_Constructor_PredicateNull_Exception()
        {
            // ReSharper disable ObjectCreationAsStatement
            new PredicateSpecification<string>(null);
            // ReSharper restore ObjectCreationAsStatement
        }

        [TestMethod]
        public void PredicateSpecification_PredicateTrue_True()
        {
            var specification = new PredicateSpecification<string>(s => true);
            Assert.AreEqual(true, specification.IsSatisfiedBy("test"));
        }

        [TestMethod]
        public void PredicateSpecification_PredicateFalse_False()
        {
            var specification = new PredicateSpecification<string>(s => false);
            Assert.AreEqual(false, specification.IsSatisfiedBy("test"));
        }
    }
}
