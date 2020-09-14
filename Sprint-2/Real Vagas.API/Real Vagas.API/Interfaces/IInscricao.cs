using Real_Vagas.API.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Vagas.API.Interfaces
{
    interface IInscricao
    {
        List<DbInscricao> Listar();

        DbInscricao BuscarPorId(int id);

        void Deletar(int id);

        void Atualizar(int id, DbInscricao InscricaoAtulizada);

       
    }
}
