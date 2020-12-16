using Real_Vagas_API.Domains;
using Real_Vagas_API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Vagas_API.Interfaces
{
    public interface ITipoUsuario
    {
        //Para listar todos os tipos de usuarios.
        List<DbTipoUsuario> Listar();
        //Para cadastrar um novo tipo de usuario
        void Cadastrar(DbTipoUsuario tipousuario);
        //Atualizar tipo usuario passando seu id na url
        void AtualizarTipoUsuarioId(int id, DbTipoUsuario tipousuario);
        //Para deletar um estudio
        void Deletar(int id);
        // Buscar tipo usuario por Id
        DbTipoUsuario BuscarId(int id); 
    }
}
