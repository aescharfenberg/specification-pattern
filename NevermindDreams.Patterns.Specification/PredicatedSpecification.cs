using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NevermindDreams.Patterns.Specification
{
    /// <summary>
    /// An implementation of the specification pattern that uses a lambda function
    /// as the predicate for determining satisfaction.
    /// </summary>
    public class PredicatedSpecification<TSubject> : ISpecification<TSubject>
    {
        private readonly Func<TSubject, bool> predicate;

        /// <summary>
        /// Creates a new <see cref="PredicatedSpecification"/> that uses the predicate
        /// provided for determining satisfaction.
        /// </summary>
        /// <param name="predicate">The predicate to use for determining satisfaction.</param>
        public PredicatedSpecification(Func<TSubject, bool> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException("predicate");

            this.predicate = predicate;
        }

        public bool IsSatisfiedBy(TSubject subject)
        {
            return predicate(subject);
        }
    }
}
