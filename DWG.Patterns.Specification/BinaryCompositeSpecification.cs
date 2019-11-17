using System;

namespace DWG.Patterns.Specification
{
    public abstract class BinaryCompositeSpecification<TSubject> : ISpecification<TSubject>
    {
        public ISpecification<TSubject> LeftSpecification { get; }

        public ISpecification<TSubject> RightSpecification { get; }

        protected BinaryCompositeSpecification(ISpecification<TSubject> leftSpecification, ISpecification<TSubject> rightSpecification)
        {
            this.LeftSpecification = leftSpecification ?? throw new ArgumentNullException(nameof(leftSpecification));
            this.RightSpecification = rightSpecification ?? throw new ArgumentNullException(nameof(rightSpecification));
        }

        public abstract bool IsSatisfiedBy(TSubject subject);
    }
}