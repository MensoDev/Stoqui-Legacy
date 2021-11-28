using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stoqui.Kernel.Domain.Exceptions;
using Stoqui.Stock.Domain.Entities;

namespace Stoqui.Stock.Domain.Tests.Entities;


[TestClass]
public class TransactionItemTests
{

    public static TransactionItem ValidTransactionItem => 
        new(ProductTests.ValidProduct, TransactionTests.ValidTransaction, 1, TransactionTopicTests.ValidTopic);

    [TestMethod]
    public void ShouldReturnSuccessWhenTransactionItemIsValid()
    {
        TransactionItem transactionItem = 
            new(ProductTests.ValidProduct, TransactionTests.ValidTransaction, 1, TransactionTopicTests.ValidTopic);

        Assert.IsNotNull(transactionItem);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenTransactionIsInvalid()
    {
        Assert.ThrowsException<AssertionConcernException>(() =>
        {
            TransactionItem item = new(ProductTests.ValidProduct, null, 1, TransactionTopicTests.ValidTopic);
        });
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenProductIsInvalid()
    {
        Assert.ThrowsException<AssertionConcernException>(() =>
        {
            TransactionItem item = new(null, TransactionTests.ValidTransaction, 1, TransactionTopicTests.ValidTopic);
        });
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenAmountIsInvalid()
    {
        Assert.ThrowsException<AssertionConcernException>(() =>
        {
            TransactionItem item = new(ProductTests.ValidProduct, TransactionTests.ValidTransaction, 0, TransactionTopicTests.ValidTopic);
        });
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenAmountLasThanZero()
    {
        Assert.ThrowsException<AssertionConcernException>(() =>
        {
            TransactionItem item = new(ProductTests.ValidProduct, TransactionTests.ValidTransaction, -1, TransactionTopicTests.ValidTopic);
        });
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenTopicIsInvalid()
    {
        Assert.ThrowsException<AssertionConcernException>(() =>
        {
            TransactionItem item = new(ProductTests.ValidProduct, TransactionTests.ValidTransaction, -1, null);
        });
    }


}

