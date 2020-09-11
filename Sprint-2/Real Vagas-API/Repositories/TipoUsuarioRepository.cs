using Microsoft.Data.SqlClient;
using Real_Vagas_API.Domains;
using Real_Vagas_API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Vagas_API.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuario
    {
        //para reconhecer o banco de dados takedi
        private string stringConexao = "Data Source=LAPTOP-QQ7IRANA\\SQLEXPRESS; initial catalog=RealVagas; user Id=sa; pwd=takedi79";


        //Repository para atualizar tipo usuario por Id
        public void AtualizarTipoUsuarioId(int id, DbTipoUsuarioDomain tipousuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "UPDATE DbTipoUsuario SET Titulo = @Titulo WHERE IDDbTipoUsuario = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Titulo", tipousuario.Titulo);

                    con.Open();
                    cmd.ExecuteNonQuery();

                }
            }
        }


        //Buscar tipo usuario por Id
        public DbTipoUsuarioDomain BuscarId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string query = "SELECT IDDbTipoUsuario, Titulo FROM DbTipoUsuario where IDDbTipoUsuario = @ID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        DbTipoUsuarioDomain tipousuario = new DbTipoUsuarioDomain();
                        tipousuario.IDDbTipoUsuario = Convert.ToInt32(reader[0]);
                        tipousuario.Titulo = reader["Titulo"].ToString();

                        return tipousuario;
                    }
                    return null;
                }
            }
        }

        //Repository para cadastrar um novo tipo de usuario
        public void Cadastrar(DbTipoUsuarioDomain tipousuario)
        {

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO DbTipoUsuario(Titulo) VALUES (@Titulo)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Titulo", tipousuario.Titulo);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        //Deletar um Tipo Usuario 
        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM DbTipoUsuario WHERE IDDbTipoUsuario = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        //Listar todos os tipos de usuarios
        public List<DbTipoUsuarioDomain> Listar()
        {
            List<DbTipoUsuarioDomain> tipousuarios = new List<DbTipoUsuarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT IDDbTipoUsuario, Titulo FROM DbTipoUsuario";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        DbTipoUsuarioDomain tipousuario = new DbTipoUsuarioDomain
                        {
                            IDDbTipoUsuario = Convert.ToInt32(rdr[0]),
                            Titulo = rdr["Titulo"].ToString()
                        };
                        tipousuarios.Add(tipousuario);
                    }
                }
            }
            return tipousuarios;
        }
    }
}

