using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stoqui.Kernel.Domain.Exceptions;
using Stoqui.Stock.Domain.Entities;
using Stoqui.Stock.Domain.Enums;

namespace Stoqui.Stock.Domain.Tests.Entities;

[TestClass]
public class TransactionTopicTests
{
    [TestMethod]
    public void ShouldReturnSuccessWhenTransactionTopicNameIsValid()
    {
        TransactionTopic topic = new TransactionTopic("Name The Topic", EStockType.ActiveStock, EStockAction.Input);

        Assert.IsNotNull(topic);
        Assert.AreEqual(topic.Name, "Name The Topic");
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenTransactionTopicNameIsInvalid()
    {
        Assert.ThrowsException<AssertionConcernException>(() =>
        {
            TransactionTopic topic = new TransactionTopic(string.Empty, EStockType.ActiveStock, EStockAction.Input);
        });
    }
}

