
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stoqui.Kernel.Domain.Exceptions;
using Stoqui.Stock.Domain.Entities;
using System;

namespace Stoqui.Stock.Domain.Tests.Entities;

[TestClass]
public class ProductTests
{

    public static Product ValidProduct => new(Guid.NewGuid(), "Product for tests");


    [TestMethod]
    public void ShouldReturnSuccessWhenProductIdIsValid()
    {
        Product product = new(Guid.NewGuid(), "Product is tests");
        Assert.IsNotNull(product, "Product not instantiated, required a valid  ID:Guid");
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenProductIdIsInvalid()
    {
        Assert.ThrowsException<AssertionConcernException>(() =>
        {
            Product product = new(Guid.Empty, "Product for tests");
        });
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenProductNameIsInvalid()
    {
        Assert.ThrowsException<AssertionConcernException>(() =>
        {
            Product product = new(Guid.NewGuid(), string.Empty);
        });
    }
}

