using Real_Vagas_API.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Vagas_API.Interfaces
{
    public interface IVagas
    {
        //Listar todas as vagas do sistema.
         List<DbVagas> ListaVagas();
        //Buscar uma vaga pelo seu ID.
         DbVagas BuscarPorId(int Id);
        //Cadastrar uma nova vaga.
         void Cadastrar(DbVagas VagaNova);
        //Atualizar uma vaga pelo seu ID e body.
         void Atualizar(int Id, DbVagas VagaAtualizada);
        //Deletar uma vaga pelo seu ID.
         void Deletar(int Id);

        //Listar todas vagas de uma empresa.
         List<DbVagas> ListaByIdEmpresa(int Id);
    }
}
