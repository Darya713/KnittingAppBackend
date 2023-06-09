var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

builder.Services.AddLogging(builder =>
{
    builder.AddConsole();
    builder.AddDebug();
    builder.AddAzureWebAppDiagnostics();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(builder =>
    builder.WithOrigins("https://knittingapp-react.azurewebsites.net", "http://localhost:3000", "https://localhost:3000")
        .AllowAnyMethod()
        .AllowCredentials());

app.UseAuthorization();

app.MapControllers();

app.Run();
