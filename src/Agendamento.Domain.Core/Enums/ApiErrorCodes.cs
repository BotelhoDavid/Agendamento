using Agendamento.Domain.Core.Attributes;
using Microsoft.AspNetCore.Http;

namespace Agendamento.Domain.Core.Enum
{
    public enum ApiErrorCodes
    {
        #region 400 Status (Bad request)

        /// <summary>
        /// E-mail não confirmado.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status400BadRequest)]
        [Description("E-mail não confirmado.")]
        ENOTCONF,

        /// <summary>
        /// Conta do usuário inativa.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status400BadRequest)]
        [Description("Conta do usuário inativa.")]
        CTUSINT,

        /// <summary>
        /// Perfil base não pode ser alterado
        /// </summary>
        [HttpStatusCode(StatusCodes.Status400BadRequest)]
        [Description("Perfil base não pode ser alterado.")]
        PBNPSA,

        /// <summary>
        /// O Id informado é inválido.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status400BadRequest)]
        [Description("O Id informado é inválido.")]
        INVID,

        /// <summary>
        /// Erro no versionamento da Api.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status400BadRequest)]
        [Description("Erro no versionamento da Api.")]
        ERRVERAPI,

        /// <summary>
        /// A ApiKey informada é inválida.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status400BadRequest)]
        [Description("A ApiKey informada é inválida.")]
        INVAPKY,

        /// <summary>
        /// Senha já utilizada.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status400BadRequest)]
        [Description("Senha já utilizada.")]
        ALUPAS,

        /// <summary>
        /// Erros de validação no ModelState.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status400BadRequest)]
        [Description("Erros de validação no ModelState.")]
        MODNOTVALD,

        /// <summary>
        /// Versão da API não suportada.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status400BadRequest)]
        [Description("Versão da API não suportada.")]
        NOTSUPAPIVERS,

        /// <summary>
        /// O usuário não possui e-mail cadastrado.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status400BadRequest)]
        [Description("O usuário não possui e-mail cadastrado.")]
        NOTFNDEMUS,

        /// <summary>
        /// Login e e-mail não conferem.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status400BadRequest)]
        [Description("Login e e-mail não conferem.")]
        LOGEMAILUS,

        /// <summary>
        /// O login informado é inválido.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status400BadRequest)]
        [Description("O login informado é inválido.")]
        INVLOG,

        /// <summary>
        /// Preencha os logins para continuar.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status400BadRequest)]
        [Description("Preencha os logins para continuar.")]
        LOGSREQ,

        /// <summary>
        /// Senha entre uma das 5 últimas utilizadas anteriormente, escolha outra senha.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status400BadRequest)]
        [Description("Senha entre uma das 5 últimas utilizadas anteriormente, escolha outra senha.")]
        ALUPASFIVELAST,

        /// <summary>
        /// O CPF informado é inválido.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status400BadRequest)]
        [Description("O CPF informado é inválido.")]
        INVCPF,

        /// <summary>
        /// O Perfil informado é inválido.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status400BadRequest)]
        [Description("O Perfil informado é inválido.")]
        INVPERFIL,

        /// <summary>
        /// A Escola informada é inválida.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status400BadRequest)]
        [Description("A Escola informada é inválida.")]
        INVESCOLA,

        /// <summary>
        /// A Cidade informada é inválida.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status400BadRequest)]
        [Description("A Cidade informada é inválida.")]
        INVCIDADE,

        /// <summary>
        /// As senhas precisam ser idênticas.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status400BadRequest)]
        [Description("As senhas precisam ser idênticas.")]
        SENDIV,

        /// <summary>
        /// A senha antiga é inválida
        /// </summary>
        [HttpStatusCode(StatusCodes.Status400BadRequest)]
        [Description("A senha antiga é inválida.")]
        SENANTINV,

        /// <summary>
        /// No mímino 6 caracteres, com ao menos uma letra e um número.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status400BadRequest)]
        [Description("No mímino 6 caracteres, com ao menos uma letra e um número.")]
        SENINV,

        /// <summary>
        /// Token inválido.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status400BadRequest)]
        [Description("Token inválido.")]
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
        /// Usuário ou senha inválidos.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status401Unauthorized)]
        [Description("Usuário ou senha inválidos.")]
        INVUSPASS,

        /// <summary>
        /// Senha expirada.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status401Unauthorized)]
        [Description("Senha expirada.")]
        EXPPASS,

        /// <summary>
        /// Tentativas excedidas de autenticação, aguarde e tente novamente mais tarde.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status401Unauthorized)]
        [Description("Tentativas excedidas de autenticação, aguarde e tente novamente mais tarde.")]
        LCKLOG,

        #endregion

        #region 403 Status (Forbidden)

        /// <summary>
        /// Sem permissão para acessar o recurso.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status403Forbidden)]
        [Description("Sem permissão para acessar o recurso.")]
        NOTALLW,

        /// <summary>
        /// O perfil base não pode ser alterado.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status403Forbidden)]
        [Description("O perfil base não pode ser alterado.")]
        PERBANPDALT,

        /// <summary>
        /// Você não possui permissão para acesso ao recurso.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status403Forbidden)]
        [Description("Você não possui permissão para acesso ao recurso.")]
        HASNOTPRMIS,

        #endregion

        #region 404 Status (Not found)

        /// <summary>
        /// Recurso não encontrado.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status404NotFound)]
        [Description("Recurso não encontrado.")]
        NOTFND,

        /// <summary>
        /// Usuário não encontrado para o login informado.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status404NotFound)]
        [Description("Usuário não encontrado para o login informado.")]
        USNOTFNDBYLOG,

