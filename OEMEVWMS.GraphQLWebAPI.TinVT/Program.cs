using OEMEVWMS.GraphQLWebAPI.TinVT.GraphQL;
using OEMEVWMS.Services.TinVT;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IServiceProviders, ServiceProviders>();

builder.Services.AddGraphQLServer()
    .AddQueryType<Queries>()
    .BindRuntimeType<DateTime, DateTimeType>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseRouting().UseEndpoints(endPoints =>
{
    endPoints.MapGraphQL();
});

app.Run();
