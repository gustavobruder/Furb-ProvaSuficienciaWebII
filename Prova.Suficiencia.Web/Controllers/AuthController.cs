using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prova.Suficiencia.Web.Services;
using Prova.Suficiencia.Web.Views;

namespace Prova.Suficiencia.Web.Controllers
{
    [AllowAnonymous]
    public class AuthController : ApiController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        [Route("token")]
        public AutenticacaoViewModel Authenticate()
        {
            var (token, expiration) = _authService.GerarJwtAuth();

            return new AutenticacaoViewModel
            {
                Token = token,
                DataExpiracao = expiration,
            };
        }
    }
}