        /// <summary>
        /// Usuário não encontrado para o e-mail informado.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status404NotFound)]
        [Description("Usuário não encontrado para o e-mail informado.")]
        USNOTFNDBYMAIL,
        /// <summary>
        /// Usuário não encontrado para o e-mail informado.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status404NotFound)]
        [Description("Usuário não encontrado para o e-mail e escola informado.")]
        USNOTFNDBYMAILESCOLA,

        /// <summary>
        /// Usuário não encontrado para o e-mail informado na escola atual.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status404NotFound)]
        [Description("Usuário não encontrado para o e-mail informado na escola atual.")]
        USNOTFNDBYMAILESC,

        /// <summary>
        /// E-mail não confirmado.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status404NotFound)]
        [Description("E-mail não confirmado.")]
        EMLNAOCNFRM,

        /// <summary>
        /// Usuário não encontrado para o CPF informado.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status404NotFound)]
        [Description("Usuário não encontrado para o CPF informado.")]
        USNOTFNDBYCPF,

        /// <summary>
        /// Nenhum usuário encontrado com o id informado.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status404NotFound)]
        [Description("Nenhum usuário encontrado com o id informado.")]
        USNOTFNDBYID,


        /// <summary>
        /// Não foi possível encontrar as configurações do Token JWT.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status404NotFound)]
        [Description("Não foi possível encontrar as configurações do Token JWT.")]
        APKYCONFGREQ,

        /// <summary>
        /// CEP não Encontrado.
        /// </summary>
        [HttpStatusCode(404)]
        [Description("CEP não encontrado")]
        CEPNOTF,

        /// <summary>
        /// Nenhum usuário encontrado.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status404NotFound)]
        [Description("Nenhum usuário encontrado.")]
        USNOTFND,

        #endregion

        #region 409 Status (Conflict)

        /// <summary>
        /// Login já cadastrado.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status409Conflict)]
        [Description("Login já cadastrado.")]
        ALULOG,

        /// <summary>
        /// Esse e-mail já existe, verifique o perfil completo na lista de usuários
        /// </summary>
        [HttpStatusCode(StatusCodes.Status409Conflict)]
        [Description("Esse e-mail já existe, verifique o perfil completo na lista de usuários.", "Usuário já existe!")]
        EMAILEXIST,

        /// <summary>
        /// CPF já cadastrado, verifique o perfil completo na lista de usuários
        /// </summary>
        [HttpStatusCode(StatusCodes.Status409Conflict)]
        [Description("CPF já cadastrado, verifique o perfil completo na lista de usuários", "Usuário já existe!")]
        CPFEXIST,

        /// <summary>
        /// Solicite ao aluno que procure a instituição para solicitar a baixa da sua matrícula na plataforma.
        /// Após a remoção do vínculo, teste o cadastro novamente.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status409Conflict)]
        [Description("Solicite ao aluno que procure a instituição para solicitar a baixa da sua matrícula na plataforma." +
            "Após a remoção do vínculo, teste o cadastro novamente.", "Usuário vinculado a outra escola!")]
        CPFEXISTOTRESCL,

        /// <summary>
        /// Esse e-mail já existe, verifique o perfil completo na lista de usuários
        /// </summary>
        [HttpStatusCode(StatusCodes.Status409Conflict)]
        [Description("Esse e-mail já existe, verifique o perfil completo na lista de usuários")]
        USUARIOEXIST,

        /// <summary>
        /// Perfil já cadastrado.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status409Conflict)]
        [Description("Perfil já cadastrado.")]
        ALUPFL,

        /// <summary>
        /// Nenhum usuário encontrado com o id informado.
        /// </summary>
        [Description("Não é permitido excluir um Tipo de Perfil com usuários associados.")]
        [HttpStatusCode(StatusCodes.Status409Conflict)]
        NOTPERMEXC,

        #endregion

        #region 500 Status (Internal Server Error)

        /// <summary>
        /// Erro ao criar usuário pelo Identity.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status500InternalServerError)]
        [Description("Erro ao criar usuário pelo Identity.")]
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
        /// Senha entre uma das 5 últimas utilizadas anteriormente, escolha outra senha.
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
        /// Erro ao alterar senha pelo Identity na criação do usuário.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status500InternalServerError)]
        [Description("Erro ao alterar senha pelo Identity na criação do usuário.")]
        CHGPASCRIDNT,

        /// <summary>
        /// Erros de validação no ModelState.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status500InternalServerError)]
        [Description("Erro no reset de senha pelo Identity.")]
        RESTPASS,

        /// <summary>
        /// Erro ao executar operação no banco de dados.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status500InternalServerError)]
        [Description("Erro ao executar operação no banco de dados.")]
        ERROPBD,

        /// <summary>
        /// Erro ao cadastrar Perfil.
        /// </summary>
        [HttpStatusCode(StatusCodes.Status500InternalServerError)]
        [Description("Erro ao cadastrar Perfil.")]
        ERRCADPRFL,

        /// <summary>
        /// Erro ao alterar permissões do perfil
        /// </summary>
        [HttpStatusCode(StatusCodes.Status500InternalServerError)]
        [Description("Erro ao alterar permissões do perfil.")]
        ERPEPERM,

        /// <summary>
        /// Problema na leitura do token
        /// </summary>
        [HttpStatusCode(StatusCodes.Status500InternalServerError)]
        [Description("Problema na leitura do token.")]
        DECTOK,

        /// <summary>
        /// Erro na geração do token
        /// </summary>
        [HttpStatusCode(StatusCodes.Status500InternalServerError)]
        [Description("Erro na geração do token.")]
        ERRGERTOK,

        #endregion
    }
}
