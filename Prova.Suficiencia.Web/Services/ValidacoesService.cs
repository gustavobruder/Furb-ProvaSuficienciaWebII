using System.Linq;
using Prova.Suficiencia.Web.Entities;
using Prova.Suficiencia.Web.Exceptions;
using Prova.Suficiencia.Web.Models;
using Prova.Suficiencia.Web.Projecoes;

namespace Prova.Suficiencia.Web.Services
{
    public class ValidacoesService : IValidacoesService
    {
        public void ValidarSeExiste(int id, Comanda comanda)
        {
            ValidarSeExisteComanda(id, comanda);
        }

        public void ValidarSeExiste(int id, DetalhesComandaProjecao comanda)
        {
            ValidarSeExisteComanda(id, comanda);
        }

        private void ValidarSeExisteComanda(int id, object comanda)
        {
            if (comanda == null)
                throw new EntidadeNaoEncontradaException($"Comanda {id} não encontrada");
        }

        public void ValidarCamposCadastro(CadastroComandaModel model)
        {
            if (model.IdUsuario <= 0)
                throw new ValidacaoException("Campo 'IdUsuario' deve ser maior que zero.");

            if (string.IsNullOrWhiteSpace(model.NomeUsuario))
                throw new ValidacaoException("Campo 'NomeUsuario' deve ser preenchido.");

            if (string.IsNullOrWhiteSpace(model.TelefoneUsuario))
                throw new ValidacaoException("Campo 'TelefoneUsuario' deve ser preenchido.");

            if (model.TelefoneUsuario.Length != 11 || !long.TryParse(model.TelefoneUsuario, out _))
                throw new ValidacaoException("Campo 'TelefoneUsuario' deve conter 11 numeros (ex: 47999887766).");

            foreach (var produto in model.Produtos)
            {
                if (produto.Id <= 0)
                    throw new ValidacaoException("Campo 'Produtos.Id' deve ser maior que zero.");

                if (string.IsNullOrWhiteSpace(produto.Nome))
                    throw new ValidacaoException("Campo 'Produtos.Nome' deve ser preenchido.");

                if (produto.Preco <= 0)
                    throw new ValidacaoException("Campo 'Produtos.Preco' deve ser maior que zero.");
            }
        }

        public void ValidarCamposAtualizacaoUsuario(AtualizacaoComandaModel model)
        {
            if (model.IdUsuario != null)
            {
                if (model.IdUsuario <= 0)
                    throw new ValidacaoException("Campo 'IdUsuario' deve ser maior que zero.");                
            }

            if (model.NomeUsuario != null)
            {
                if (model.NomeUsuario == string.Empty || model.NomeUsuario.All(char.IsWhiteSpace))
                    throw new ValidacaoException("Campo 'NomeUsuario' deve ser preenchido.");
            }

            if (model.TelefoneUsuario != null)
            {
                if (model.TelefoneUsuario == string.Empty || model.TelefoneUsuario.All(char.IsWhiteSpace))
                    throw new ValidacaoException("Campo 'TelefoneUsuario' deve ser preenchido.");

                if (model.TelefoneUsuario.Length != 11 || !long.TryParse(model.TelefoneUsuario, out _))
                    throw new ValidacaoException("Campo 'TelefoneUsuario' deve conter 11 numeros (ex: 47999887766).");
            }
        }

        public void ValidarCamposAtualizacaoProdutoInserir(AtualizacaoProdutoModel model)
        {
            if (model.Id <= 0)
                throw new ValidacaoException("Campo 'Produtos.Id' deve ser maior que zero.");

            if (string.IsNullOrWhiteSpace(model.Nome))
                throw new ValidacaoException("Campo 'Produtos.Nome' deve ser preenchido.");

            if (model.Preco == null || model.Preco <= 0)
                throw new ValidacaoException("Campo 'Produtos.Preco' deve ser maior que zero.");
        }

        public void ValidarCamposAtualizacaoProdutoAtualizar(AtualizacaoProdutoModel model)
        {
            if (model.Nome != null)
            {
                if (model.Nome == string.Empty || model.Nome.All(char.IsWhiteSpace))
                    throw new ValidacaoException("Campo 'Produtos.Nome' deve ser preenchido.");
            }

            if (model.Preco != null)
            {
                if (model.Preco <= 0)
                    throw new ValidacaoException("Campo 'Produtos.Preco' deve ser maior que zero.");
            }
        }
    }
}