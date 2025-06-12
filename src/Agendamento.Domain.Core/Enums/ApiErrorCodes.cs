using Agendamento.Domain.Core.Attributes;
using Microsoft.AspNetCore.Http;

namespace Agendamento.Domain.Core.Enum
{
    public enum ApiErrorCodes
    {
        #region 400 Status (Bad request)

        /// <summary>
        /// E-mail n�o confirmado.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status400BadRequest)]
        [Description("E-mail n�o confirmado.")]
        ENOTCONF,

        /// <summary>
        /// Conta do usu�rio inativa.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status400BadRequest)]
        [Description("Conta do usu�rio inativa.")]
        CTUSINT,

        /// <summary>
        /// Perfil base n�o pode ser alterado
        /// </summary>
        [HttpStatusCode(StatusCodes.Status400BadRequest)]
        [Description("Perfil base n�o pode ser alterado.")]
        PBNPSA,

        /// <summary>
        /// O Id informado � inv�lido.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status400BadRequest)]
        [Description("O Id informado � inv�lido.")]
        INVID,

        /// <summary>
        /// Erro no versionamento da Api.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status400BadRequest)]
        [Description("Erro no versionamento da Api.")]
        ERRVERAPI,

        /// <summary>
        /// A ApiKey informada � inv�lida.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status400BadRequest)]
        [Description("A ApiKey informada � inv�lida.")]
        INVAPKY,

        /// <summary>
        /// Senha j� utilizada.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status400BadRequest)]
        [Description("Senha j� utilizada.")]
        ALUPAS,

        /// <summary>
        /// Erros de valida��o no ModelState.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status400BadRequest)]
        [Description("Erros de valida��o no ModelState.")]
        MODNOTVALD,

        /// <summary>
        /// Vers�o da API n�o suportada.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status400BadRequest)]
        [Description("Vers�o da API n�o suportada.")]
        NOTSUPAPIVERS,

        /// <summary>
        /// O usu�rio n�o possui e-mail cadastrado.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status400BadRequest)]
        [Description("O usu�rio n�o possui e-mail cadastrado.")]
        NOTFNDEMUS,

        /// <summary>
        /// Login e e-mail n�o conferem.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status400BadRequest)]
        [Description("Login e e-mail n�o conferem.")]
        LOGEMAILUS,

        /// <summary>
        /// O login informado � inv�lido.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status400BadRequest)]
        [Description("O login informado � inv�lido.")]
        INVLOG,

        /// <summary>
        /// Preencha os logins para continuar.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status400BadRequest)]
        [Description("Preencha os logins para continuar.")]
        LOGSREQ,

        /// <summary>
        /// Senha entre uma das 5 �ltimas utilizadas anteriormente, escolha outra senha.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status400BadRequest)]
        [Description("Senha entre uma das 5 �ltimas utilizadas anteriormente, escolha outra senha.")]
        ALUPASFIVELAST,

        /// <summary>
        /// O CPF informado � inv�lido.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status400BadRequest)]
        [Description("O CPF informado � inv�lido.")]
        INVCPF,

        /// <summary>
        /// O Perfil informado � inv�lido.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status400BadRequest)]
        [Description("O Perfil informado � inv�lido.")]
        INVPERFIL,

        /// <summary>
        /// A Escola informada � inv�lida.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status400BadRequest)]
        [Description("A Escola informada � inv�lida.")]
        INVESCOLA,

        /// <summary>
        /// A Cidade informada � inv�lida.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status400BadRequest)]
        [Description("A Cidade informada � inv�lida.")]
        INVCIDADE,

        /// <summary>
        /// As senhas precisam ser id�nticas.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status400BadRequest)]
        [Description("As senhas precisam ser id�nticas.")]
        SENDIV,

        /// <summary>
        /// A senha antiga � inv�lida
        /// </summary>
        [HttpStatusCode(StatusCodes.Status400BadRequest)]
        [Description("A senha antiga � inv�lida.")]
        SENANTINV,

        /// <summary>
        /// No m�mino 6 caracteres, com ao menos uma letra e um n�mero.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status400BadRequest)]
        [Description("No m�mino 6 caracteres, com ao menos uma letra e um n�mero.")]
        SENINV,

        /// <summary>
        /// Token inv�lido.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status400BadRequest)]
        [Description("Token inv�lido.")]
        INVTOK,

