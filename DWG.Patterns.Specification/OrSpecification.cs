namespace DWG.Patterns.Specification
{
    public class OrSpecification<TSubject> : BinaryCompositeSpecification<TSubject>
    {
        public OrSpecification(ISpecification<TSubject> leftSpecification,
                               ISpecification<TSubject> rightSpecification)
            : base(leftSpecification, rightSpecification)
        {
        }

        public override bool IsSatisfiedBy(TSubject subject)
        {
            return LeftSpecification.IsSatisfiedBy(subject) || RightSpecification.IsSatisfiedBy(subject);
        }
    }
}
