using Real_Vagas_API.Domains;
using Real_Vagas_API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Vagas_API.Repositories
{
    public class EmpresasRepository : IEmpresas
    {
        public void Delete(int ID)
        {
            using (RealVagasContext Ctx = new RealVagasContext())
            {
                DbEmpresas del = SearchById(ID);
                Ctx.DbEmpresas.Remove(del);
                Ctx.SaveChanges();
            }
        }

        public List<DbEmpresas> Get()
        {
            using (RealVagasContext Ctx = new RealVagasContext())
            {
                return Ctx.DbEmpresas.ToList();
            }
        }

        public void Post(DbEmpresas Empresa)
        {
            using (RealVagasContext Ctx = new RealVagasContext())
            {
                Ctx.DbEmpresas.Add(Empresa);
                Ctx.SaveChanges();
            }
        }

        public void Put(DbEmpresas Empresa)
        {
            using (RealVagasContext Ctx = new RealVagasContext())
            {
                DbEmpresas EmpresaAtual = SearchById(Empresa.Id);
                EmpresaAtual.Nome = (Empresa.Nome == null || Empresa.Nome == "") ? EmpresaAtual.Nome : Empresa.Nome;
                EmpresaAtual.Email = (Empresa.Email == null || Empresa.Email == "") ? EmpresaAtual.Email : Empresa.Email;
                EmpresaAtual.NomeResponsavel = (Empresa.NomeResponsavel == null || Empresa.NomeResponsavel == "") ? EmpresaAtual.NomeResponsavel : Empresa.NomeResponsavel;
                EmpresaAtual.RazaoSocial = (Empresa.RazaoSocial == null || Empresa.RazaoSocial == "") ? EmpresaAtual.RazaoSocial : Empresa.RazaoSocial;
                EmpresaAtual.Senha = (Empresa.Senha == null || Empresa.Senha == "") ? EmpresaAtual.Senha : Empresa.Senha;
                EmpresaAtual.Telefone= (Empresa.Telefone == null || Empresa.Telefone == "") ? EmpresaAtual.Telefone : Empresa.Telefone;
                EmpresaAtual.Cnpj = (Empresa.Cnpj == null || Empresa.Cnpj == "") ? EmpresaAtual.Cnpj : Empresa.Cnpj;

                Ctx.DbEmpresas.Update(EmpresaAtual);
                Ctx.SaveChanges();
            }
        }

        public List<DbVagas> RegisteredVacancies(int ID)
        {
            using (RealVagasContext Ctx = new RealVagasContext())
            {
                return Ctx.DbVagas.OrderBy(V => V.DataPublicacao).ToList().FindAll(V => V.IdEmpresaNavigation.Id == ID);
            }
        }

        public List<DbVagas> RegisteredVacanciesBy30Days(int ID)
        {
            using (RealVagasContext Ctx = new RealVagasContext())
            {
                DateTime result = DateTime.Now.Subtract(TimeSpan.FromDays(30));
                return Ctx.DbVagas.OrderBy(V => V.DataPublicacao).Where(V => V.DataPublicacao > result)
                .ToList().FindAll(V => V.IdEmpresaNavigation.Id == ID);
            }
        }

        public List<DbInscricao> ResumesReceived(int ID)
        {
            using (RealVagasContext Ctx = new RealVagasContext())
            {
                return Ctx.DbInscricao.ToList().FindAll(I => I.IdVagaNavigation.IdEmpresaNavigation.Id == ID);
            }
        }

        public List<DbInscricao> ResumesReceivedBy30Days(int ID)
        {
            using (RealVagasContext Ctx = new RealVagasContext())
            {
                DateTime result = DateTime.Now.Subtract(TimeSpan.FromDays(30));
                return Ctx.DbInscricao.OrderBy(V => V.StatusInscricao == true).Where(V => V.IdVagaNavigation.DataPublicacao > result)
                .ToList().FindAll(V => V.IdVagaNavigation.IdEmpresaNavigation.Id == ID);
            }
        }

        public List<DbInscricao> ResumesReceivedByVacancies(int ID)
        {
            using (RealVagasContext Ctx = new RealVagasContext())
            {
                return Ctx.DbInscricao.ToList().FindAll(I => I.IdVaga == ID);
            }
        }

        public DbEmpresas SearchByEmpresa(string Email, string Cnpj)
        {
            using (RealVagasContext Ctx = new RealVagasContext())
            {
                return Ctx.DbEmpresas.FirstOrDefault(E => E.Email == Email || E.Cnpj == Cnpj);
            }
        }

        public DbEmpresas SearchById(int ID)
        {
            using (RealVagasContext Ctx = new RealVagasContext())
            {
                return Ctx.DbEmpresas.FirstOrDefault(E => E.Id == ID);
            }
        }
    }
}
