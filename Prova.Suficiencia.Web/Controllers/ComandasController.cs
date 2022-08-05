using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prova.Suficiencia.Web.Models;
using Prova.Suficiencia.Web.Services;
using Prova.Suficiencia.Web.Views;

namespace Prova.Suficiencia.Web.Controllers
{
    [Authorize]
    public class ComandasController : ApiController
    {
        private readonly IComandasServices _comandasServices;

        public ComandasController(IComandasServices comandasServices)
        {
            _comandasServices = comandasServices;
        }

        [HttpGet]
        public Task<IList<ListagemComandaViewModel>> ListarComandas()
        {
            return _comandasServices.ListarComandas();
        }

        [HttpGet]
        [Route("{id}")]
        public Task<DetalhesComandaViewModel> DetalharComanda([FromRoute] int id)
        {
            return _comandasServices.DetalharComanda(id);
        }

        [HttpPost]
        public Task<CadastroComandaViewModel> CadastrarComanda([FromBody] CadastroComandaModel model)
        {
            return _comandasServices.CadastrarComanda(model);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<object> AtualizarComanda([FromRoute] int id, [FromBody] AtualizacaoComandaModel model)
        {
            return _comandasServices.AtualizarComanda(id, model);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task<RemocaoComandaViewModel> RemoverComanda([FromRoute] int id)
        {
            return _comandasServices.RemoverComanda(id);
        }
    }
}