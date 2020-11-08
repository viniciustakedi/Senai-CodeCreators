using Real_Vagas_API.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Vagas_API.Interfaces
{
    public interface IVagas
    {
         List<DbVagas> ListaVagas();
         DbVagas BuscarPorId(int Id);
         void Cadastrar(DbVagas VagaNova);
         void Atualizar(int Id, DbVagas VagaAtualizada);
         void Deletar(int Id);

         List<DbVagas> ListaByIdEmpresa(int Id);
         DbVagas BuscarPorLocal(string localVaga);
         DbVagas BuscarPorCargo(string Cargo);
         DbVagas BuscarPorData(DateTime DataPublicacao);
         DbVagas BuscarPorNomeEmpresa(string EmpresaNome);
    }
}
