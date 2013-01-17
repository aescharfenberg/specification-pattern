using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NevermindDreams.Patterns.Specification
{
    public interface ISpecification<in TSubject>
    {
        bool IsSatisfiedBy(TSubject subject);
    }
}
