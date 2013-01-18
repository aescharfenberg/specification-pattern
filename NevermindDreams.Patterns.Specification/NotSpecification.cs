using System;

namespace NevermindDreams.Patterns.Specification
{
    /// <summary>
    /// A specification that is satisfied by negating the specification provided.
    /// </summary>
    internal class NotSpecification<TSubject> : ISpecification<TSubject>
    {
        private readonly ISpecification<TSubject> specification;

        /// <summary>
        /// The specification to use as the basis for the <see cref="NotSpecification{TSubject}"/>.
        /// </summary>
        public ISpecification<TSubject> Specification
        {
            get { return specification; }
        }

        /// <summary>
        /// Creates a new <see cref="NotSpecification{TSubject}"/> from the specification provided.
        /// </summary>
        /// <param name="specification">The specification to use as the basis for the new <see cref="NotSpecification{TSubject}"/>.</param>
        public NotSpecification(ISpecification<TSubject> specification)
        {
            if (specification == null)
                throw new ArgumentNullException("specification");

            this.specification = specification;
        }

        /// <summary>
        /// Determines whether or not the <see cref="NotSpecification{TSubject}"/>
        /// is satisifed by the subject provided.
        /// </summary>
        /// <param name="subject">The subject for which satisfaction is to be determined.</param>
        /// <returns>true if basis specification is not satisifed by the subject provided; false if the basis specification is satisfied by the subject provided</returns>
        public bool IsSatisfiedBy(TSubject subject)
        {
            return !Specification.IsSatisfiedBy(subject);
        }
    }
}