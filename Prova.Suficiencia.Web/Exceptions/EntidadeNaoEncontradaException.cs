using System;

namespace Prova.Suficiencia.Web.Exceptions
{
    public class EntidadeNaoEncontradaException : Exception
    {
        public EntidadeNaoEncontradaException(string mensagem) : base(mensagem)
        {
        }
    }
}