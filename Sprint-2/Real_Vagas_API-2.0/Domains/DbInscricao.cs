using System;
using System.Collections.Generic;

namespace Real_Vagas_API.Domains
{
    public partial class DbInscricao
    {
        public int Id { get; set; }
        public bool? StatusInscricao { get; set; }
        public DateTime? DataInscricao { get; set; }
        public int? IdVaga { get; set; }
        public int? IdUsuario { get; set; }

        public DbUsuarios IdUsuarioNavigation { get; set; }
        public DbVagas IdVagaNavigation { get; set; }
    }
}
