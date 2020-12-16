using Real_Vagas_API.Domains;
using Real_Vagas_API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Vagas_API.Repositories
{
    public class VagasRepository : IVagas
    {
        //Contexto feito pelo scafolding para usar o entity framework
        RealVagasContext ctx = new RealVagasContext();

        //Metodo que atualiza as vagas
        public void Atualizar(int Id, DbVagas VagaAtualizada)
        {
            DbVagas VagaBuscada = ctx.DbVagas.Find(Id);
            VagaBuscada.StatusVaga = VagaAtualizada.StatusVaga;
            if (VagaBuscada != null)
            {
                ctx.DbVagas.Update(VagaBuscada);

                ctx.SaveChanges();
            }
        }

        public List<DbVagas> ListaByIdEmpresa(int Id)
        {
            using (RealVagasContext Ctx = new RealVagasContext())
            {
                return Ctx.DbVagas.ToList().FindAll(E => E.IdEmpresa == Id && E.StatusVaga != false);
            }
        }

        //Método que busca uma vaga por Id
        public DbVagas BuscarPorId(int Id)
        {
            DbVagas VagaBuscada = ctx.DbVagas.FirstOrDefault(x => x.Id == Id);

            if (VagaBuscada != null)
            {
                return VagaBuscada;
            }

            return null;
        }

        //Método que cadastra uma nova vaga
        public void Cadastrar(DbVagas VagaNova)
        {
            ctx.DbVagas.Add(VagaNova);

            ctx.SaveChanges();
        }

        //Método que deleta uma vaga
        public void Deletar(int Id)
        {
            DbVagas Deletado = BuscarPorId(Id);

            ctx.DbVagas.Remove(Deletado);

            ctx.SaveChanges();
        }

        //Método que lista todas as vagas
        public List<DbVagas> ListaVagas()
        {
            return ctx.DbVagas.ToList().FindAll(U => U.StatusVaga != false);
        }
    }
}
