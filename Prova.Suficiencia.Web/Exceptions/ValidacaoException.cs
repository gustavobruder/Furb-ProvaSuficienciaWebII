using System;

namespace Prova.Suficiencia.Web.Exceptions
{
    public class ValidacaoException : Exception
    {
        public ValidacaoException(string mensagem) : base(mensagem)
        {
        }
    }
}