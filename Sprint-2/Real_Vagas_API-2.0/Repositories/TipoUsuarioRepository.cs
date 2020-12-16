using Real_Vagas_API.Domains;
using Real_Vagas_API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Vagas_API.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuario
    { 
        //Atualizar um tipo de usuário pelo ID e tipo usuário.
        public void AtualizarTipoUsuarioId(int id, DbTipoUsuario tipousuario)
        {
            using (RealVagasContext Ctx = new RealVagasContext())
            {
                DbTipoUsuario TipoUsuarioAtual = BuscarId(id);
                TipoUsuarioAtual.Titulo = (tipousuario.Titulo == null || tipousuario.Titulo == "") ? TipoUsuarioAtual.Titulo : tipousuario.Titulo;

                Ctx.DbTipoUsuario.Update(TipoUsuarioAtual);
                Ctx.SaveChanges();
            }
        }

        //Buscar um tipo de usuário pelo seu ID.
        public DbTipoUsuario BuscarId(int id)
        {
            using (RealVagasContext Ctx = new RealVagasContext())
            {
                return Ctx.DbTipoUsuario.FirstOrDefault(E => E.Id == id);
            }
        }

        //Cadastrar um tipo de usuário no sistema. 
        public void Cadastrar(DbTipoUsuario tipousuario)
        {
            using (RealVagasContext Ctx = new RealVagasContext())
            {
                Ctx.DbTipoUsuario.Add(tipousuario);
                Ctx.SaveChanges();
            }
        }

        //Deletar um tipo de usuário pelo seu ID.
        public void Deletar(int id)
        {
            using (RealVagasContext Ctx = new RealVagasContext())
            {
                DbTipoUsuario del = BuscarId(id);
                Ctx.DbTipoUsuario.Remove(del);
                Ctx.SaveChanges();
            }
        }

        //Listar todos tipo de usuário.
        public List<DbTipoUsuario> Listar()
        {
            using (RealVagasContext Ctx = new RealVagasContext())
            {
                return Ctx.DbTipoUsuario.ToList();
            }
        }
    }
}

