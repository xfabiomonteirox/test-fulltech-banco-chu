using BancoChu.API;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();

builder.Services.AddInfrastructure();

builder.Services.AddPersistence(builder.Configuration);

builder.Services.AddAuthenticationAndAuthorization();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.ApplyMigrations();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapBankChuEndpoints();

app.Run();