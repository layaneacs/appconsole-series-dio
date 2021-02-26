using System.Collections.Generic;

namespace Dio.Series
{
    public interface IRepository<T> where T : class
    {
        List<T> Lista();
        T RetornaPorId(int id);
        void Insere(T entidade);
        void Exluir(int id);
        void Atualizar(int id, T entidade);
        int ProximoId();

    }
}