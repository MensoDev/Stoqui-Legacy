using AutoMapper;
using Stoqui.Stock.Application.Interfaces.Models;
using Stoqui.Stock.Domain.Entities;

namespace Stoqui.Stock.Application.Queries.MapperProfile;

public class TransactionTopicProfile : Profile
{
    public TransactionTopicProfile()
    {
        CreateMap<TransactionTopic, TransactionTopicModel>();
    }
}