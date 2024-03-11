using Domain.Entities;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Domain.Tests.BankAccountTests
{
    public class InterestEarningAccountTests : BanckAccountBaseTests
    {

        private InterestEarningAccount _interestEarningAccount;

        public InterestEarningAccountTests()
        {
            _interestEarningAccount = new InterestEarningAccount(name, initialBalance);
        }

        [Fact]
        public void ItShouldCreateInterestEarningAccount()
        {
            using var assertionScope = new AssertionScope();
            _interestEarningAccount.Balance.Should().Be(initialBalance);
            _interestEarningAccount.Owner.Should().Be(name);
        }

    }
}
