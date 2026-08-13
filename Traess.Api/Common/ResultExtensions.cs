using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Traess.Domain.Common;

namespace Traess.Api.Common;

public static class ResultExtensions
{
    public static Result<TDest> MapData<TSource, TDest>(this Result<TSource> result, Func<TSource, TDest> selector)
    {
        return result.IsSuccess
            ? Result<TDest>.Success(selector(result.Data))
            : result.PropagateFail<TDest>();
    }

    public static IResult ToHttpResult(this Result result, IMapper mapper)
    {
        return result.IsSuccess
            ? Results.NoContent()
            : ToProblem(result.Errors[0], mapper);
    }

    public static IResult ToHttpResult<T>(this Result<T> result, IMapper mapper)
    {
        return result.IsSuccess
            ? Results.Ok(result.Data)
            : ToProblem(result.Errors[0], mapper);
    }

    public static IResult ToCreatedHttpResult<T>(this Result<T> result, IMapper mapper, Func<T, string> locationFactory)
    {
        return result.IsSuccess
            ? Results.Created(locationFactory(result.Data), result.Data)
            : ToProblem(result.Errors[0], mapper);
    }

    private static IResult ToProblem(Error error, IMapper mapper)
    {
        var problemDetails = mapper.Map<ProblemDetails>(error);
        return Results.Problem(problemDetails);
    }
}
