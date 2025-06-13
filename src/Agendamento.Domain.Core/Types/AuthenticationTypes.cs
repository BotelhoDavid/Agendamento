using Agendamento.Domain.Core.Extensions;

namespace Agendamento.Domain.Core.Types
{
    public class AuthenticationTypes
    {
        public const string ApiKey = "ApiKey";
        public const string JWTBearer = "Bearer";
        public const string Cookies = "Cookies";


        /// <summary>
        /// Utilizando reflection, verifica se no tipo AuthenticationTypes
        /// existe alguma constante com o valor do parâmetro constantName.
        /// </summary>
        /// <param name="constantName">Valor a ser procurado no tipo AuthenticationTypes.</param>
        /// <returns></returns>
        public static bool Contains(string constantName)
        {
            return new AuthenticationTypes().GetType().GetAllPublicConstantValues<string>().Contains(constantName);
        }
    }
}
