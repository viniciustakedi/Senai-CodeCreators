using System;
using System.Collections.Generic;

namespace Real_Vagas_API.Domains
{
    public partial class DbEmpresas
    {
        public DbEmpresas()
        {
            DbVagas = new HashSet<DbVagas>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeResponsavel { get; set; }
        public string Senha { get; set; }
        public int? IdTipoUsuario { get; set; }

        public DbTipoUsuario IdTipoUsuarioNavigation { get; set; }
        public ICollection<DbVagas> DbVagas { get; set; }
    }
}
