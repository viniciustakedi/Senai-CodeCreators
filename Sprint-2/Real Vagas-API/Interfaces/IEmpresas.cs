using Real_Vagas_API.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Vagas_API.Interfaces
{
    interface IEmpresas
    {
        void Post(DbEmpresas Empresa);
        List<DbEmpresas> Get();
        void Put(DbEmpresas Empresa);
        void Delete(int ID);
        DbEmpresas SearchById(int ID);
        DbEmpresas SearchByEmpresa(string Email, string Cnpj);
        List<DbVagas> RegisteredVacancies(int ID);
        List<DbVagas> RegisteredVacanciesBy30Days(int ID);
        List<DbInscricao> ResumesReceived(int ID);
        List<DbInscricao> ResumesReceivedBy30Days(int ID);
        List<DbInscricao> ResumesReceivedByVacancies(int ID);

    }
}
