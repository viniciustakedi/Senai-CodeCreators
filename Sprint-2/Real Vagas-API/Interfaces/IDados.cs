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
        /// Busca um usuário através do ID
        /// </summary>
        /// <param name="id">ID do usuário buscado</param>
        /// <returns>Um usuário buscado</returns>
        DbDados BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="novoUsuario">Objeto novoUsuario que será cadastrado</param>
        void Cadastrar(DbDados novoUsuario);

        /// <summary>
        /// Atualiza um usuário existente
        /// </summary>
        /// <param name="id">ID do usuário que será atualizado</param>
        /// <param name="usuarioAtualizado">Objeto com as novas informações</param>
        void Atualizar(int id, DbDados usuarioAtualizado);

        /// <summary>
        /// Deleta um usuário
        /// </summary>
        /// <param name="id">ID do usuário que será deletado</param>
        void Deletar(int id);
    }
}
