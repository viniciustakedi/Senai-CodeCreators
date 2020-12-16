using Real_Vagas_API.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Vagas_API.Interfaces
{
    public interface IAdicional
    {
        void EnviarEmail(string email, int ID, string senha);
        //Interface gerar um código para redefinir sua senha que é enviado para email da pessoa.
        string GerarCodigo(string ID, string Senha, bool user);
        //Interface validar o código recebido pela pessoa.
        string ValidarCodigo(string str);
        //Interface modificar a senha do usuário através do código recebido.
        string ModifyPass(string mody, string senha);
        //Interface para buscar uma empresa pelo email o cnpj.
        DbEmpresas BuscarPorEmpresa(string Email, string Cnpj);
        //Cryptografa os dados
        string Cryptografia(string str);
        //string de conexão cryptografada
        string conexao(string str);

        DbUsuarios DecodeUsuario(DbUsuarios objeto, bool state);
        List<DbUsuarios> DecodeListUsuarios(List<DbUsuarios> objetos, bool state);

        DbDados DecodeDados(DbDados objeto, bool state);
        List<DbDados> DecodeListDados(List<DbDados> objetos, bool state);

        DbEmpresas DecodeEmpresa(DbEmpresas objeto,bool state);
        List<DbEmpresas> DecodeListEmpresas(List<DbEmpresas> objetos, bool state);
    }
}
