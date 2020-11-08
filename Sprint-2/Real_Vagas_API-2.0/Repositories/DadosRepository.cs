using Real_Vagas_API.Domains;
using Real_Vagas_API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Vagas_API.Repositories
{
    public class DadosRepository : IDados
    {
        RealVagasContext ctx = new RealVagasContext();

        public void Atualizar(int id, DbDados dadoAtualizado)
        {
            DbDados dadoBuscado = ctx.DbDados.Find(id);

            dadoBuscado.Cpf = dadoAtualizado.Cpf;
            dadoBuscado.NumMatricula = dadoAtualizado.NumMatricula;
            dadoBuscado.Senha = dadoAtualizado.Senha;
        }

        public DbDados BuscarPorId(int id)
        {
            return ctx.DbDados.FirstOrDefault(u => u.Id == id);
        }

        public int Cadastrar(DbDados novoUsuario)
        {
            ctx.DbDados.Add(novoUsuario);
            // Salva as informações para serem gravas no banco
            ctx.SaveChanges();

            return ctx.DbDados.FirstOrDefault(D => D.Cpf == novoUsuario.Cpf).Id;
        }

        public void Deletar(int id)
        {
            DbDados usuarioBuscado = ctx.DbDados.Find(id);

            // Remove o usuário que foi buscado
            ctx.DbDados.Remove(usuarioBuscado);

            // Salva as alterações
            ctx.SaveChanges();
        }

        public List<DbDados> Listar()
        {
            return ctx.DbDados.ToList();
        }
    }
}
