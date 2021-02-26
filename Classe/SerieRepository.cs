using System;
using System.Collections.Generic;

namespace Dio.Series
{
    public class SerieRepository : IRepository<Serie>
    {
        private List<Serie> series = new List<Serie>();

        public void Atualizar(int id, Serie entidade)
        {
            series[id] = entidade;
        }

        public void Exluir(int id)
        {
            // series.RemoveAt(id);  mudará os indices
            series[id].Excluir();

        }

        public void Insere(Serie entidade)
        {
            series.Add(entidade);
        }

        public List<Serie> Lista()
        {
            return series;
        }

        public int ProximoId()
        {
            return series.Count;
        }

        public Serie RetornaPorId(int id)
        {
            return series[id];
        }
    }
}