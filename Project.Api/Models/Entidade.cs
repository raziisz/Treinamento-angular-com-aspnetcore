using System.Collections.Generic;
using System.Linq;

namespace Project.Api.Models
{
    public abstract class Entidade
    {
        private List<string> _mensagemValidacao { get; set; }
        private List<string> mensagemValidacao 
        {
            get { return _mensagemValidacao ?? (_mensagemValidacao = new List<string>());}
        }

        protected void LimparMensagensValidacao()
        {
            mensagemValidacao.Clear();
        }

        protected void AdicionarCritica(string mensagem)
        {
            mensagemValidacao.Add(mensagem);
        }

        public abstract void Validate();
        protected bool EhValidado
        {
            get { return !mensagemValidacao.Any();}
        }
    }
}