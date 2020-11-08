using Real_Vagas_API.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Vagas_API.Interfaces
{
    public interface IAdministrador
    {
        void CadastrarAdm(DbUsuarios Usuario);
        void DeletarAdm(int ID);
        void CadastrarAluno(DbUsuarios Usuario);
        void CadastrarEmpresa(DbEmpresas empresa);
        List<DbEmpresas> ListarEmpresas();
        List<DbUsuarios> ListarAlunos();
        List<DbUsuarios> ListarAdministradores();
    }
}
