using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stoqui.Kernel.Domain.Exceptions;
using Stoqui.Stock.Domain.Entities;
using System;

namespace Stoqui.Stock.Domain.Tests.Entities;

[TestClass]
public class TransactionTests
{

    public static Transaction ValidTransaction => new("Is Valid Description", "Stockist Name", "Requester Name"); 

    [TestMethod]
    public void ShouldReturnSuccessWhenTransactionIsValid()
    {
        Assert.IsNotNull(ValidTransaction);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenDescriptionIsInvalid()
    {
        Assert.ThrowsException<AssertionConcernException>(() =>
        {
            Transaction transaction = new(string.Empty, "Stockist Name", "Requester Namer");
        });
    }


    [TestMethod]
    public void ShouldReturnSuccessWhenStockistIsInvalid()
    {
        Assert.ThrowsException<AssertionConcernException>(() =>
        {
            Transaction transaction = new("Is Valid Description", string.Empty, "Requester Name");
        });
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenRequesterIsInvalid()
    {
        Assert.ThrowsException<AssertionConcernException>(() =>
        {
            Transaction transaction = new("Is Valid Description", "Stockist Name", string.Empty);
        });
    }
}