        /// <summary>
        /// Nenhum material informado.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status400BadRequest)]
        [Description("Nenhum material informado.")]
        NENMATINF,

        #endregion

        #region 401 Status (Unauthorized)

        /// <summary>
        /// Usu�rio ou senha inv�lidos.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status401Unauthorized)]
        [Description("Usu�rio ou senha inv�lidos.")]
        INVUSPASS,

        /// <summary>
        /// Senha expirada.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status401Unauthorized)]
        [Description("Senha expirada.")]
        EXPPASS,

        /// <summary>
        /// Tentativas excedidas de autentica��o, aguarde e tente novamente mais tarde.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status401Unauthorized)]
        [Description("Tentativas excedidas de autentica��o, aguarde e tente novamente mais tarde.")]
        LCKLOG,

        #endregion

        #region 403 Status (Forbidden)

        /// <summary>
        /// Sem permiss�o para acessar o recurso.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status403Forbidden)]
        [Description("Sem permiss�o para acessar o recurso.")]
        NOTALLW,

        /// <summary>
        /// O perfil base n�o pode ser alterado.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status403Forbidden)]
        [Description("O perfil base n�o pode ser alterado.")]
        PERBANPDALT,

        /// <summary>
        /// Voc� n�o possui permiss�o para acesso ao recurso.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status403Forbidden)]
        [Description("Voc� n�o possui permiss�o para acesso ao recurso.")]
        HASNOTPRMIS,

        #endregion

        #region 404 Status (Not found)

        /// <summary>
        /// Recurso n�o encontrado.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status404NotFound)]
        [Description("Recurso n�o encontrado.")]
        NOTFND,

        /// <summary>
        /// Usu�rio n�o encontrado para o login informado.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status404NotFound)]
        [Description("Usu�rio n�o encontrado para o login informado.")]
        USNOTFNDBYLOG,

        /// <summary>
        /// Usu�rio n�o encontrado para o e-mail informado.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status404NotFound)]
        [Description("Usu�rio n�o encontrado para o e-mail informado.")]
        USNOTFNDBYMAIL,
        /// <summary>
        /// Usu�rio n�o encontrado para o e-mail informado.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status404NotFound)]
        [Description("Usu�rio n�o encontrado para o e-mail e escola informado.")]
        USNOTFNDBYMAILESCOLA,

        /// <summary>
        /// Usu�rio n�o encontrado para o e-mail informado na escola atual.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status404NotFound)]
        [Description("Usu�rio n�o encontrado para o e-mail informado na escola atual.")]
        USNOTFNDBYMAILESC,

        /// <summary>
        /// E-mail n�o confirmado.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status404NotFound)]
        [Description("E-mail n�o confirmado.")]
        EMLNAOCNFRM,

        /// <summary>
        /// Usu�rio n�o encontrado para o CPF informado.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status404NotFound)]
        [Description("Usu�rio n�o encontrado para o CPF informado.")]
        USNOTFNDBYCPF,

        /// <summary>
        /// Nenhum usu�rio encontrado com o id informado.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status404NotFound)]
        [Description("Nenhum usu�rio encontrado com o id informado.")]
        USNOTFNDBYID,


        /// <summary>
        /// N�o foi poss�vel encontrar as configura��es do Token JWT.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status404NotFound)]
        [Description("N�o foi poss�vel encontrar as configura��es do Token JWT.")]
        APKYCONFGREQ,

        /// <summary>
        /// CEP n�o Encontrado.
        /// </summary>
        [HttpStatusCode(404)]
        [Description("CEP n�o encontrado")]
        CEPNOTF,

        /// <summary>
        /// Nenhum usu�rio encontrado.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status404NotFound)]
        [Description("Nenhum usu�rio encontrado.")]
        USNOTFND,

        #endregion

        #region 409 Status (Conflict)

        /// <summary>
        /// Login j� cadastrado.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status409Conflict)]
        [Description("Login j� cadastrado.")]
        ALULOG,

        /// <summary>
        /// Esse e-mail j� existe, verifique o perfil completo na lista de usu�rios
        /// </summary>
        [HttpStatusCode(StatusCodes.Status409Conflict)]
        [Description("Esse e-mail j� existe, verifique o perfil completo na lista de usu�rios.", "Usu�rio j� existe!")]
        EMAILEXIST,

