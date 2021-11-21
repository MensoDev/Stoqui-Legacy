using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stoqui.Kernel.Domain.Exceptons;
using Stoqui.Stock.Domain.Entities;
using System;

namespace Stoqui.Stock.Domain.Tests.Entities;

[TestClass]
public class TransactionTests
{
    [TestMethod]
    public void ShouldReturnSuccessWhenTransactionIsValid()
    {
        Transaction transaction = new("Está é uma descrição valida", new Product(Guid.NewGuid()), 1, "Emerson", "Tony");
        Assert.IsNotNull(transaction);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenDescriptionIsInvalid()
    {
        Assert.ThrowsException<AssertionConcernException>(() =>
        {
            Transaction transaction = new(string.Empty, new Product(Guid.NewGuid()), 1, "Emerson", "Tony");
        });
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenProductIsInvalid()
    {
        Assert.ThrowsException<AssertionConcernException>(() =>
        {
            Transaction transaction = new("Descrição valida", new Product(Guid.Empty), 1, "Emerson", "Tony");
        });
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenAmountIsInvalid()
    {
        Assert.ThrowsException<AssertionConcernException>(() =>
        {
            Transaction transaction = new("Descrição valida", new Product(Guid.NewGuid()), -1, "Emerson", "Tony");
        });
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenStockistIsInvalid()
    {
        Assert.ThrowsException<AssertionConcernException>(() =>
        {
            Transaction transaction = new("Descrição valida", new Product(Guid.NewGuid()), -1, string.Empty, "Tony");
        });
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenRequesterIsInvalid()
    {
        Assert.ThrowsException<AssertionConcernException>(() =>
        {
            Transaction transaction = new("Descrição valida", new Product(Guid.NewGuid()), -1, "Emerson", string.Empty);
        });
    }
}

