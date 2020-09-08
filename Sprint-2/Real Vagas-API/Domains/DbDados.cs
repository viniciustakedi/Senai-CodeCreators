using System;
using System.Collections.Generic;

namespace Real_Vagas_API.Domains
{
    public partial class DbDados
    {
        public DbDados()
        {
            DbUsuarios = new HashSet<DbUsuarios>();
        }

        public int Id { get; set; }
        public string Cpf { get; set; }
        public string NumMatricula { get; set; }
        public string Senha { get; set; }

        public virtual ICollection<DbUsuarios> DbUsuarios { get; set; }
    }
}
