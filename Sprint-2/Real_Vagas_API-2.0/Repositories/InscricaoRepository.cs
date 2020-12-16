using Microsoft.EntityFrameworkCore;
using Real_Vagas_API.Domains;
using Real_Vagas_API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Vagas_API.Repositories
{
    public class InscricaoRepository : IInscricao
    {
        //Listar todas as inscrições.
        public List<DbInscricao> Listar()
        {
            using (RealVagasContext ctx = new RealVagasContext())
            {
                return ctx.DbInscricao.ToList();
            }

        } 

        //Buscar uma inscrição pelo seu ID.
        public DbInscricao BuscarPorId(int id)
        {
            using (RealVagasContext ctx = new RealVagasContext())
            {
                return ctx.DbInscricao.FirstOrDefault(e => e.Id == id);
            }

        }

        //Deletar uma inscrição pelo seu ID.
        public void Deletar(int id)
        {
            using (RealVagasContext ctx = new RealVagasContext())
            {
                DbInscricao del = BuscarPorId(id);
                ctx.DbInscricao.Remove(del);
                ctx.SaveChanges();
            }
        }

        //Cadastrar uma nova inscrição.
        public void Cadastrar(DbInscricao inscricao)
        {
            using (RealVagasContext ctx = new RealVagasContext())
            {
                ctx.DbInscricao.Add(inscricao);
                ctx.SaveChanges();
            }
        }

        //Listar todas inscrições de um usuário pelo seu ID.
        public List<DbInscricao> ListarById(int id)
        {
            using (RealVagasContext ctx = new RealVagasContext())
            {
                List<DbInscricao> NovasInscricaos = new List<DbInscricao>();
                List<DbInscricao> inscricaos = ctx.DbInscricao.Include(I => I.IdVagaNavigation.IdEmpresaNavigation)
                    .ToList().FindAll(I => I.IdUsuario == id & I.StatusInscricao == true);
                    
                AdiconalRepository adiconal = new AdiconalRepository();

                foreach (var item in inscricaos)
                {
                    adiconal.DecodeEmpresa(item.IdVagaNavigation.IdEmpresaNavigation, false);
                    NovasInscricaos.Add(item);
                }
                return NovasInscricaos; 
            }
        }

        //Atualizar uma inscrição pelo seu ID e body.
        public void Atualizar(int id, DbInscricao inscricaoAtulizada)
        {
            using (RealVagasContext ctx = new RealVagasContext())
            {

                DbInscricao inscricaoBuscado = ctx.DbInscricao.Find(id);

                inscricaoBuscado.DataInscricao = inscricaoAtulizada.DataInscricao;
                inscricaoBuscado.StatusInscricao = inscricaoAtulizada.StatusInscricao;
                inscricaoBuscado.IdVaga = inscricaoAtulizada.IdVaga;
                inscricaoBuscado.IdUsuario = inscricaoAtulizada.IdUsuario;

                ctx.DbInscricao.Update(inscricaoBuscado);
                ctx.SaveChanges();
            }
        }

        //Listar todas inscrições de uma empresa pelo seu ID.
        public List<DbInscricao> ListarByIdEmpresa(int id)
        {
            using (RealVagasContext ctx = new RealVagasContext())
            {

                List<DbInscricao> NovasInscricaos = new List<DbInscricao>();
                List<DbInscricao> inscricaos = ctx.DbInscricao.Include(I => I.IdVagaNavigation).Include(I => I.IdUsuarioNavigation)
                    .ToList().FindAll(I => I.IdVagaNavigation.IdEmpresa == id
                    && I.IdVagaNavigation.StatusVaga != false);

                AdiconalRepository adiconal = new AdiconalRepository();

                foreach (var item in inscricaos)
                {
                    adiconal.DecodeUsuario(item.IdUsuarioNavigation, false);
                    NovasInscricaos.Add(item);
                }
                return NovasInscricaos;
            }
        }

        //Listar todas inscrições de uma determinada vaga pelo seu ID.
        public List<DbInscricao> ListarByIdVaga(int id)
        {
            using (RealVagasContext ctx = new RealVagasContext())
            {
                List<DbInscricao> NovasInscricaos = new List<DbInscricao>();
                  List<DbInscricao> inscricaos = ctx.DbInscricao.Include(I => I.IdVagaNavigation)
                    .Include(I => I.IdUsuarioNavigation).ToList().FindAll(I => I.IdVaga == id);

                AdiconalRepository adiconal = new AdiconalRepository();

                foreach (var item in inscricaos)
                {
                    adiconal.DecodeUsuario(item.IdUsuarioNavigation, false);
                    NovasInscricaos.Add(item);
                }
                return NovasInscricaos;
            }
        }
    }
}
