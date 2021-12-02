using AutoMapper;
using Stoqui.Kernel.Domain.Objects;
using Stoqui.Stock.Application.Interfaces.Models;
using Stoqui.Stock.Domain.Entities;

namespace Stoqui.Stock.Application.Queries.MapperProfile;

public class ProductStockProfile : Profile
{
    public ProductStockProfile()
    {
        CreateMap<Product, ProductStockModel>();
        CreateMap<PagingResult<Product>, PagingResult<ProductStockModel>>();
    }
}