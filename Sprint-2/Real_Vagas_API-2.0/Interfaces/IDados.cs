using Real_Vagas_API.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Vagas_API.Interfaces
{
    public interface IDados
    {                            
        List<DbDados> Listar();

        /// <summary>
        /// Buscar um pelo ID do dado.
        /// </summary>
        /// <param name="id">ID do usuário buscado</param>
        /// <returns>Um usuário buscado</returns>
        DbDados BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo dado
        /// </summary>
        int Cadastrar(DbDados dados);

        /// <summary>
        /// Atualizar um dado
        /// </summary>
        void Atualizar(int id, DbDados dados);

        /// <summary>
        /// Deletar um dado
        /// </summary>
        void Deletar(int id);
    }
}
