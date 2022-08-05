using System.Collections.Generic;
using System.Threading.Tasks;
using Prova.Suficiencia.Web.Entities;
using Prova.Suficiencia.Web.Projecoes;

namespace Prova.Suficiencia.Web.DAOs
{
    public interface IComandasDAO
    {
        Task<IList<ListagemComandaProjecao>> ObterComandasParaListagem();
        Task<DetalhesComandaProjecao> ObterComandaParaDetalhes(int id);
        Task<Comanda> ObterComanda(int id);
        Task<int> InserirComanda(Comanda comanda);
        Task AtualizarComanda(Comanda comanda);
        Task RemoverComanda(Comanda comanda);
    }
}