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

            if (VagaBuscada != null)
            {
                ctx.DbVagas.Update(VagaBuscada);

                ctx.SaveChanges();
            }
        }

        public DbVagas BuscarPorCargo(string Cargo)
        {
            DbVagas VagaBuscada = ctx.DbVagas.FirstOrDefault(x => x.Cargo == Cargo);

            if (VagaBuscada != null)
            {
                return VagaBuscada;
            }

            return null;
        }

        public DbVagas BuscarPorData(DateTime DataPublicacao)
        {
            DbVagas VagaBuscada = ctx.DbVagas.FirstOrDefault(x => x.DataPublicacao == DataPublicacao);

            if (VagaBuscada != null)
            {
                return VagaBuscada;
            }

            return null;
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

        public DbVagas BuscarPorLocal(string localVaga)
        {
            DbVagas VagaBuscada = ctx.DbVagas.FirstOrDefault(x => x.LocalVaga == localVaga);

            if (VagaBuscada != null)
            {
                return VagaBuscada;
            }

            return null;
        }

        public DbVagas BuscarPorNomeEmpresa(string EmpresaNome)
        {
            using (RealVagasContext ctx = new RealVagasContext())
            {
                return ctx.DbVagas.FirstOrDefault(x => x.IdEmpresaNavigation.Nome == EmpresaNome);
            }
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
            ctx.DbVagas.Remove(BuscarPorId(Id));

            ctx.SaveChanges();
        }

        //Método que lista todas as vagas
        public List<DbVagas> ListaVagas()
        {
            return ctx.DbVagas.ToList();
        }
    }
}
