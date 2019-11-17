namespace DWG.Patterns.Specification
{
    public class AndSpecification<TSubject> : BinaryCompositeSpecification<TSubject>
    {
        public AndSpecification(ISpecification<TSubject> leftSpecification, ISpecification<TSubject> rightSpecification)
            : base(leftSpecification, rightSpecification)
        {
        }

        public override bool IsSatisfiedBy(TSubject subject)
        {
            return LeftSpecification.IsSatisfiedBy(subject) && RightSpecification.IsSatisfiedBy(subject);
        }
    }
}
