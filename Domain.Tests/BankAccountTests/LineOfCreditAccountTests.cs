using Domain.Entities;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Domain.Tests.BankAccountTests
{
    public class LineOfCreditAccountTests : BanckAccountBaseTests
    {

        private LineOfCreditAccount _lineOfCreditAccount;

        public LineOfCreditAccountTests()
        {
            _lineOfCreditAccount = new LineOfCreditAccount(name, initialBalance);
        }

        [Fact]
        public void ItShouldCreateLineOfCreditAccount()
        {
            using var assertionScope = new AssertionScope();
            _lineOfCreditAccount.Balance.Should().Be(initialBalance);
            _lineOfCreditAccount.Owner.Should().Be(name);
        }

    }
}
