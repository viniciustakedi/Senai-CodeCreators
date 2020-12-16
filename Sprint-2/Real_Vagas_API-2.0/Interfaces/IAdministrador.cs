using Real_Vagas_API.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Vagas_API.Interfaces
{
    public interface IAdministrador
    {
        //Interface para cadastrar um usuário do tipo administrador
        void CadastrarAdministrador(DbUsuarios Usuario);
        //Interface deletar um usuário do tipo administraodr
        void DeletarAdministrador(int ID);
        //Interface para cadastrar um usuário do tipo aluno
        void CadastrarAluno(DbUsuarios Usuario);
        //Intercace para cadastrar um usuário do tipo empresa
        void CadastrarEmpresa(DbEmpresas empresa);
        //Interface para listar todos os usuários do tipo empresa
        List<DbEmpresas> ListarEmpresas();
        //Interface para listar todos os usuários do tipo aluno e ex-aluno
        List<DbUsuarios> ListarAlunos();
        //Interface para listar todos os usuários do tipo Administrador 
        List<DbUsuarios> ListarAdministradores();
    }
}
