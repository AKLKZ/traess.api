using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Traess.Api.Contracts;
using Traess.Domain.Common;
using Traess.Domain.Entities;

namespace Traess.Api.Common;

public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Error, ProblemDetails>();

        CreateMap<TractorUnit, TractorUnitResponse>();
        CreateMap<CreateTractorUnitRequest, TractorUnit>();
        CreateMap<UpdateTractorUnitRequest, TractorUnit>();

        CreateMap<Trailer, TrailerResponse>();
        CreateMap<CreateTrailerRequest, Trailer>();
        CreateMap<UpdateTrailerRequest, Trailer>();

        CreateMap<Driver, DriverResponse>();
        CreateMap<CreateDriverRequest, Driver>();
        CreateMap<UpdateDriverRequest, Driver>();

        CreateMap<TransportOrder, TransportOrderResponse>();
        CreateMap<CreateTransportOrderRequest, TransportOrder>();
        CreateMap<UpdateTransportOrderRequest, TransportOrder>();

        CreateMap<Trip, TripResponse>();
        CreateMap<CreateTripRequest, Trip>();
        CreateMap<UpdateTripRequest, Trip>();
    }
}
