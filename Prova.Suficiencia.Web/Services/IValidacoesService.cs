using Prova.Suficiencia.Web.Entities;
using Prova.Suficiencia.Web.Models;
using Prova.Suficiencia.Web.Projecoes;

namespace Prova.Suficiencia.Web.Services
{
    public interface IValidacoesService
    {
        void ValidarSeExiste(int id, Comanda comanda);
        void ValidarSeExiste(int id, DetalhesComandaProjecao comanda);
        void ValidarCamposCadastro(CadastroComandaModel model);
        void ValidarCamposAtualizacaoUsuario(AtualizacaoComandaModel model);
        void ValidarCamposAtualizacaoProdutoInserir(AtualizacaoProdutoModel model);
        void ValidarCamposAtualizacaoProdutoAtualizar(AtualizacaoProdutoModel model);
    }
}