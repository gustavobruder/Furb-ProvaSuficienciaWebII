using System.Collections.Generic;

namespace Prova.Suficiencia.Web.Entities
{
    public class Comanda
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string TelefoneUsuario { get; set; }
        public virtual IList<Produto> Produtos { get; set; }
    }
}