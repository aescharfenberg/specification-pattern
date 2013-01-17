using System;
using System.Collections.Generic;
using System.Linq;

namespace NevermindDreams.Patterns.Specification
{
    internal abstract class BinaryCompositeSpecification<TSubject> : ISpecification<TSubject>
    {
        private readonly ISpecification<TSubject> leftSpecification;
        private readonly ISpecification<TSubject> rightSpecification;

        public ISpecification<TSubject> LeftSpecification
        {
            get { return leftSpecification; }
        }

        public ISpecification<TSubject> RightSpecification
        {
            get { return rightSpecification; }
        }

        protected BinaryCompositeSpecification(ISpecification<TSubject> leftSpecification,
                                               ISpecification<TSubject> rightSpecification)
        {
            if (leftSpecification == null)
                throw new ArgumentNullException("leftSpecification");

            if (rightSpecification == null)
                throw new ArgumentNullException("rightSpecification");

            this.leftSpecification = leftSpecification;
            this.rightSpecification = rightSpecification;
        }

        public abstract bool IsSatisfiedBy(TSubject subject);
    }
}