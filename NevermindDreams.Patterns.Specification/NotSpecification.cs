using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NevermindDreams.Patterns.Specification
{
    class NotSpecification<TSubject> : PredicatedSpecification<TSubject>
    {
        /// <summary>
        /// Creates a new <see cref="NotSpecification"/> from the specification provided.
        /// </summary>
        /// <param name="specification">The specification to use as the basis for the new <see cref="NotSpecification"/>.</param>
        public NotSpecification(ISpecification<TSubject> specification)
            : base((subject) => !specification.IsSatisfiedBy(subject))
        {
            if (specification == null)
                throw new ArgumentNullException("specification");
        }
    }
}
