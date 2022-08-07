using System.Collections.Generic;
using System.Threading.Tasks;
using Prova.Suficiencia.Web.Models;
using Prova.Suficiencia.Web.Views;

namespace Prova.Suficiencia.Web.Services
{
    public interface IComandasServices
    {
        Task<IList<ListagemComandaViewModel>> ListarComandas();
        Task<DetalhesComandaViewModel> DetalharComanda(int id);
        Task<CadastroComandaViewModel> CadastrarComanda(CadastroComandaModel model);
        Task AtualizarComanda(int id, AtualizacaoComandaModel model);
        Task<RemocaoComandaViewModel> RemoverComanda(int id);
    }
}