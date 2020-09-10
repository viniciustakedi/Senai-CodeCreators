using System;
using System.Collections.Generic;

namespace Real_Vagas_API.Domains
{
    public class DbTipoUsuarioDomain
    {
        public DbTipoUsuarioDomain()
        {
            DbEmpresas = new HashSet<DbEmpresas>();
            DbUsuarios = new HashSet<DbUsuarios>();
        }

        public int Id { get; set; }
        public string Titulo { get; set; }

        public virtual ICollection<DbEmpresas> DbEmpresas { get; set; }
        public virtual ICollection<DbUsuarios> DbUsuarios { get; set; }
        public int IDDbTipoUsuario { get; set; }
    }
}
