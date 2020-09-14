using System;
using System.Collections.Generic;

namespace Real_Vagas.API.Domains
{
    public partial class DbVagas
    {
        public DbVagas()
        {
            DbInscricao = new HashSet<DbInscricao>();
        }

        public int Id { get; set; }
        public string NomeRecrutador { get; set; }
        public string LocalVaga { get; set; }
        public string TipoContrato { get; set; }
        public DateTime? DataPublicacao { get; set; }
        public string Cargo { get; set; }
        public int? QntVagas { get; set; }
        public decimal? Salario { get; set; }
        public string Descricao { get; set; }
        public byte[] Foto { get; set; }
        public bool? StatusVaga { get; set; }
        public int? IdEmpresa { get; set; }

        public virtual DbEmpresas IdEmpresaNavigation { get; set; }
        public virtual ICollection<DbInscricao> DbInscricao { get; set; }
    }
}
