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
        /// Usu�rio e/ou senha inv�lidos.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status400BadRequest)]
        [Description("Usu�rio e/ou senha inv�lidos.")]
        INVLOP,

        #endregion 400 Status (Bad request)

        #region 401 Status (Unauthorized)

        /// <summary>
        /// Usu�rio ou senha inv�lidos.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status401Unauthorized)]
        [Description("Usu�rio ou senha inv�lidos.")]
        INVUSPASS,

        #endregion 401 Status (Unauthorized)

        #region 404 Status (Not found)

        /// <summary>
        /// Recurso n�o encontrado.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status404NotFound)]
        [Description("Recurso n�o encontrado.")]
        NOTFND,

        /// <summary>
        /// N�o foi poss�vel encontrar as configura��es do Token JWT.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status404NotFound)]
        [Description("N�o foi poss�vel encontrar as configura��es do Token JWT.")]
        APKYCONFGREQ,

        #endregion 404 Status (Not found)

        #region 409 Status (Conflict)

        /// <summary>
        /// CPF j� cadastrado
        /// </summary>
        [HttpStatusCode(StatusCodes.Status409Conflict)]
        [Description("CPF j� cadastrado")]
        CPFEXIST,

        #endregion 409 Status (Conflict)
    }
}