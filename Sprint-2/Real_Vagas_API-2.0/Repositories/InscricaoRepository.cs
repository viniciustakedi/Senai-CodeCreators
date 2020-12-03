﻿using Microsoft.EntityFrameworkCore;
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
        public List<DbInscricao> Listar()
        {
            using (RealVagasContext ctx = new RealVagasContext())
            {
                return ctx.DbInscricao.ToList();
            }

        }

        public DbInscricao BuscarPorId(int id)
        {
            using (RealVagasContext ctx = new RealVagasContext())
            {
                return ctx.DbInscricao.FirstOrDefault(e => e.Id == id);
            }

        }

        public void Deletar(int id)
        {
            using (RealVagasContext ctx = new RealVagasContext())
            {
                DbInscricao del = BuscarPorId(id);
                ctx.DbInscricao.Remove(del);
                ctx.SaveChanges();
            }
        }

        public void Cadastrar(DbInscricao inscricao)
        {
            using (RealVagasContext ctx = new RealVagasContext())
            {
                ctx.DbInscricao.Add(inscricao);
                ctx.SaveChanges();
            }
        }

        public List<DbInscricao> ListarById(int id)
        {
            using (RealVagasContext ctx = new RealVagasContext())
            {
 
                return ctx.DbInscricao.Include(I => I.IdVagaNavigation.IdEmpresaNavigation).ToList().FindAll(I => I.IdUsuario == id & I.StatusInscricao == true );
            }
        }

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

        public List<DbInscricao> ListarByIdEmpresa(int id)
        {
            using (RealVagasContext ctx = new RealVagasContext())
            {

                return ctx.DbInscricao.Include(I => I.IdVagaNavigation)
                    .ToList().FindAll(I => I.IdVagaNavigation.IdEmpresa == id 
                    && I.IdVagaNavigation.StatusVaga != false);
            }
        }

        public List<DbInscricao> ListarByIdVaga(int id)
        {
            using (RealVagasContext ctx = new RealVagasContext())
            {
                return ctx.DbInscricao.Include(I => I.IdVagaNavigation)
                    .Include(I => I.IdUsuarioNavigation).ToList().FindAll(I => I.IdVaga == id);
            }
        }
    }
}