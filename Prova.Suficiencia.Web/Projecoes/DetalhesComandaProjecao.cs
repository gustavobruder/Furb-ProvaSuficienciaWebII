using System.Collections.Generic;

namespace Prova.Suficiencia.Web.Projecoes
{
    public class DetalhesComandaProjecao// todo heranca da listagem?
    {
        public int IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string TelefoneUsuario { get; set; }
        public IList<DetalhesComandaProdutoProjecao> Produtos { get; set; }
    }

    public class DetalhesComandaProdutoProjecao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
    }
}