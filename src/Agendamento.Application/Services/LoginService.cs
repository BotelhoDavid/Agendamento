using Agendamento.Application.Interfaces;

namespace Agendamento.Application.Services
{
    public class LoginService : ILoginService
    {
        public bool Login(string email, string password)
        {
            return email == "admin@teste.com" && password == "123456";
        }
    }
}
