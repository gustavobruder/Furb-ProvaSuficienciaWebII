using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prova.Suficiencia.Web.Models;
using Prova.Suficiencia.Web.Services;
using Prova.Suficiencia.Web.Views;

namespace Prova.Suficiencia.Web.Controllers
{
    [Authorize]
    [Produces("application/json")]
    public class ComandasController : ApiController
    {
        private readonly IComandasServices _comandasServices;

        public ComandasController(IComandasServices comandasServices)
        {
            _comandasServices = comandasServices;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ListagemComandaViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IList<ListagemComandaViewModel>>> ListarComandas()
        {
            var viewModel = await  _comandasServices.ListarComandas();
            return Ok(viewModel);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(DetalhesComandaViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DetalhesComandaViewModel>> DetalharComanda([FromRoute] int id)
        {
            var viewModel = await  _comandasServices.DetalharComanda(id);
            return Ok(viewModel);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CadastroComandaViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<ActionResult<CadastroComandaViewModel>> CadastrarComanda([FromBody] CadastroComandaModel model)
        {
            var viewModel = await _comandasServices.CadastrarComanda(model);
            return Ok(viewModel);
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<ActionResult> AtualizarComanda([FromRoute] int id, [FromBody] AtualizacaoComandaModel model)
        {
            await _comandasServices.AtualizarComanda(id, model);
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(RemocaoComandaViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RemocaoComandaViewModel>> RemoverComanda([FromRoute] int id)
        {
            var viewModel = await _comandasServices.RemoverComanda(id);
            return Ok(viewModel);
        }
    }
}