using Real_Vagas_API.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Vagas_API.Interfaces
{
    public interface IInscricao
    { 
        //Listar todas inscrições cadastradas.
        List<DbInscricao> Listar();
        //Buscar uma inscrição pelo ID.
        DbInscricao BuscarPorId(int id);
        //Cadastrar uma nova inscrição.
        void Cadastrar(DbInscricao inscricao);
        //Listar todas inscrições de determinado usuário.
        List<DbInscricao> ListarById(int id);
        //Listar todas inscrições que uma empresa recebeu.
        List<DbInscricao> ListarByIdEmpresa(int id);
        //Listar todas inscrições de determinada vaga.
        List<DbInscricao> ListarByIdVaga(int id);
        //Deletar uma inscrição do sistema.
        void Deletar(int id);
        //Atualizar uma inscrição.
        void Atualizar(int id, DbInscricao InscricaoAtulizada);


    }
}
