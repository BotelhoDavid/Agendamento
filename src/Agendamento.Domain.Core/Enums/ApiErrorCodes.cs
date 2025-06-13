using Agendamento.Domain.Core.Attributes;
using Microsoft.AspNetCore.Http;

namespace Agendamento.Domain.Core.Enum
{
    public enum ApiErrorCodes
    {
        #region Excecao default

        /* O valor default necessita ficar no inicio do enum para evitar problemas
         * com o reinicio da enumeracao, o que causa a exibicao do codigo diferente do desejado.*/

        /// <summary>
        /// Erro inesperado.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status500InternalServerError)]
        [Description("Erro inesperado.", "Contate o administrador do sistema.")]
        UNEXPC = 0,

        #endregion Excecao default

        #region 400 Status (Bad request)

        /// <summary>
        /// Usuário e/ou senha inválidos.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status400BadRequest)]
        [Description("Usuário e/ou senha inválidos.")]
        INVLOP,

        #endregion 400 Status (Bad request)

        #region 401 Status (Unauthorized)

        /// <summary>
        /// Usuário ou senha inválidos.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status401Unauthorized)]
        [Description("Usuário ou senha inválidos.")]
        INVUSPASS,

        #endregion 401 Status (Unauthorized)

        #region 404 Status (Not found)

        /// <summary>
        /// Recurso não encontrado.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status404NotFound)]
        [Description("Recurso não encontrado.")]
        NOTFND,

        /// <summary>
        /// Não foi possível encontrar as configurações do Token JWT.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status404NotFound)]
        [Description("Não foi possível encontrar as configurações do Token JWT.")]
        APKYCONFGREQ,

        #endregion 404 Status (Not found)

        #region 409 Status (Conflict)

        /// <summary>
        /// CPF já cadastrado
        /// </summary>
        [HttpStatusCode(StatusCodes.Status409Conflict)]
        [Description("CPF já cadastrado")]
        CPFEXIST,

        #endregion 409 Status (Conflict)
    }
}