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
        //Método para listar todos os dados.
        public List<DbDados> Listar()
        {
            using (RealVagasContext ctx = new RealVagasContext())
            {
                AdiconalRepository adiconal = new AdiconalRepository();

                List<DbDados> dados = adiconal.DecodeListDados(ctx.DbDados.ToList(), false);

                return dados;
            }
        } 

        //Método para cadastrar um novo dado.
        public int Cadastrar(DbDados novoUsuario)
        {
            using (RealVagasContext ctx = new RealVagasContext())
            {
                AdiconalRepository adiconal = new AdiconalRepository();

                novoUsuario = adiconal.DecodeDados(novoUsuario, true);
                ctx.DbDados.Add(novoUsuario);
                // Salva as informações para serem gravas no banco
                ctx.SaveChanges();

                return ctx.DbDados.FirstOrDefault(D => D.Cpf == novoUsuario.Cpf).Id;
            }
        }

        //M[etodo para atualizar um dado existente.
        public void Atualizar(int id, DbDados dadoAtualizado)
        {
            using (RealVagasContext ctx = new RealVagasContext())
            {
                AdiconalRepository adiconal = new AdiconalRepository();

                DbDados dadoBuscado = ctx.DbDados.Find(id);

                dadoBuscado.Cpf = (dadoAtualizado.Cpf == null || dadoAtualizado.Cpf == "") ? dadoBuscado.Cpf : adiconal.Cryptografia(dadoAtualizado.Cpf);
                dadoBuscado.NumMatricula = (dadoAtualizado.NumMatricula == null || dadoAtualizado.NumMatricula == "") ? dadoBuscado.NumMatricula : adiconal.Cryptografia(dadoAtualizado.NumMatricula);
                dadoBuscado.Senha = (dadoAtualizado.Senha == null || dadoAtualizado.Senha == "") ? dadoBuscado.Senha : adiconal.Cryptografia(dadoAtualizado.Senha);

                ctx.DbDados.Update(dadoBuscado);
                ctx.SaveChanges();
            }
        }

        //Método para buscar um dado pelo seu ID.
        public DbDados BuscarPorId(int id)
        {
            using (RealVagasContext ctx = new RealVagasContext())
            {
                AdiconalRepository adiconal = new AdiconalRepository();

                List<DbDados> dados = adiconal.DecodeListDados(ctx.DbDados.ToList(), false);

                return dados.FirstOrDefault(u => u.Id == id);
            }
        }

        //Método para deletar um novo dado.
        public void Deletar(int id)
        {
            using (RealVagasContext ctx = new RealVagasContext())
            { 
                DbDados usuarioBuscado = ctx.DbDados.Find(id);

                // Remove o usuário que foi buscado
                ctx.DbDados.Remove(usuarioBuscado);

                // Salva as alterações
                ctx.SaveChanges();
            }
        }
    }
}
