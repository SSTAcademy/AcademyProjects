using MyFirstApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("copyright.json", false, true);
var config = builder.Configuration;
config.GetValue<string>("AllowedHosts");
builder.Services.AddSingleton<IConfiguration>(config);
var secretKey = config.GetValue<string>("SecretKey");
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExceptionHandler>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
