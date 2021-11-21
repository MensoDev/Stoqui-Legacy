using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stoqui.Catalog.Domain.Entities;
using Stoqui.Kernel.Domain.Exceptions;

namespace Stoqui.Catalog.Domain.Tests.Entities;

[TestClass]
public class ProductTests
{
    [TestMethod]
    public void MustReturnSuccessIfProductIsInvalid()
    {
        Assert.ThrowsException<AssertionConcernException>(() =>
        {
            var product = new Product(string.Empty, "");
        });
    }

    [TestMethod]
    public void MustReturnSuccessIfProductDescriptionIsInvalid()
    {
        Assert.ThrowsException<AssertionConcernException>(() =>
        {
            var product = new Product("Roteador TP-Link 750", string.Empty);
        });
    }

    [TestMethod]
    public void MustReturnSuccessIfProductNameIsInvalid()
    {
        Assert.ThrowsException<AssertionConcernException>(() =>
        {
            var product = new Product(string.Empty, "Roteador bom");
        });
    }

    public void MustReturnSuccessIfProductIsValid()
    {
        var product = new Product("Roteador Mikrotik 3011", "Bom para gerenciamento de rede de pequenas empresas");

        Assert.IsNotNull(product, "Product is required, Error on create a instance");
    }

}

