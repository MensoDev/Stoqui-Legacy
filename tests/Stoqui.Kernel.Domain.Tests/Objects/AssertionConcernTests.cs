using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stoqui.Kernel.Domain.Exceptons;
using Stoqui.Kernel.Domain.Objects;
using System;

namespace Stoqui.Kernel.Domain.Tests.Objects;

[TestClass]
public class AssertionConcernTests
{
    [TestMethod]
    public void ShouldReturnSuccessWhen_NotNullObjectHasNoFail()
    {
        var obj = new object();
        AssertionConcern.NotNull(obj, "");
    }

    [TestMethod]
    public void ShouldReturnSuccessWhen_NotNullObjectHasFail()
    {
        Assert.ThrowsException<AssertionConcernException>(() =>
        {
            AssertionConcern.NotNull(null, string.Empty);
        });
    }

    [TestMethod]
    public void ShouldReturnSuccessWhen_NotEmptyStringHasNoFail()
    {
        AssertionConcern.NotEmpty("Não falha", "Teste de Falha");
    }

    [TestMethod]
    public void ShouldReturnSuccessWhen_NotEmptyStringHasFail()
    {

        Assert.ThrowsException<AssertionConcernException>(() =>
        {
            AssertionConcern.NotEmpty("   ", string.Empty);
        });

        Assert.ThrowsException<AssertionConcernException>(() =>
        {
            AssertionConcern.NotEmpty("", string.Empty);
        });

        Assert.ThrowsException<AssertionConcernException>(() =>
        {
            AssertionConcern.NotEmpty(string.Empty, string.Empty);
        });        
    }

    [TestMethod]
    public void ShouldReturnSuccessWhen_NotEmptyGuidHasNoFail()
    {
        AssertionConcern.NotEmpty(Guid.NewGuid(), "Teste de Falha"); 
    }

    [TestMethod]
    public void ShouldReturnSuccessWhen_NotEmptyGuidHasFail()
    {

        Assert.ThrowsException<AssertionConcernException>(() =>
        {
            AssertionConcern.NotEmpty(Guid.Empty, string.Empty);
        });

        Assert.ThrowsException<AssertionConcernException>(() =>
        {
            AssertionConcern.NotEmpty(new Guid(), string.Empty);
        });
    }

    [TestMethod]
    public void ShouldReturnSuccessWhen_GreaterThanIntHasNoFail()
    {
        AssertionConcern.GreaterThan(10, -0, "Unit Test");
    }

    [TestMethod]
    public void ShouldReturnSuccessWhen_GreaterThanIntHasFail()
    {
        Assert.ThrowsException<AssertionConcernException>(() =>
        {
            AssertionConcern.GreaterThan(-0, 10, "Unit Test");
        });
    }


}

