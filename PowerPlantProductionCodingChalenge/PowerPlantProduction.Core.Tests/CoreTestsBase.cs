using AutoFixture;
using AutoFixture.AutoMoq;

namespace PowerPlantProduction.Core.Tests
{
    public abstract class CoreTestsBase<T>
    {
        protected T Service;

        protected static IFixture Fixture { get; } = new Fixture()
    .Customize(new AutoMoqCustomization() { ConfigureMembers = true, GenerateDelegates = true });

        public CoreTestsBase()
        {
            Fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

    }
}
