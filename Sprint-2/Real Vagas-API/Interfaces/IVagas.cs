using Real_Vagas_API.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Vagas_API.Interfaces
{
    public interface IVagas
    {
        public List<DbVagas> ListaVagas();
        public DbVagas BuscarPorId(int Id);
        public void Cadastrar(DbVagas VagaNova);
        public void Atualizar(int Id, DbVagas VagaAtualizada);
        public void Deletar(int Id);

        public List<DbVagas> ListaByIdEmpresa(int Id);
        public DbVagas BuscarPorLocal(string localVaga);
        public DbVagas BuscarPorCargo(string Cargo);
        public DbVagas BuscarPorData(DateTime DataPublicacao);
        public DbVagas BuscarPorNomeEmpresa(string EmpresaNome);
    }
}
