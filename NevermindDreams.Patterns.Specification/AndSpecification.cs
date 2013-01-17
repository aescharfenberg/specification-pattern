using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NevermindDreams.Patterns.Specification
{
    class AndSpecification<TSubject> : CompositeSpecification<TSubject>
    {
        public AndSpecification(IEnumerable<ISpecification<TSubject>> specifications)
            : base(specifications)
        {
        }

        public override bool IsSatisfiedBy(TSubject subject)
        {
            return Specifications.All((specification) => specification.IsSatisfiedBy(subject));
        }
    }
}
