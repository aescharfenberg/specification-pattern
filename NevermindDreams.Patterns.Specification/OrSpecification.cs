using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NevermindDreams.Patterns.Specification
{
    class OrSpecification<TSubject> : CompositeSpecification<TSubject>
    {
        public OrSpecification(IEnumerable<ISpecification<TSubject>> specifications)
            : base(specifications)
        {
        }

        public override bool IsSatisfiedBy(TSubject subject)
        {
            return Specifications.Any((specification) => specification.IsSatisfiedBy(subject));
        }
    }
}
