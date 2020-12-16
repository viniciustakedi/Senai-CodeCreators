using System;
using System.Collections.Generic;

namespace Real_Vagas_API.Domains
{
    public partial class DbUsuarios
    {
        public DbUsuarios()
        {
            DbInscricao = new HashSet<DbInscricao>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Escola { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string EstadoCivil { get; set; }
        public string UrlCurriculo { get; set; }
        public string Nivel { get; set; }
        public string TipoCurso { get; set; }
        public string Curso { get; set; }
        public string Turma { get; set; }
        public string Turno { get; set; }
        public int? Termo { get; set; }
        public int? IdTipoUsuario { get; set; }
        public int? IdDados { get; set; }

        public DbDados IdDadosNavigation { get; set; }
        public DbTipoUsuario IdTipoUsuarioNavigation { get; set; }
        public ICollection<DbInscricao> DbInscricao { get; set; }
    }
}
