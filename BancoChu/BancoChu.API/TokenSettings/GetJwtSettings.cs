using BancoChu.Infrastructure.Authentication;
using Microsoft.Extensions.Options;

namespace BancoChu.API.TokenSettings;

public class GetJwtSettings(IConfiguration configuration) : IConfigureOptions<JwtOptions>
{
    private const string SectionName = "Jwt";
    private readonly IConfiguration _configuration = configuration;

    public void Configure(JwtOptions options) =>
        _configuration.GetSection(SectionName).Bind(options);
}