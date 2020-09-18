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
        public void CadastrarAdm(DbUsuarios Usuario)
        {
            using(RealVagasContext Ctx = new RealVagasContext())
            {
                Ctx.DbUsuarios.Add(Usuario);
                Ctx.SaveChanges();
            }
        }

        public void CadastrarEmpresa(DbEmpresas empresa)
        {
            using (RealVagasContext Ctx = new RealVagasContext())
            {
                Ctx.DbEmpresas.Add(empresa);
                Ctx.SaveChanges();
            }
        }

        public void CadastrarAluno(DbUsuarios Usuario)
        {
            using (RealVagasContext Ctx = new RealVagasContext())
            {
                Ctx.DbUsuarios.Add(Usuario);
                Ctx.SaveChanges();
            }
        }

        public List<DbUsuarios> ListarAdministradores()
        {
            using (RealVagasContext Ctx = new RealVagasContext())
            {
                return Ctx.DbUsuarios.ToList().FindAll(U => U.IdTipoUsuarioNavigation.Id == 1);
            }
        }

        public List<DbUsuarios> ListarAlunos()
        {
            using (RealVagasContext Ctx = new RealVagasContext())
            {
                return Ctx.DbUsuarios.ToList().FindAll(U => U.IdTipoUsuarioNavigation.Id == 3
                && U.IdTipoUsuarioNavigation.Id == 4);
            }
        }

        public List<DbEmpresas> ListarEmpresas()
        {
            using (RealVagasContext Ctx = new RealVagasContext())
            {
                return Ctx.DbEmpresas.ToList().FindAll(U => U.IdTipoUsuarioNavigation.Id == 2);
            }
        }

        public void DeletarAdm(int ID)
        {
            using (RealVagasContext Ctx = new RealVagasContext())
            {
                DbUsuarios delete= Ctx.DbUsuarios.FirstOrDefault(U => U.Id == ID);
                Ctx.DbUsuarios.Remove(delete);
                Ctx.SaveChanges();
            }
        }
    }
}
