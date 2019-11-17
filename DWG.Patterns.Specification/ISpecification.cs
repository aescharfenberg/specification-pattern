namespace DWG.Patterns.Specification
{
    public interface ISpecification<in TSubject>
    {
        bool IsSatisfiedBy(TSubject subject);
    }
}
