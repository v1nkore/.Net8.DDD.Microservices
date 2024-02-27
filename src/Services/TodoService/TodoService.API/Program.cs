using TodoService.API.Endpoints;
using TodoService.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddDataServices(builder.Configuration);
    
    builder.Services.AddReadRepositories();
    builder.Services.AddWriteRepositories();
}

var app = builder.Build();
{
    app.MapTodoEndpoints();
}

app.Run();