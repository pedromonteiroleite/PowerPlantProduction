using AutoFixture;
using Domain.Entities;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Domain.Tests.BankAccountTests
{
    public class GiftCardAccountTests : BanckAccountBaseTests
    {

        private decimal _monthlyDeposit = Fixture.Create<decimal>();
        private GiftCardAccount _giftCardAccount;

        public GiftCardAccountTests()
        {
            _giftCardAccount = new GiftCardAccount(name, initialBalance, _monthlyDeposit);
        }

        [Fact]
        public void ItShouldCreateGiftCardAccount()
        {
            using var assertionScope = new AssertionScope();
            _giftCardAccount.Balance.Should().Be(initialBalance);
            _giftCardAccount.Owner.Should().Be(name);
        }

        [Theory]
        [InlineData(20, "get expensive cofee")]
        [InlineData(50, "buy groceries")]
        public void ItShouldMakeWithdrawal(decimal amount, string note)
        {
            _giftCardAccount = new GiftCardAccount(name, 100, 50);

            _giftCardAccount.MakeWithdrawal(amount, DateTime.Now, note);
        }


    }
}
