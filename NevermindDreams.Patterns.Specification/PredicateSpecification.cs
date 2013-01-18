using System;

namespace NevermindDreams.Patterns.Specification
{
    /// <summary>
    /// An implementation of the specification pattern that uses a predicate for determining satisfaction.
    /// </summary>
    public class PredicateSpecification<TSubject> : ISpecification<TSubject>
    {
        private readonly Predicate<TSubject> predicate;

        /// <summary>
        /// Creates a new <see cref="PredicateSpecification{TSubject}"/> that uses the predicate
        /// provided for determining satisfaction.
        /// </summary>
        /// <param name="predicate">The predicate to use for determining satisfaction.</param>
        public PredicateSpecification(Predicate<TSubject> predicate)
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