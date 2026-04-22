using GoodHamburger.API.Middlewares;
using GoodHamburger.Application;
using GoodHamburger.Infrastructure.Seeds;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddExceptionHandler<GlobalExceptionMiddleware>();
builder.Services.AddProblemDetails();

builder.Services.AddContext()
                .AddMapperServices()
                .AddMediatorServices();


builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.WithOrigins(
                "http://localhost:5001",
                "https://localhost:5001",
                "http://localhost:5101",
                "https://localhost:5101"
              )
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

await app.Services.ApplySeedAsync();

app.UseCors("CorsPolicy");
app.UseExceptionHandler();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
