// The 'using' statement for Test Tools is in GlobalUsings.cs
// using Microsoft.VisualStudio.TestTools.UnitTesting;

using BankAccountNS;

namespace BankTests;

[TestClass]
public class BankAccountTests
{
    public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";
    public const string DebitAmountLessThanZeroMessage = "Debit amount is less than zero";
    [TestMethod]
    public void Debit_WithValidAmount_UpdatesBalance()
    {
        // Arrange
        var beginningBalance = 11.99;
        var debitAmount = 4.55;
        var expected = 7.44;
        BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

        // Act
        account.Debit(debitAmount);

        // Assert
        var actual = account.Balance;
        Assert.AreEqual(expected, actual, delta: 0.001, "Account not debited correctly");
    }
    [TestMethod]
    public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
    {
        // Arrange
        var beginningBalance = 11.99;
        var debitAmount = 20.0;
        BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

        // Act
        try
        {
            account.Debit(debitAmount);
        }
        catch (System.ArgumentOutOfRangeException e)
        {
            // Assert
            StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
            return;
        }

        Assert.Fail("The expected exception was not thrown.");
    }
}