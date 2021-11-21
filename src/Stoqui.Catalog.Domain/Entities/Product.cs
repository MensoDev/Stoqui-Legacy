using Stoqui.Kernel.Domain.Objects;

namespace Stoqui.Catalog.Domain.Entities;

public class Product : Entity, IAggregateRoot
{
    public Product(string name, string description)
    {
        Name = name;
        Description = description;

        Validate();
    }

    public string Name { get; private set; }
    public string Description { get; private set; }

    protected override void Validate()
    {
        AssertionConcern.NotEmpty(Name, "Product.Name is required");
        AssertionConcern.NotEmpty(Description, "Product.Description is required");
    }
}