        /// <summary>
        /// CPF j� cadastrado, verifique o perfil completo na lista de usu�rios
        /// </summary>
        [HttpStatusCode(StatusCodes.Status409Conflict)]
        [Description("CPF j� cadastrado, verifique o perfil completo na lista de usu�rios", "Usu�rio j� existe!")]
        CPFEXIST,

        /// <summary>
        /// Solicite ao aluno que procure a institui��o para solicitar a baixa da sua matr�cula na plataforma.
        /// Ap�s a remo��o do v�nculo, teste o cadastro novamente.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status409Conflict)]
        [Description("Solicite ao aluno que procure a institui��o para solicitar a baixa da sua matr�cula na plataforma." +
            "Ap�s a remo��o do v�nculo, teste o cadastro novamente.", "Usu�rio vinculado a outra escola!")]
        CPFEXISTOTRESCL,

        /// <summary>
        /// Esse e-mail j� existe, verifique o perfil completo na lista de usu�rios
        /// </summary>
        [HttpStatusCode(StatusCodes.Status409Conflict)]
        [Description("Esse e-mail j� existe, verifique o perfil completo na lista de usu�rios")]
        USUARIOEXIST,

        /// <summary>
        /// Perfil j� cadastrado.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status409Conflict)]
        [Description("Perfil j� cadastrado.")]
        ALUPFL,

        /// <summary>
        /// Nenhum usu�rio encontrado com o id informado.
        /// </summary>
        [Description("N�o � permitido excluir um Tipo de Perfil com usu�rios associados.")]
        [HttpStatusCode(StatusCodes.Status409Conflict)]
        NOTPERMEXC,

        #endregion

        #region 500 Status (Internal Server Error)

        /// <summary>
        /// Erro ao criar usu�rio pelo Identity.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status500InternalServerError)]
        [Description("Erro ao criar usu�rio pelo Identity.")]
        CRUSIDNT,

        /// <summary>
        /// Erro ao alterar senha pelo Identity.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status500InternalServerError)]
        [Description("Erro ao alterar senha pelo Identity.")]
        ERALTSEIDNT,

        /// <summary>
        /// Erro inesperado.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status500InternalServerError)]
        [Description("Erro inesperado.", "Contate o administrador do sistema.")]
        UNEXPC,

        /// <summary>
        /// Senha entre uma das 5 �ltimas utilizadas anteriormente, escolha outra senha.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status500InternalServerError)]
        [Description("Erro ao alterar senha.")]
        CHGPASS,

        /// <summary>
        /// Erro ao fazer login.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status500InternalServerError)]
        [Description("Erro ao fazer login.")]
        ERRLOG,

        /// <summary>
        /// Erro ao alterar senha pelo Identity na cria��o do usu�rio.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status500InternalServerError)]
        [Description("Erro ao alterar senha pelo Identity na cria��o do usu�rio.")]
        CHGPASCRIDNT,

        /// <summary>
        /// Erros de valida��o no ModelState.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status500InternalServerError)]
        [Description("Erro no reset de senha pelo Identity.")]
        RESTPASS,

        /// <summary>
        /// Erro ao executar opera��o no banco de dados.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status500InternalServerError)]
        [Description("Erro ao executar opera��o no banco de dados.")]
        ERROPBD,

        /// <summary>
        /// Erro ao cadastrar Perfil.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status500InternalServerError)]
        [Description("Erro ao cadastrar Perfil.")]
        ERRCADPRFL,

        /// <summary>
        /// Erro ao alterar permiss�es do perfil
        /// </summary>
        [HttpStatusCode(StatusCodes.Status500InternalServerError)]
        [Description("Erro ao alterar permiss�es do perfil.")]
        ERPEPERM,

        /// <summary>
        /// Problema na leitura do token
        /// </summary>
        [HttpStatusCode(StatusCodes.Status500InternalServerError)]
        [Description("Problema na leitura do token.")]
        DECTOK,

        /// <summary>
        /// Erro na gera��o do token
        /// </summary>
        [HttpStatusCode(StatusCodes.Status500InternalServerError)]
        [Description("Erro na gera��o do token.")]
        ERRGERTOK,

        #endregion
    }
}
