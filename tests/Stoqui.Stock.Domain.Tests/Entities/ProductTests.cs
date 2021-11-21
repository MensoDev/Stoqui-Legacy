
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stoqui.Kernel.Domain.Exceptions;
using Stoqui.Stock.Domain.Entities;
using System;

namespace Stoqui.Stock.Domain.Tests.Entities;

[TestClass]
public class ProductTests
{
    [TestMethod]
    public void ShouldReturnSuccessWhenProductIdIsValid()
    {
        Product product = new(Guid.NewGuid());
        Assert.IsNotNull(product, "Product not instantiated, required a valid  ID:Guid");
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenProductIdIsInvalid()
    {
        Assert.ThrowsException<AssertionConcernException>(() =>
        {
            Product product = new(Guid.Empty);
        });
    }
}

