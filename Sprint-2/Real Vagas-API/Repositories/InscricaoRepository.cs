using Microsoft.EntityFrameworkCore;
using Real_Vagas_API.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Vagas_API.Repositories
{
    public class InscricaoRepository
    {
        RealVagasContext ctx = new RealVagasContext();


        public List<DbInscricao> Listar()
        {
            return ctx.DbInscricao

                .Include(e => e.IdUsuarioNavigation)

                .Include(e => e.IdVagaNavigation)

                .ToList();
        }

        public DbInscricao BuscarPorId(int id)
        {
            return ctx.DbInscricao.FirstOrDefault(e => e.Id == id);
        }

        public void Deletar(int id)
        {
            ctx.DbInscricao.Remove(BuscarPorId(id));
            ctx.SaveChanges();

        }


        public void Atualizar(int id, DbInscricao inscricaoAtulizada)
        {
            DbInscricao inscricaoBuscado = ctx.DbInscricao.Find(id);

            inscricaoBuscado.DataInscricao = inscricaoAtulizada.DataInscricao;
            inscricaoBuscado.StatusInscricao = inscricaoAtulizada.StatusInscricao;
            inscricaoBuscado.IdVaga = inscricaoAtulizada.IdVaga;
            inscricaoBuscado.IdUsuario = inscricaoAtulizada.IdUsuario;
        }
    }
}
