using AutoFixture;

namespace Domain.Tests
{

    public class DomainTestsBase
    {
        protected static Fixture Fixture { get; }
         
        static DomainTestsBase()
        {
            Fixture = new Fixture();
        }
    }
}
