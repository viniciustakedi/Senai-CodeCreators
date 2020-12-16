using Microsoft.EntityFrameworkCore;
using Real_Vagas_API.Domains;
using Real_Vagas_API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Vagas_API.Repositories
{
    public class AdministradorRepository : IAdministrador
    { 
        //Método para cadastrar um usuário do tipo administrador no banco de dados
        public void CadastrarAdministrador(DbUsuarios Usuario)
        {
            using (RealVagasContext ctx = new RealVagasContext())
            {
                AdiconalRepository adiconal = new AdiconalRepository();
                // Adiciona um novo usuário

                Usuario = adiconal.DecodeUsuario(Usuario, true);

                ctx.DbUsuarios.Add(Usuario);

                // Salva as informações para serem gravas no banco
                ctx.SaveChanges();
            }
        }

        //Método para cadastrar um usuário do tipo empresa no banco de dados
        public void CadastrarEmpresa(DbEmpresas Empresa)
        {
            using (RealVagasContext Ctx = new RealVagasContext())
            {
                AdiconalRepository adiconal = new AdiconalRepository();

                Empresa = adiconal.DecodeEmpresa(Empresa, true);
                Ctx.DbEmpresas.Add(Empresa);
                Ctx.SaveChanges();
            }
        }

        //Método para cadastrar um usuário do tipo aluno e ex-aluno no banco de dados
        public void CadastrarAluno(DbUsuarios Usuario)
        {
            using (RealVagasContext ctx = new RealVagasContext())
            {
                AdiconalRepository adiconal = new AdiconalRepository();
                // Adiciona um novo usuário

                Usuario = adiconal.DecodeUsuario(Usuario, true);

                ctx.DbUsuarios.Add(Usuario);

                // Salva as informações para serem gravas no banco
                ctx.SaveChanges();
            }
        }

        //Método para listar todos usuários do tipo administradores do banco de dados
        public List<DbUsuarios> ListarAdministradores()
        {
            using (RealVagasContext ctx = new RealVagasContext())
            {
                AdiconalRepository adiconal = new AdiconalRepository();

                List<DbUsuarios> usuarios = ctx.DbUsuarios.ToList().FindAll(U => U.IdTipoUsuario == 1);
                usuarios = adiconal.DecodeListUsuarios(usuarios, false);
                return usuarios;
            }
        }

        //Método para listar todos usuários do tipo aluno e ex-aluno do banco de dados
        public List<DbUsuarios> ListarAlunos()
        {
            using (RealVagasContext ctx = new RealVagasContext())
            {
                AdiconalRepository adiconal = new AdiconalRepository();

                List<DbUsuarios> usuarios = ctx.DbUsuarios.ToList()
                    .FindAll(U => U.IdTipoUsuario == 3 || U.IdTipoUsuario == 4);
                usuarios = adiconal.DecodeListUsuarios(usuarios, false);
                return usuarios;
            }
        }

        //Método para listar todos usuários do tipo empresa do banco de dados
        public List<DbEmpresas> ListarEmpresas()
        {
              using (RealVagasContext Ctx = new RealVagasContext())
                {
                    AdiconalRepository adiconal = new AdiconalRepository();

                    List<DbEmpresas> empresas = adiconal.DecodeListEmpresas(Ctx.DbEmpresas.ToList(), false);

                    return empresas;
                }
        }

        //Método para deletar um usuário do tipo administrador do banco de dados
        public void DeletarAdministrador(int ID)
        {
            using (RealVagasContext Ctx = new RealVagasContext())
            {
                DbUsuarios delete = Ctx.DbUsuarios.FirstOrDefault(U => U.Id == ID);
                Ctx.DbUsuarios.Remove(delete);
                Ctx.SaveChanges();
            }
        }
    }
}
