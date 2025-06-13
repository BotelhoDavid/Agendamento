using Agendamento.Application.Interfaces;
using Agendamento.Domain.Core.DTO;
using Agendamento.Domain.Core.Enum;
using Agendamento.Domain.Core.Settings;
using Agendamento.Infra.CrossCutting.ExceptionHandler.Extensions;
using Agendamento.Infrastructure.Dapper.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Agendamento.Application.Services
{
    public class AutenticacaoAppService : IAutenticacaoAppService
    {
        private readonly IConfiguration _configuration;
        private readonly IAgendamentoDapperManager _dapperAgendamento;

        public AutenticacaoAppService(IConfiguration configuration, IAgendamentoDapperManager dapperAgendamento)
        {
            _configuration = configuration;
            _dapperAgendamento = dapperAgendamento;
        }

        public async Task<string> AutenticarAsync(string email, string senha)
        {
            TokenConfigurationsSettings _tokenConfigurations = _configuration.GetSection(nameof(TokenConfigurationsSettings))?.Get<TokenConfigurationsSettings>();

            UsuarioDTO usuario = await _dapperAgendamento.ObterUsuarioPorEmailAsync(email) ?? throw new ApiException(ApiErrorCodes.INVUSPASS);

            bool senhaValida = BCrypt.Net.BCrypt.Verify(senha, usuario.SenhaHash);

            if (!senhaValida)
                throw new ApiException(ApiErrorCodes.INVLOP);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString())
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_tokenConfigurations.Secret));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "Agendamento",
                audience: "Agendamento",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
