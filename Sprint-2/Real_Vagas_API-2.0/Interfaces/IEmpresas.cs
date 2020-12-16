using Real_Vagas_API.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Vagas_API.Interfaces
{ 
    public interface IEmpresas
    {
        //Interface para cadastrar uma empresa.
        void Post(DbEmpresas Empresa);
        //Interface para listar todas as empresas.
        List<DbEmpresas> Get();
        //Interface para atualizar uma empresa.
        void Put(DbEmpresas Empresa);
        //Interface para deletar uma empresa.
        void Delete(int ID);
        //Interface para buscar uma empresa pelo seu ID.
        DbEmpresas BuscarPorId(int ID);
        //Interface para fazer login de uma empresa no sistema.
        DbEmpresas Login(string Email, string Senha);
        //Interface para buscar uma empresa pelo email o cnpj.
        DbEmpresas BuscarPorEmpresa(string Email, string Cnpj);
        //Interface para buscar todos as vagas cadastras nós últimos 30 dias.
        List<DbVagas> VagasCadastradas30Dias(int ID);
        //Interface para buscar todos as inscrições recebidas nós últimos 30 dias.
        List<DbInscricao> InscricoesRecebidas30Dias(int ID);

    }
}
