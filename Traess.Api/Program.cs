using Traess.Api.Endpoints;
using Traess.Data.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(cfg => { }, typeof(Program));
builder.Services.AddDataServices(builder.Configuration);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapTractorUnitEndpoints();
app.MapTrailerEndpoints();
app.MapDriverEndpoints();
app.MapTransportOrderEndpoints();
app.MapTripEndpoints();

app.Run();
