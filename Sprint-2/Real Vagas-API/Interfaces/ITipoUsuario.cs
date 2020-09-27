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
        List<DbTipoUsuario> Listar(); //Para listar todos os tipos de usuarios
        void Cadastrar(DbTipoUsuario tipousuario); //Para cadastrar um novo tipo de usuario
        void AtualizarTipoUsuarioId(int id, DbTipoUsuario tipousuario); //Atualizar tipo usuario passando seu id na url
        void Deletar(int id); //Para deletar um estudio
        DbTipoUsuario BuscarId(int id); // buscar tipo usuario por Id
    }
}
