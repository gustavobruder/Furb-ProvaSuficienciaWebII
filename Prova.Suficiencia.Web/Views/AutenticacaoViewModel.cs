using System;
using System.Text.Json.Serialization;

namespace Prova.Suficiencia.Web.Views
{
    public class AutenticacaoViewModel
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("dataExpiracao")]
        public DateTime DataExpiracao { get; set; }
    }
}