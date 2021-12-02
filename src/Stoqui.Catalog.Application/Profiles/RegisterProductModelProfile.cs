using AutoMapper;
using Stoqui.Catalog.Application.Interfaces.Models;
using Stoqui.Catalog.Domain.Entities;

namespace Stoqui.Catalog.Application.Profiles;

public class RegisterProductModelProfile : Profile
{
    public RegisterProductModelProfile()
    {
        CreateMap<Product, RegisterProductModel>();
    }
}

