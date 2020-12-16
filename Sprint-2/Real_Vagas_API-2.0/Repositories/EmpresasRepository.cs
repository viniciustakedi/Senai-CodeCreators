using Microsoft.EntityFrameworkCore;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Real_Vagas_API.Domains;
using Real_Vagas_API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;

namespace Real_Vagas_API.Repositories
{ 
    public class EmpresasRepository : IEmpresas
    {
        //Deletar um usuário do tipo empresa.
        public void Delete(int ID)
        {
            using (RealVagasContext Ctx = new RealVagasContext())
            {
                DbEmpresas del = BuscarPorId(ID);
                Ctx.DbEmpresas.Remove(del);
                Ctx.SaveChanges();
            }
        }

        //Listar todos usuários do tipo empresa.
        public List<DbEmpresas> Get()
        {
            using (RealVagasContext Ctx = new RealVagasContext())
            {
                AdiconalRepository adiconal = new AdiconalRepository();

                List<DbEmpresas> empresas = adiconal.DecodeListEmpresas(Ctx.DbEmpresas.ToList(), false);

                return empresas;
            }
        }

        //Buscar email e senha para efetuar o login.
        public DbEmpresas Login(string Email, string Senha)
        {
            using (RealVagasContext Ctx = new RealVagasContext())
            {
                AdiconalRepository adiconal = new AdiconalRepository();

                List<DbEmpresas> empresas = adiconal.DecodeListEmpresas(Ctx.DbEmpresas.ToList(), false);

                DbEmpresas empresa = empresas.FirstOrDefault(U => U.Email == Email && U.Senha == Senha);

                return empresa;
            }
        }      

        //Cadastrar uma nova empresa no sistema.
        public void Post(DbEmpresas Empresa)
        {
            using (RealVagasContext Ctx = new RealVagasContext())
            {
                AdiconalRepository adiconal = new AdiconalRepository();

                Empresa = adiconal.DecodeEmpresa(Empresa, true);
                Ctx.DbEmpresas.Add(Empresa);
                Ctx.SaveChanges();
            }
        }

        //Atualizar os dados de uma empresa.
        public void Put(DbEmpresas Empresa)
        {
            using (RealVagasContext Ctx = new RealVagasContext())
            {
                AdiconalRepository adiconal = new AdiconalRepository();

                DbEmpresas EmpresaAtual = BuscarPorId(Empresa.Id);
                EmpresaAtual.Nome = (Empresa.Nome == null || Empresa.Nome == "") ? EmpresaAtual.Nome : adiconal.Cryptografia(Empresa.Nome);
                EmpresaAtual.Email = (Empresa.Email == null || Empresa.Email == "") ? EmpresaAtual.Email : adiconal.Cryptografia(Empresa.Email);
                EmpresaAtual.NomeResponsavel = (Empresa.NomeResponsavel == null || Empresa.NomeResponsavel == "") ? EmpresaAtual.NomeResponsavel : adiconal.Cryptografia(Empresa.NomeResponsavel);
                EmpresaAtual.RazaoSocial = (Empresa.RazaoSocial == null || Empresa.RazaoSocial == "") ? EmpresaAtual.RazaoSocial : adiconal.Cryptografia(Empresa.RazaoSocial);
                EmpresaAtual.Senha = (Empresa.Senha == null || Empresa.Senha == "") ? EmpresaAtual.Senha : adiconal.Cryptografia(Empresa.Senha);
                EmpresaAtual.Telefone = (Empresa.Telefone == null || Empresa.Telefone == "") ? EmpresaAtual.Telefone : adiconal.Cryptografia(Empresa.Telefone);
                EmpresaAtual.Cnpj = (Empresa.Cnpj == null || Empresa.Cnpj == "") ? EmpresaAtual.Cnpj : adiconal.Cryptografia(Empresa.Cnpj);

                Ctx.DbEmpresas.Update(EmpresaAtual);
                Ctx.SaveChanges();
            }
        }

        //Listar todas vagas cadastradas nós últimos 30 dias.
        public List<DbVagas> VagasCadastradas30Dias(int ID)
        {
            using (RealVagasContext Ctx = new RealVagasContext())
            {
                DateTime result = DateTime.Now.Subtract(TimeSpan.FromDays(30));
                return Ctx.DbVagas.OrderBy(V => V.DataPublicacao).Where(V => V.DataPublicacao > result)
                .ToList().FindAll(V => V.IdEmpresaNavigation.Id == ID);
            }
        }

        //Listar todas as inscrições dos últimos 30 dias.
        public List<DbInscricao> InscricoesRecebidas30Dias(int ID)
        {
            using (RealVagasContext Ctx = new RealVagasContext())
            {
                DateTime result = DateTime.Now.Subtract(TimeSpan.FromDays(30));
                return Ctx.DbInscricao.OrderBy(V => V.StatusInscricao == true).Where(V => V.IdVagaNavigation.DataPublicacao > result)
                .ToList().FindAll(V => V.IdVagaNavigation.IdEmpresaNavigation.Id == ID);
            }
        }

        //Buscar uma empresa pelo seu email e cnpj
        public DbEmpresas BuscarPorEmpresa(string Email, string Cnpj)
        {
            using (RealVagasContext Ctx = new RealVagasContext())
            {
                AdiconalRepository adiconal = new AdiconalRepository();

                List<DbEmpresas> empresas = adiconal.DecodeListEmpresas(Ctx.DbEmpresas.ToList(), false);

                DbEmpresas empresa = empresas.FirstOrDefault(U => U.Email == Email || U.Cnpj == Cnpj);

                return empresa;
            }
        }

        //Buscar uma empresa pelo seu ID.
        public DbEmpresas BuscarPorId(int ID)
        {
            using (RealVagasContext Ctx = new RealVagasContext())
            {
                AdiconalRepository adiconal = new AdiconalRepository();

                DbEmpresas empresa = Ctx.DbEmpresas.FirstOrDefault(U => U.Id == ID);
                empresa = adiconal.DecodeEmpresa(empresa, false);

                return empresa;
            }
        }

    }
}
