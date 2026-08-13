using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Traess.Domain.Common;

namespace Traess.Api.Common;

public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Error, ProblemDetails>();
    }
}
