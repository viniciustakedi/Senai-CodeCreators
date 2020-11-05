using Real_Vagas_API.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Vagas_API.Interfaces
{
    public interface IInscricao
    {
        List<DbInscricao> Listar();

        DbInscricao BuscarPorId(int id);

        void Cadastrar(DbInscricao inscricao);
        List<DbInscricao> ListarById(int id);
        void Deletar(int id);

        void Atualizar(int id, DbInscricao InscricaoAtulizada);


    }
}
