using GrpcService;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGrpcClient<CityProtoService.CityProtoServiceClient>(opt =>
{
    opt.Address = new Uri("http://localhost:5258");
});
var app = builder.Build();
app.MapGet("/", () => "Hello World!");
app.MapGet("/grpc", (CityProtoService.CityProtoServiceClient grpcClient) =>
{
    var response = grpcClient.SayCity(new CityRequest
    {
        City = "Bangkok"
    });
    return response.Message;
});

app.Run();