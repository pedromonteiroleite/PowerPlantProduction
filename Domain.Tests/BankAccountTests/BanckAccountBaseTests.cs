using AutoFixture;
using Domain.Entities;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Domain.Tests.BankAccountTests
{
    public class BanckAccountBaseTests : DomainTestsBase
    {

        protected string name = Fixture.Create<string>();
        protected decimal initialBalance = Fixture.Create<decimal>();
        protected BankAccount bankAccount;

        public BanckAccountBaseTests()
        {
            bankAccount = new BankAccount(name, initialBalance);
        }

        [Fact]
        public void ItShouldCreateBankAccount()
        {
            using var assertionScope = new AssertionScope();
            bankAccount.Balance.Should().Be(initialBalance);
            bankAccount.Owner.Should().Be(name);
        }

    }
}
