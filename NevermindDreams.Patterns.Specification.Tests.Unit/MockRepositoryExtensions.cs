using Moq;

namespace NevermindDreams.Patterns.Specification.Tests.Unit
{
    internal static class MockRepositoryExtensions
    {
        public static ISpecification<TSubject> CreateSpecificationMock<TSubject>(this MockRepository mockRepository)
        {
            return mockRepository.Create<ISpecification<TSubject>>().Object;
        }

        public static ISpecification<TSubject> CreateSpecificationMock<TSubject>(this MockRepository mockRepository,
                                                                                 bool isSatisfied)
        {
            var result = mockRepository.Create<ISpecification<TSubject>>();
            result.Setup(m => m.IsSatisfiedBy(It.IsAny<TSubject>()))
                  .Returns(isSatisfied);
            return result.Object;
        }
    }
}