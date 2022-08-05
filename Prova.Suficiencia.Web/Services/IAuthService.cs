using System;

namespace Prova.Suficiencia.Web.Services
{
    public interface IAuthService
    {
        (string, DateTime) GerarJwtAuth();
    }
}