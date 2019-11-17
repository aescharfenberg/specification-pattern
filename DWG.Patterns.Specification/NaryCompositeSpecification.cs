using System;
using System.Collections.Generic;
using System.Linq;

namespace DWG.Patterns.Specification
{
    public abstract class NaryCompositeSpecification<TSubject> : ISpecification<TSubject>
    {
        private readonly IEnumerable<ISpecification<TSubject>> specifications;

        public IEnumerable<ISpecification<TSubject>> Specifications
        {
            get { return specifications; }
        }

        protected NaryCompositeSpecification(IEnumerable<ISpecification<TSubject>> specifications)
        {
            if (specifications == null)
                throw new ArgumentNullException("specifications");

            specifications = specifications.ToArray();

            if (specifications.Any(specification => specification == null))
                throw new ArgumentException("specifications contains a null value");

            this.specifications = specifications;
        }

        public abstract bool IsSatisfiedBy(TSubject subject);
    }
}