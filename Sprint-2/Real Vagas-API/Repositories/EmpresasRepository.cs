using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Real_Vagas_API.Domains;
using Real_Vagas_API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Real_Vagas_API.Repositories
{
    public class EmpresasRepository : IEmpresas
    {
        public void Delete(int ID)
        {
            using (RealVagasContext Ctx = new RealVagasContext())
            {
                DbEmpresas del = SearchById(ID);
                Ctx.DbEmpresas.Remove(del);
                Ctx.SaveChanges();
            }
        }

        public void EnviarEmail(string email, int ID, string senha)
        {
            string nome = "";
            using (RealVagasContext Ctx = new RealVagasContext())
            {
                nome = Ctx.DbEmpresas.FirstOrDefault(E => E.Email == email).NomeResponsavel;
            }
            string to = email;
            string from = "group.codecreators@hotmail.com";
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Redefinir senha Real Vagas - Não Responda!!!";
            string CodigoRedefinir = GenerateCode(ID.ToString(), senha);
            message.Body = @$"Olá senhor(a) {nome} solicitação para redefinir sua senha, codigo para \n redefinir sua senha: 
            {CodigoRedefinir}. Não espalhe para ninguem usei para alterar sua senha.";
            SmtpClient client = new SmtpClient("smtp.live.com", Convert.ToInt32("587"));

            client.UseDefaultCredentials = true;
            client.Credentials = new NetworkCredential("group.codecreators@hotmail.com", "#CodeCr3at0rs");
            client.EnableSsl = true;

            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateTestMessage2(): {0}",
                    ex.ToString());
            }
        }

        public string GenerateCode(string ID, string Senha)
        {
            Random rnd = new Random();
            //string que será enviada para o usuário
            DateTime data = DateTime.Now.AddMinutes(5);
            string inicial = $"Real_Vagas:ID='{ID}±Pass:{Senha}¢data:{data};";
            string Codigo = "";
            //letra para descobrir qual hash usar;
            string[] lets = new string[] { "V", "R" };
            int num = rnd.Next(lets.Length);
            string LetraSecurity = lets[num];

            //herda os arrays da outra classe para deixa o codigo mais light 
            string[] letras = (LetraSecurity == "V") ? RedefinirRepository.PrimeiroArray() : RedefinirRepository.SegundoArray();
            string hash = (LetraSecurity == "V") ? RedefinirRepository.Hash_1() : RedefinirRepository.Hash_2();
            string[] Numbers = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

            //limpa o hash para preparação do codigo
            string hashModi = "";
            for (int i = 0; i < hash.Length; i++)
            {
                for (int h = 0; h < Numbers.Length; h++)
                {
                    string let = hash.Substring(i, 1);
                    if (let == Numbers[h])
                    {
                        hashModi += string.Concat(let);
                        break;
                    }
                }
            }

            List<string> hashs = new List<string>();

            for (int i = 0; i < hashModi.Length; i += 3)
            {
                int startIndex = i;
                int length = 3;
                string substring = hashModi.Substring(startIndex, length);
                hashs.Add(substring);
            }

            //através do hash ele transformar a string inicial em cryptografia
            char[] cod = inicial.ToArray();

            for (int i = 0; i < cod.Length; i++)
            {
                for (int j = 0; j < letras.Length; j++)
                {
                    if (cod[i].ToString() == letras[j])
                    {
                        Codigo += string.Concat(hashs[j]);
                        break;
                    }
                }
            }

            //proteger o codigo para ficar mais dificil de descodificar
            string[] letters = RedefinirRepository.Letras();
            for (int i = 0; i < Codigo.Length; i++)
            {
                int rand = rnd.Next(letters.Length);
                int go = rnd.Next(1, 11);
                if (go >= 5)
                {
                    Codigo = Codigo.Insert(i, letters[rand]);
                }
            }

            Codigo = Codigo.Insert(0, LetraSecurity);
            return Codigo;
        }

        public List<DbEmpresas> Get()
        {
            using (RealVagasContext Ctx = new RealVagasContext())
            {
                return Ctx.DbEmpresas.ToList();
            }
        }

        public DbEmpresas Login(string Email, string Senha)
        {         
            using (RealVagasContext Ctx = new RealVagasContext())
            {
                return Ctx.DbEmpresas.FirstOrDefault(U => U.Email == Email &&
                U.Senha == Senha);
            }       
        }

        public bool ModifyPass(string mody, string senha)
        {
            mody.Trim();
            //Buscar o ID na string
            string rappi = mody.Substring(mody.IndexOf("ID") + 4);
            int ho = rappi.IndexOf('±');
            int id = Convert.ToInt32(rappi.Substring(0, ho));

            //Buscar a senha na string
            string pos = mody.Substring(mody.IndexOf("Pass") + 5);
            int tilo = pos.IndexOf('¢');
            string pass = pos.Substring(0, tilo);

            //Buscar a data na string
            string jun = mody.Substring(mody.IndexOf("data") + 5, 19);
            DateTime data = Convert.ToDateTime(jun);

            if (DateTime.Now < data)
            {
                using (RealVagasContext Ctx = new RealVagasContext())
                {
                    DbEmpresas Empresa = Ctx.DbEmpresas.FirstOrDefault(E => E.Id == id);
                    Empresa.Senha = senha;
                    Ctx.DbEmpresas.Update(Empresa);
                    Ctx.SaveChanges();
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Post(DbEmpresas Empresa)
        {
            using (RealVagasContext Ctx = new RealVagasContext())
            {
                Ctx.DbEmpresas.Add(Empresa);
                Ctx.SaveChanges();
            }
        }

        public void Put(DbEmpresas Empresa)
        {
            using (RealVagasContext Ctx = new RealVagasContext())
            {
                DbEmpresas EmpresaAtual = SearchById(Empresa.Id);
                EmpresaAtual.Nome = (Empresa.Nome == null || Empresa.Nome == "") ? EmpresaAtual.Nome : Empresa.Nome;
                EmpresaAtual.Email = (Empresa.Email == null || Empresa.Email == "") ? EmpresaAtual.Email : Empresa.Email;
                EmpresaAtual.NomeResponsavel = (Empresa.NomeResponsavel == null || Empresa.NomeResponsavel == "") ? EmpresaAtual.NomeResponsavel : Empresa.NomeResponsavel;
                EmpresaAtual.RazaoSocial = (Empresa.RazaoSocial == null || Empresa.RazaoSocial == "") ? EmpresaAtual.RazaoSocial : Empresa.RazaoSocial;
                EmpresaAtual.Senha = (Empresa.Senha == null || Empresa.Senha == "") ? EmpresaAtual.Senha : Empresa.Senha;
                EmpresaAtual.Telefone = (Empresa.Telefone == null || Empresa.Telefone == "") ? EmpresaAtual.Telefone : Empresa.Telefone;
                EmpresaAtual.Cnpj = (Empresa.Cnpj == null || Empresa.Cnpj == "") ? EmpresaAtual.Cnpj : Empresa.Cnpj;

                Ctx.DbEmpresas.Update(EmpresaAtual);
                Ctx.SaveChanges();
            }
        }

        public List<DbVagas> RegisteredVacancies(int ID)
        {
            using (RealVagasContext Ctx = new RealVagasContext())
            {
                return Ctx.DbVagas.OrderBy(V => V.DataPublicacao).ToList().FindAll(V => V.IdEmpresaNavigation.Id == ID);
            }
        }

        public List<DbVagas> RegisteredVacanciesBy30Days(int ID)
        {
            using (RealVagasContext Ctx = new RealVagasContext())
            {
                DateTime result = DateTime.Now.Subtract(TimeSpan.FromDays(30));
                return Ctx.DbVagas.OrderBy(V => V.DataPublicacao).Where(V => V.DataPublicacao > result)
                .ToList().FindAll(V => V.IdEmpresaNavigation.Id == ID);
            }
        }

        public List<DbInscricao> ResumesReceived(int ID)
        {
            using (RealVagasContext Ctx = new RealVagasContext())
            {
                return Ctx.DbInscricao.ToList().FindAll(I => I.IdVagaNavigation.IdEmpresaNavigation.Id == ID);
            }
        }

        public List<DbInscricao> ResumesReceivedBy30Days(int ID)
        {
            using (RealVagasContext Ctx = new RealVagasContext())
            {
                DateTime result = DateTime.Now.Subtract(TimeSpan.FromDays(30));
                return Ctx.DbInscricao.OrderBy(V => V.StatusInscricao == true).Where(V => V.IdVagaNavigation.DataPublicacao > result)
                .ToList().FindAll(V => V.IdVagaNavigation.IdEmpresaNavigation.Id == ID);
            }
        }

        public List<DbInscricao> ResumesReceivedByVacancies(int ID)
        {
            using (RealVagasContext Ctx = new RealVagasContext())
            {
                return Ctx.DbInscricao.ToList().FindAll(I => I.IdVaga == ID);
            }
        }

        public DbEmpresas SearchByEmpresa(string Email, string Cnpj)
        {
            using (RealVagasContext Ctx = new RealVagasContext())
            {
                return Ctx.DbEmpresas.FirstOrDefault(E => E.Email == Email || E.Cnpj == Cnpj);
            }
        }

        public DbEmpresas SearchById(int ID)
        {
            using (RealVagasContext Ctx = new RealVagasContext())
            {
                return Ctx.DbEmpresas.FirstOrDefault(E => E.Id == ID);
            }
        }

        public string ValidateCode(string str)
        {
            string codigo = "";
            string LetraSecurity = str.Substring(0, 1);

            //herda os arrays da outra classe para deixa o codigo mais light 
            string[] letras = (LetraSecurity == "V") ? RedefinirRepository.PrimeiroArray() : RedefinirRepository.SegundoArray();
            string hash = (LetraSecurity == "V") ? RedefinirRepository.Hash_1() : RedefinirRepository.Hash_2();
            string[] Numbers = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

            //limpa o hash para preparação do codigo
            string hashModi = "";
            for (int i = 0; i < hash.Length; i++)
            {
                for (int h = 0; h < Numbers.Length; h++)
                {
                    string let = hash.Substring(i, 1);
                    if (let == Numbers[h])
                    {
                        hashModi += string.Concat(let);
                        break;
                    }
                }
            }
            //limpa o string recebida 
            string Strlimpo = "";
            for (int i = 0; i < str.Length; i++)
            {
                for (int h = 0; h < Numbers.Length; h++)
                {
                    string let = str.Substring(i, 1);
                    if (let == Numbers[h])
                    {
                        Strlimpo += string.Concat(let);
                        break;
                    }
                }
            }

            List<string> max = new List<string>();
            for (int i = 0; i < hashModi.Length; i += 3)
            {
                int startIndex = i;
                int length = 3;
                string substring = hashModi.Substring(startIndex, length);
                max.Add(substring);
            }
            List<string> hulk = new List<string>();
            for (int i = 0; i < Strlimpo.Length; i += 3)
            {
                int startIndex = i;
                int length = 3;
                string substring = Strlimpo.Substring(startIndex, length);
                hulk.Add(substring);
            }

            string nova = "";
            for (int i = 0; i < hulk.Count; i++)
            {
                for (int h = 0; h < max.Count; h++)
                {
                    if (hulk[i].ToString() == max[h].ToString())
                    {
                        nova += letras[h];
                        break;
                    }
                }
            }
            codigo = nova;

            return codigo;
        }

        public bool VerificarCnpj(string cnpj)
        {
            bool verify = false;
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Url = "https://www.situacao-cadastral.com/";

                IWebElement text = driver.FindElement(By.Id("doc"));

                string valor = cnpj;
                char[] count = valor.ToCharArray();
                int cot = 0;
                char[] nums = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                for (int i = 0; i < valor.Length; i++)
                {
                    for (int j = 0; j < nums.Length; j++)
                    {
                        if (count[i] == nums[j])
                        {
                            cot += 1;
                        }
                    }
                }
                text.SendKeys(valor);

                IWebElement consultar = driver.FindElement(By.Id("consultar"));

                consultar.Click();
                System.Threading.Thread.Sleep(2 * 1000);

                if (driver.FindElement(By.ClassName("vrd")).Displayed)
                {
                    IWebElement ativo = driver.FindElement(By.ClassName("vrd"));
                    verify = (ativo.Text == "Situação: Ativa" || ativo.Text == "Situação: Regular") ? true : false;
                }
                else if (driver.FindElement(By.Id("mensagem")).Displayed)
                {
                    IWebElement ativo = driver.FindElement(By.Id("mensagem"));
                    verify = (ativo.Text == "CNPJ inválido") ? true : false;
                }
                else if (driver.FindElement(By.ClassName("vrm")).Displayed)
                {
                    IWebElement ativo = driver.FindElement(By.ClassName("vrm"));
                    verify = (ativo.Text == "Situação: Inexistente") ? true : false;
                }
                driver.Close();
                driver.Quit();
            }
            return verify;
        }
    }
}
