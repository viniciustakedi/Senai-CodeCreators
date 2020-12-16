using Microsoft.EntityFrameworkCore;
using Real_Vagas_API.Domains;
using Real_Vagas_API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Vagas_API.Repositories
{
    public class UsuariosRepository : IUsuarios
    {
        //Métdo para atualizar um usuário.
        public void Atualizar(int id, DbUsuarios usuarioAtualizado)
        {
            using (RealVagasContext ctx = new RealVagasContext())
            {
                AdiconalRepository adiconal = new AdiconalRepository();

                // Busca um usuário através do id
                DbUsuarios usuarioBuscado = ctx.DbUsuarios.Find(id);

                // Atribui os novos valores ao campos existentes
                usuarioBuscado.Nome = (usuarioAtualizado.Nome == null || usuarioAtualizado.Nome == "") ? usuarioBuscado.Nome : adiconal.Cryptografia(usuarioAtualizado.Nome);
                usuarioBuscado.DataNascimento = (usuarioAtualizado.DataNascimento == null)? usuarioBuscado.DataNascimento : usuarioAtualizado.DataNascimento;
                usuarioBuscado.Sexo = (usuarioAtualizado.Sexo == null || usuarioAtualizado.Sexo == "") ? usuarioBuscado.Sexo : usuarioAtualizado.Sexo;
                usuarioBuscado.Escola = (usuarioAtualizado.Escola == null || usuarioAtualizado.Escola == "") ? usuarioBuscado.Escola : adiconal.Cryptografia(usuarioAtualizado.Escola);
                usuarioBuscado.Email = (usuarioAtualizado.Email == null || usuarioAtualizado.Email == "") ? usuarioBuscado.Email : adiconal.Cryptografia(usuarioAtualizado.Email);
                usuarioBuscado.Telefone = (usuarioAtualizado.Telefone == null || usuarioAtualizado.Telefone == "") ? usuarioBuscado.Telefone : adiconal.Cryptografia(usuarioAtualizado.Telefone);
                usuarioBuscado.EstadoCivil = (usuarioAtualizado.EstadoCivil == null || usuarioAtualizado.EstadoCivil == "") ? usuarioBuscado.EstadoCivil : adiconal.Cryptografia(usuarioAtualizado.EstadoCivil);
                usuarioBuscado.UrlCurriculo = (usuarioAtualizado.UrlCurriculo == null || usuarioAtualizado.UrlCurriculo == "") ? usuarioBuscado.UrlCurriculo : usuarioAtualizado.UrlCurriculo;
                usuarioBuscado.Nivel = (usuarioAtualizado.Nivel == null || usuarioAtualizado.Nivel == "") ? usuarioBuscado.Nivel : usuarioAtualizado.Nivel;
                usuarioBuscado.TipoCurso = (usuarioAtualizado.TipoCurso == null || usuarioAtualizado.TipoCurso == "") ? usuarioBuscado.TipoCurso : usuarioAtualizado.TipoCurso;
                usuarioBuscado.Curso = (usuarioAtualizado.Curso == null || usuarioAtualizado.Curso == "") ? usuarioBuscado.Curso : adiconal.Cryptografia(usuarioAtualizado.Curso);
                usuarioBuscado.Turma = (usuarioAtualizado.Turma == null || usuarioAtualizado.Turma == "") ? usuarioBuscado.Turma : usuarioAtualizado.Turma;
                usuarioBuscado.Turno = (usuarioAtualizado.Turno == null || usuarioAtualizado.Turno == "") ? usuarioBuscado.Turno : adiconal.Cryptografia(usuarioAtualizado.Turno);
                usuarioBuscado.Termo = (usuarioAtualizado.Termo ==  null) ? usuarioBuscado.Termo : usuarioAtualizado.Termo;
                usuarioBuscado.IdTipoUsuario = (usuarioAtualizado.IdTipoUsuario == null) ? usuarioBuscado.IdTipoUsuario : usuarioAtualizado.IdTipoUsuario;
                usuarioBuscado.IdDados = (usuarioAtualizado.IdDados == null) ? usuarioBuscado.IdDados : usuarioAtualizado.IdDados;

                // Atualiza o usuário que foi buscado
                ctx.DbUsuarios.Update(usuarioBuscado);

                // Salva as informações para serem gravadas no banco
                ctx.SaveChanges();
            }
        }

        //Método para buscar um usuário pelo seu ID.
        public DbUsuarios BuscarPorId(int id)
        {
            using (RealVagasContext Ctx = new RealVagasContext())
            {
                // Retorna o primeiro usuário para o ID informado
                AdiconalRepository adiconal = new AdiconalRepository();

                List<DbUsuarios> usuarios = adiconal.DecodeListUsuarios(Ctx.DbUsuarios.Include(U => U.IdDadosNavigation).ToList(), false);
                DbUsuarios usuario = usuarios.FirstOrDefault(U => U.Id == id);
                usuario.IdDadosNavigation = adiconal.DecodeDados(usuario.IdDadosNavigation, false);
                return usuario;
            }
        }

        //Buscar um usuário pelo seu email.
        public DbUsuarios BuscarPorEmail(string email)
        {
            using (RealVagasContext ctx = new RealVagasContext())
            {
                AdiconalRepository adiconal = new AdiconalRepository();

                List<DbUsuarios> usuarios = adiconal.DecodeListUsuarios(ctx.DbUsuarios.Include(U => U.IdDadosNavigation).ToList(), false);

                DbUsuarios usuario = usuarios.FirstOrDefault(U => U.Email == email);

                return usuario;
            }
        }


        //Para buscar um usuario pelo Email e Senha
        public DbUsuarios BuscarPorEmailSenha(string email, string senha)
        {
            using (RealVagasContext Ctx = new RealVagasContext())
            {
                AdiconalRepository adiconal = new AdiconalRepository();

                List<DbUsuarios> usuarios = adiconal.DecodeListUsuarios(Ctx.DbUsuarios.Include(U => U.IdDadosNavigation).ToList(), false);

                 DbUsuarios usuario = usuarios.FirstOrDefault(U => U.Email == email &&
                adiconal.ValidarCodigo(U.IdDadosNavigation.Senha) == senha);

                return usuario;
            }
        }

        //Cadastrar um novo usuário no sistema.
        public void Cadastrar(DbUsuarios novoUsuario)
        {

            using (RealVagasContext ctx = new RealVagasContext())
            {
                AdiconalRepository adiconal = new AdiconalRepository();
                // Adiciona um novo usuário

                novoUsuario = adiconal.DecodeUsuario(novoUsuario, true);

                ctx.DbUsuarios.Add(novoUsuario);

                // Salva as informações para serem gravas no banco
                ctx.SaveChanges();
            }
        }

        //Deletar um usuário do sistema.
        public void Deletar(int id)
        {
            using (RealVagasContext ctx = new RealVagasContext())
            {
                // Busca um usuário através do id
                DbUsuarios usuarioBuscado = ctx.DbUsuarios.Find(id);

                // Remove o usuário que foi buscado
                ctx.DbUsuarios.Remove(usuarioBuscado);

                // Salva as alterações
                ctx.SaveChanges();
            }
        }

        //Listar todos os usuários do sistema.
        public List<DbUsuarios> Listar()
        {
            using (RealVagasContext ctx = new RealVagasContext())
            {
                AdiconalRepository adiconal = new AdiconalRepository();

                List<DbUsuarios> usuarios = ctx.DbUsuarios.Include(U => U.IdDadosNavigation).ToList();
                usuarios = adiconal.DecodeListUsuarios(usuarios, false);
                return usuarios;
            }
        }
    }
}
