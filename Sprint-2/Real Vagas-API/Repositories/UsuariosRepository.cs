using Microsoft.Data.SqlClient;
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
        private string stringConexao = "Data completar depois";
        RealVagasContext ctx = new RealVagasContext();
        public void Atualizar(int id, DbUsuarios usuarioAtualizado)
        {
            // Busca um usuário através do id
            DbUsuarios usuarioBuscado = ctx.DbUsuarios.Find(id);

            // Atribui os novos valores ao campos existentes
            usuarioBuscado.Nome = usuarioAtualizado.Nome;
            usuarioBuscado.DataNascimento = usuarioAtualizado.DataNascimento;
            usuarioBuscado.Sexo = usuarioAtualizado.Sexo;
            usuarioBuscado.Escola = usuarioAtualizado.Escola;
            usuarioBuscado.Email = usuarioAtualizado.Email;
            usuarioBuscado.Telefone = usuarioAtualizado.Telefone;
            usuarioBuscado.EstadoCivil = usuarioAtualizado.EstadoCivil;
            usuarioBuscado.Nivel = usuarioAtualizado.Nivel;
            usuarioBuscado.TipoCurso = usuarioAtualizado.TipoCurso;
            usuarioBuscado.Curso = usuarioAtualizado.Curso;
            usuarioBuscado.Turma = usuarioAtualizado.Turma;
            usuarioBuscado.Turno = usuarioAtualizado.Turno;
            usuarioBuscado.Termo = usuarioAtualizado.Termo;
            usuarioBuscado.IdTipoUsuario = usuarioAtualizado.IdTipoUsuario;
            usuarioBuscado.IdDados = usuarioAtualizado.IdDados;

            // Atualiza o usuário que foi buscado
            ctx.DbUsuarios.Update(usuarioBuscado);
            ctx.DbUsuarios.Update(usuarioBuscado);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        public DbUsuarios BuscarPorId(int id)
        {
            // Retorna o primeiro usuário para o ID informado
            return ctx.DbUsuarios.FirstOrDefault(u => u.Id == id);
        }


        //Para buscar um usuario pelo Email e Senha
        //Takedi fez essa parte então se der algum erro só comunicar.
        public DbUsuarios BuscarPorEmailSenha(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Query para o data base
                string query = "SELECT Email, Senha FROM DbUsuarios INNER JOIN DbDados ON DbDados.ID  = DbUsuarios.IdDbDados";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if(reader.Read())
                    {
                        DbUsuarios usuario = new DbUsuarios(); //Para chamar o usuario domain mais rapido
                        DbDados dado = new DbDados();
                        usuario.Id = Convert.ToInt32(reader["IdDbUsuarios"]);
                        usuario.Email = reader["Email"].ToString();
                        dado.Senha = reader["Senha"].ToString();

                        return usuario;
                        
                    }
                }
                return null;
            }
        }
          

        public void Cadastrar(DbUsuarios novoUsuario)
        {
            // Adiciona um novo usuário
            ctx.DbUsuarios.Add(novoUsuario);

            // Salva as informações para serem gravas no banco
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            // Busca um usuário através do id
            DbUsuarios usuarioBuscado = ctx.DbUsuarios.Find(id);

            // Remove o usuário que foi buscado
            ctx.DbUsuarios.Remove(usuarioBuscado);

            // Salva as alterações
            ctx.SaveChanges();
        }

        public List<DbUsuarios> Listar()
        {
            return ctx.DbUsuarios.ToList();
        }
    }
}
