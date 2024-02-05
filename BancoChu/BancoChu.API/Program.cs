using BancoChu.API;
using BancoChu.API.TokenSettings;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureOptions<GetJwtSettings>();
builder.Services.ConfigureOptions<JwtOptionsSettings>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddBearerToken();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapBankChuEndpoints();

app.Run();