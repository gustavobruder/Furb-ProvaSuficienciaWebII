using System.Text.Json.Serialization;

namespace Prova.Suficiencia.Web.Views
{
    public class RemocaoComandaViewModel
    {
        [JsonPropertyName("success")]
        public SuccessViewModel Success { get; set; }
    }

    public class SuccessViewModel
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }
    }
}