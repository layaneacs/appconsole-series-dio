using System;

namespace Dio.Series
{
    public class Serie: EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }   
        private int Ano { get; set; }

        private bool Exluido { get; set; }

        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Exluido = false;
        }

        public override string ToString()
        {
            var retorno = "";
            retorno += "Gênero: "+ this.Genero + Environment.NewLine;
            retorno += "Título: "+ this.Titulo + Environment.NewLine;
            retorno += "Descrição: "+ this.Descricao + Environment.NewLine;
            retorno += "Ano: "+ this.Ano + Environment.NewLine;
            retorno += "Excluido: "+ this.Exluido;
            return retorno;
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }

        public int retornaId()
        {
            return this.Id;
        }

        public bool RetornaExluido()
        {
            return this.Exluido;
        }
        public void Excluir()
        {
            this.Exluido = true;
        }

    }
}