﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prova.Suficiencia.Web.DAOs;
using Prova.Suficiencia.Web.Entities;
using Prova.Suficiencia.Web.Models;
using Prova.Suficiencia.Web.Views;

namespace Prova.Suficiencia.Web.Services
{
    public class ComandasServices : IComandasServices
    {
        private readonly IComandasDAO _comandasDao;
        private readonly IValidacoesService _validacoesService;

        public ComandasServices(IComandasDAO comandasDao, IValidacoesService validacoesService)
        {
            _comandasDao = comandasDao;
            _validacoesService = validacoesService;
        }

        public async Task<IList<ListagemComandaViewModel>> ListarComandas()
        {
            var comandas = await _comandasDao.ObterComandasParaListagem();

            return comandas
                .Select(x => new ListagemComandaViewModel
                {
                    IdUsuario = x.IdUsuario,
                    NomeUsuario = x.NomeUsuario,
                    TelefoneUsuario = x.TelefoneUsuario,
                })
                .ToArray();
        }

        public async Task<DetalhesComandaViewModel> DetalharComanda(int id)
        {
            var comanda = await _comandasDao.ObterComandaParaDetalhes(id);

            _validacoesService.ValidarSeExiste(id, comanda);

            return new DetalhesComandaViewModel
            {
                IdUsuario = comanda.IdUsuario,
                NomeUsuario = comanda.NomeUsuario,
                TelefoneUsuario = comanda.TelefoneUsuario,
                Produtos = comanda.Produtos
                    .Select(x => new DetalhesProdutoViewModel
                    {
                        Id = x.Id,
                        Nome = x.Nome,
                        Preco = x.Preco,
                    })
                    .ToArray(),
            };
        }

        public async Task<CadastroComandaViewModel> CadastrarComanda(CadastroComandaModel model)
        {
            _validacoesService.ValidarCamposCadastro(model);

            var comanda = new Comanda
            {
                IdUsuario = model.IdUsuario,
                NomeUsuario = model.NomeUsuario,
                TelefoneUsuario = model.TelefoneUsuario,
                Produtos = model.Produtos
                    .Select(x => new Produto
                    {
                        Id = x.Id,
                        Nome = x.Nome,
                        Preco = x.Preco,
                    })
                    .ToArray(),
            };

            var idComanda = await _comandasDao.InserirComanda(comanda);

            return new CadastroComandaViewModel
            {
                Id = idComanda,
                IdUsuario = comanda.IdUsuario,
                NomeUsuario = comanda.NomeUsuario,
                TelefoneUsuario = comanda.TelefoneUsuario,
                Produtos = comanda.Produtos
                    .Select(x => new CadastroProdutoViewModel
                    {
                        Id = x.Id,
                        Nome = x.Nome,
                        Preco = x.Preco,
                    })
                    .ToArray(),
            };
        }

        public async Task AtualizarComanda(int id, AtualizacaoComandaModel model)
        {
            var comanda = await _comandasDao.ObterComanda(id);

            _validacoesService.ValidarSeExiste(id, comanda);
            _validacoesService.ValidarCamposAtualizacaoUsuario(model);

            comanda.IdUsuario = model.IdUsuario ?? comanda.IdUsuario;
            comanda.NomeUsuario = model.NomeUsuario ?? comanda.NomeUsuario;
            comanda.TelefoneUsuario = model.TelefoneUsuario ?? comanda.TelefoneUsuario;

            foreach (var modelProduto in model.Produtos ?? new List<AtualizacaoProdutoModel>())
            {
                var comandaProduto = comanda.Produtos.FirstOrDefault(x => x.Id == modelProduto.Id);

                if (comandaProduto == null)
                {
                    _validacoesService.ValidarCamposAtualizacaoProdutoInserir(modelProduto);

                    comandaProduto = new Produto
                    {
                        Id = modelProduto.Id,
                        Nome = modelProduto.Nome,
                        Preco = (double) modelProduto.Preco,
                    };
                    comanda.Produtos.Add(comandaProduto);
                }
                else
                {
                    _validacoesService.ValidarCamposAtualizacaoProdutoAtualizar(modelProduto);

                    comandaProduto.Nome = modelProduto.Nome ?? comandaProduto.Nome;
                    comandaProduto.Preco = modelProduto.Preco ?? comandaProduto.Preco;
                }
            }

            await _comandasDao.AtualizarComanda(comanda);
        }

        public async Task<RemocaoComandaViewModel> RemoverComanda(int id)
        {
            var comanda = await _comandasDao.ObterComanda(id);

            _validacoesService.ValidarSeExiste(id, comanda);

            await _comandasDao.RemoverComanda(comanda);

            return new RemocaoComandaViewModel
            {
                Success = new SuccessViewModel
                {
                    Text = "comanda removida",
                },
            };
        }
    }
}