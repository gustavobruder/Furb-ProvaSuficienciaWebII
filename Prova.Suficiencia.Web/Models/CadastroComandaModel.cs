using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Prova.Suficiencia.Web.Models
{
    public class CadastroComandaModel
    {
        [JsonPropertyName("idUsuario")]
        public int IdUsuario { get; set; }

        [JsonPropertyName("nomeUsuario")]
        public string NomeUsuario { get; set; }

        [JsonPropertyName("telefoneUsuario")]
        public string TelefoneUsuario { get; set; }

        [JsonPropertyName("produtos")]
        public IList<CadastroProdutoModel> Produtos { get; set; }

        public CadastroComandaModel()
        {
            Produtos = new List<CadastroProdutoModel>();
        }
    }

    public class CadastroProdutoModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [JsonPropertyName("preco")]
        public double Preco { get; set; }
    }
}