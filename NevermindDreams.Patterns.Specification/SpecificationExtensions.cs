using System.Linq;

namespace NevermindDreams.Patterns.Specification
{
    /// <summary>
    /// Extension methods for working with specifications.
    /// </summary>
    public static class SpecificationExtensions
    {
        public static ISpecification<TSubject> And<TSubject>(this ISpecification<TSubject> value,
                                                             ISpecification<TSubject> specification)
        {
            return new AndSpecification<TSubject>(value, specification);
        }

        public static ISpecification<TSubject> Or<TSubject>(this ISpecification<TSubject> value,
                                                            ISpecification<TSubject> specification)
        {
            return new OrSpecification<TSubject>(value, specification);
        }

        public static ISpecification<TSubject> Not<TSubject>(this ISpecification<TSubject> value)
        {
            return new NotSpecification<TSubject>(value);
        }
    }
}