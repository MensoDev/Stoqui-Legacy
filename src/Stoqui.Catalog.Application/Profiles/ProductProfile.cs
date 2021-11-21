using AutoMapper;
using Stoqui.Catalog.Application.Interfaces.Models;
using Stoqui.Catalog.Domain.Entities;

namespace Stoqui.Catalog.Application.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductModel>();
    }
}

