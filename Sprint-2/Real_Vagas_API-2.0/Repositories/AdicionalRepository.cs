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
    public class AdiconalRepository : IAdicional
    { 
        public static string conect()
        {
            string str = "RQ1c5lVoKA9fYdFh8337pz1UT7avQZ6R1O7f999V5Yg8Era0cLzsAp7T02l7np1K7p8l5y0xRQA8ABK6X17R0dtQoTyd28G33B8McHLRFy6M1eWmP7879Ur8nE5" +
                "7A17O8Hkh3U32i73EkFbmu82j9Xy389Ft7M1Aak79BNp855Ft1Ot3DMORWMLjmvu78711zudy9dlj8Bb0zbTak95Fb80QfaOc70tZqC2HBRt71tKS7v51B38498X0066e67F" +
                "1mYYI7LG85c0wuv86o1D6x6pgI68zrz3s3m673s7kTS87i985wz19tTN8nfon8Px33C2xHctuM73bL8sWwE49";
            return str;
        }
        public static string[] PrimeiroArray()
        {
            string[] letter = {"\\","<","½","r","A","H","c","~","Ü","Ñ","?","P","±","¹","4","u","Q","ª","Á","å","|","C","1","Ð","b","Ú","Þ","W",
            " ","ß","¸","ë","O","`","É","m","Î","_","º","B","J","Ê","X","Ë","³","y","V","¶","í","é",")","ù","Ç",">","f","K","M","÷","«","d","Ö",
            "¡","è","j","ã","á","ç","Ó","¦","Ø",".","e","G","×","À","Í","^","D","ú","*","q","!","ü","t","3","L","'","F","%","ø","Ý","$",";","Û",
            "g","&","©","§","U","o","0","p","Æ","Ã","h","¥","â","E","(",":","þ","Y",",","I","ö","+","õ","{","[","Ò","#","û","·","¿","ð","8","a",
            "²","®","¼","¯","à","T","Õ","µ","5","ò","v","l","Ï","£","w","@","¢","´","n","6","î","Ô","z","ô","-","\"","ó","9","æ","Å","ì","2","ñ",
            "ä","ï","ý","}","Z","i","]","ê","7","¬","Ä","Ù","¤","»","/","S","°","¾","R","x","=","¨","ÿ","N","È","k","Ì","Â","s"};

            return letter;
        }

        public static string[] SegundoArray()
        {
            string[] letter ={"Æ","ú","Þ","ÿ","c","«","M","E","ç","¤","9","@","³","è","¼","l","p","(","/","U","^","=","¦","õ","Ø","ß","¯",";",
            "¢","e","®"," ","f","Ì","·","ñ","ë","¿","u","º","ö","3","Î","5","x",":","]","m","Q","ô","L","T","C","Ê","!","´","å","¥","q",")","Â","?",
            "\\","Ý","È","{","Ë","j","A","µ","o","h","Ñ","G","[","+","W","»","R","û","ï","¸","à","Ä","÷","§","ä","n","4","t","×","|","Õ","6","é",
            "î",">","Ó","Ð","d","Ç","0","~","¡","X","Ã","í","Ü","ü","-","ã","S","k","`","g","ì","J","Ú","'","¶","s","F","Í","ý","ð","Z","#","æ",
            "r","%","Ù","B","É","O","&","â","£","ù","\"","ó","*","w","¾","þ","y","À","±","Û","Ô","¨","z","ò","V","_","I","i","2","7","1","Ï","Å",
            "P","b",".","8","ê","Y","²","K","N","¬","v","D","$","Á","H","á","Ò","<","ª",",","ø","}","¹","½","°","©","a","Ö"};

            return letter;
        }

        public static string Hash_1()
        {
            string letter = "k5513577lA7874882810LKp44Tx666784h882x4957042v5I90747232UW876959iFU7362W5086I02nP108y6442L03t5" +
                "myD6491249FMHT2Y7364dFb8cY4as63532c4s343v9735866gz487J14f160Q2f9I32aFl04F376906Q438E7572c67o4541x33tJ156749" +
                "6E8y05yO6854er776U7Z4D204m211982D7225431i38nI36435H368L98l214r326B4b90559683T8L35975t82m685759X86350JA4D765" +
                "Uk3vAKt1855k74M2w1559E15187A556BPP92365H280697g994To16374AU561035485363L1749092139E997137543DN4819l9HF3QX39" +
                "225z305teXY04782z98i069216sU6K9h5r570794ETT4o4Fk50c8F83V952q3632Gm23145964D80usa847nef330F199435223361j5216" +
                "28b0589cVh833554QF553i5a00297w3873r48P424D3rgjd8x9P7l59g39j55RR6o559286s7U60RH7d96i913e647m5X25138885422f4G" +
                "386157Vz3y03a7884aNk434U40180550527Ak4932108cB9kM542967L6k862uU39f87966405C1987W517s7q7355GVkr0Mu1770Y7r4n4" +
                "263q5I79T7x41O1283L009784Yj3s0ECy2c663L1VU85W099k20I868I17248227n83H93";

            return letter;
        }

        public static string Hash_2()
        {

            string letter = "474515KHvm8789Z1C67023s5c54w5288g261829y16288wO29Iv32717c81878l0999990jY714849514p24z2f262Y56XN" +
                "cs5952i87j3274dz68g4Ea9TbA47286137258II3Y2F9375y5SL97b887S517jW43E8161oA76926486737398E8P5486C7722T98513s28" +
                "44U9649944y2666k2yIn451528893sxA19k48eW7u9x6VzV9X60p860250tFmIGT97579o1W8h1456iB3r6Bn57G2199zq31ZI2r7NTil34" +
                "717m38945mu5N8a4LX64V687488uB867731419605h484362O88464y8ZHPPv7n2x24V0b62660992Qh6sA98N58I5q589k364r7Pwe1841" +
                "462Ku6x49VQ15820k840850300198lq301e5lky497782X09L9868197774d03ou1035B4544C5p1091U59Zb266p32r0u39LvZ3904l9o6" +
                "2273ev32Y6F8gf79823Z74237u180oGC0304cz8Y33v1C65z9332w907r5Y9g45c0s2356c85H763zK2X538Ya068Y3T2X62U2981p40963" +
                "f712e4943kH7749A3Z6tREN338D92497zb46E6D9i9pEtD554667151195G70937P612l2e5I4349709z13158070n7N3q837yz5Y0h3032" +
                "i29syQU65T13c453H7S52I053479213603113GTS919T9sE74495215252C6X11707LILASz3bc03Nf96538J78714wsT3";

            return letter;
        }

        public static string[] Letras()
        {
            string[] Letters = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m",
            "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D",
            "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U",
            "V", "W", "X", "Y", "Z" };

            return Letters;
        }

        //Enviar email para redefinir a senha do usuário.
        public void EnviarEmail(string email, int ID, string senha)
        {
            string nome = "";
            bool user;
            using (RealVagasContext Ctx = new RealVagasContext())
            {
                if (Ctx.DbEmpresas.FirstOrDefault(E => E.Email == email) != null)
                {
                    nome = Ctx.DbEmpresas.FirstOrDefault(E => E.Email == email).NomeResponsavel;
                    user = false;
                }
                else
                {
                    nome = Ctx.DbUsuarios.FirstOrDefault(E => E.Email == email).Nome;
                    user = true;
                }
            }
            string str = AdiconalRepository.conect();
            string conect = ValidarCodigo(str);

            string Real = conect.Substring(0, conect.IndexOf(';'));
            int cot = conect.Substring(conect.IndexOf(';') + 1).Length;
            string vagas = conect.Substring(conect.IndexOf(';') + 1, cot - 1);
            string to = email;
            string from = Real;
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Redefinir senha Real Vagas - Não Responda!!!";
            string CodigoRedefinir = GerarCodigo(ID.ToString(), senha, user);
            message.Body = $"Olá senhor(a) {nome} solicitação para redefinir sua senha, codigo para \n redefinir sua senha: {CodigoRedefinir}. Não espalhe para ninguem usei para alterar sua senha.";
            SmtpClient client = new SmtpClient("smtp.live.com", Convert.ToInt32("587"));

            client.UseDefaultCredentials = true;
            client.Credentials = new NetworkCredential(Real, vagas);
            client.EnableSsl = true;

            try
            {
                client.Send(message);
            }
            catch
            {
                Console.WriteLine("Ocorreu um erro ao enviar seu email de redefinir senha!!!");
            }
        }

        //Gerar um código para redefinir a senha do usuário.
        public string GerarCodigo(string ID, string Senha, bool user)
        {
            Random rnd = new Random();
            //string que será enviada para o usuário
            DateTime data = DateTime.Now.AddMinutes(5);
            string inicial = $"¤={user}/Real_Vagas:ID='{ID}±Pass:{Senha}¢data:{data};";
            string Codigo = "";
            //letra para descobrir qual hash usar;
            string[] lets = new string[] { "V", "R" };
            int num = rnd.Next(lets.Length);
            string LetraSecurity = lets[num];

            //herda os arrays da outra classe para deixa o codigo mais light 
            string[] letras = (LetraSecurity == "V") ? PrimeiroArray() : SegundoArray();
            string hash = (LetraSecurity == "V") ? Hash_1() : Hash_2();
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
            string[] letters = Letras();
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

        //Validar código recebido para redefinir a senha.
        public string ValidarCodigo(string str)
        {
            try
            {
                string codigo = "";
                string LetraSecurity = str.Substring(0, 1);

                //herda os arrays da outra classe para deixa o codigo mais light 
                string[] letras = (LetraSecurity == "V") ? PrimeiroArray() : SegundoArray();
                string hash = (LetraSecurity == "V") ? Hash_1() : Hash_2();
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
            catch
            {
                return "";
            }
        }

        public string ModifyPass(string mody, string senha)
        {
            mody.Trim();
            //Buscar o user na string
            string tag = mody.Substring(mody.IndexOf("¤") + 2);
            int sol = tag.IndexOf('/');
            bool user = Convert.ToBoolean(tag.Substring(0, sol));

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
                if (user != true)
                {
                    using (RealVagasContext Ctx = new RealVagasContext())
                    {
                        DbEmpresas Empresa = Ctx.DbEmpresas.FirstOrDefault(E => E.Id == id);
                        Empresa.Senha = senha;
                        Ctx.DbEmpresas.Update(Empresa);
                        Ctx.SaveChanges();
                    }
                    return "Senha da empresa atualizado com sucesso!!!";
                }
                else
                {
                    using (RealVagasContext Ctx = new RealVagasContext())
                    {
                        DbUsuarios usuario = Ctx.DbUsuarios.FirstOrDefault(E => E.Id == id);
                        usuario.IdDadosNavigation.Senha = senha;
                        Ctx.DbUsuarios.Update(usuario);
                        Ctx.SaveChanges();
                    }
                    return "Senha do usuário atualizado com sucesso!!!";
                }
            }
            else
            {
                return "Não autenticado";
            }
        }

        public DbEmpresas BuscarPorEmpresa(string Email, string Cnpj)
        {
                using (RealVagasContext Ctx = new RealVagasContext())
                {
                    AdiconalRepository adiconal = new AdiconalRepository();

                    List<DbEmpresas> empresas = adiconal.DecodeListEmpresas(Ctx.DbEmpresas.ToList(), false);

                    DbEmpresas empresa = empresas.FirstOrDefault(U => U.Email == Email || U.Cnpj == Cnpj);

                    return empresa;
                }        
        }

        public string Cryptografia(string str)
        {
            Random rnd = new Random();
            string inicial = str;
            string Codigo = "";
            //letra para descobrir qual hash usar;
            string[] lets = new string[] { "V", "R" };
            int num = rnd.Next(lets.Length);
            string LetraSecurity = lets[num];

            //herda os arrays da outra classe para deixa o codigo mais light 
            string[] letras = (LetraSecurity == "V") ? PrimeiroArray() : SegundoArray();
            string hash = (LetraSecurity == "V") ? Hash_1() : Hash_2();
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
            string[] letters = Letras();
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

        public string conexao(string str)
        {
            string connection = "";
            if (str == "Henrique")
            {
                connection = "VB74RukGH13O507mejn48kCb5653E5Jqr074arjqbw8K2anK6ybSZf6RsZY6nja3kQz7SMa82mV84253485gThSk8n6kj42TG5k7n88nc5867ZjoN075vsq8wkW6933637pt31WVmkI3Uw58QHtM6KE64OUL4iBRNkd5j5i17wuw41JY5Xw" +
                    "976NoH377kMR07NWR2V6H7wkqaN425x9Y787WhZZ0774YEp1io74jYzltn1qa9z219qlw158Li3u3ycNaGcE979Tjv8DJe3TT39i1283x3bZo3N93jdsL350hBNXJXDgB26cmwkn6b9v7OKq8I3kW5nM0833sqzewdg592fAzv74Pn9uHDuNNa8exwb3" +
                    "VisE3KRkhUgI97R18I3339vfB3Bio9vdVZo2F1Vok34Je87M4gImGF8bjSdE7zFj6a9fxzJUI3r9B3ci9N7j93yYv5Z0AomFCL3R682F0V4Je64EDPU4KQR92y2b3vs883E8A8m3vTKO5B04Yp66rzn97aMv96v4jq09s2fl2R38826X6PwLB34ST87V" +
                    "48i76QZ93n509va2t1";

            } else if (str == "Fabiane")
            {
                connection = "Rk2CB0YgU5d8ly8Q2m5V4F5yAj2SH2KVSbsFPXpMcmT94dC42Fq4r5p0j7DFfIrbV0ZB94032NQ0A5WO6x12uq3W20U4a995sH4rW519Ojz86FM12757X5icHzYNiXD452hw8Jdbd4r4998827O7eyjQvKd8OT7DKON0liY9u1waztZGlf4XM188XC2v54Al55q45";
            }
            else if (str == "Vinicius")
            {
                connection = "VGef74HkIQv1WxoZS350Lef748DQf5xAh65dFWUc3Ps5I0t74r8nn26b66Q378ejDpqn2JxCL8go425AGCWhdaTO3t4SC85h8Wv642O57vPFI8Nj8VVi5jgZK9RhEp7B5F9fjVN7O1f77dCBDY2g23MZ9TxqlNgYZ7Qj8DOo82G8x9Ctu2pa" +
                    "a0Tk8vj28CKWP551m7Zn41hMs597z6j377mtNdP0U7n2674KQk2CEB5t9r78z70A77xsb4sYQ17c41V2yP1tQ0pQD5pdgsoE3Q0WCmBAkQ20LQWl3n1raJ8r09jqq21ElEvb9Y1R5mJH833p9HHb7OH98J33O9ZA1t2Sr8dZT3t33aaS9U3DzBT3XlJh5" +
                    "026CFSy6F9lY783508335W927QId4v98K3e3m9I71OBI8ZUyqO3pVx3b39w392Gt1K3FcBX48D7wWO48i769ypU39ae3L9uL79hHb3R5hImiIzYHMg036w8qPc2C0A46T44mL9xwh2UkXz2E38Gi8Z3hNDrkH8Uqc8350xWwtZJ4gLD6MG6GRv97sQy96" +
                    "40E9eV2238ENAi82varQ6qkp6D34tI8EJqs7487wzc69sg3HFVqf5d09pq2l1";
            }
            else if (str == "Gabriel")
            {
                connection = "VTHlV7I41ws3F5mLFRg0748565F3oS507A4h82V6OrE6i6ZSH37y8C2fubR8r4RZl25KrFYJKS348586gqD4257kP8b8a9zw338uPNPh5vYs42Y0Us3Gx63n7o20To37i5ihu94W3F8l10M455Kr1ddyO7O4mY1lmtb5P9dQ7q637bVu7072" +
                    "V6OY7Y425VG97YEw8e7qdZBg07h74V174m1tX2V10pZI5qlsL3G020S3szX1A8K092ENqKr19km1pQPJZBgB58L3beEY39FJmQY798IEB33tU9TqrPM1u2Hg8zW33393Y3bbOS502GcbGFX6Lq6uj978z3wfU5abiX0oJAA83V35CR9R27s49JdX8lKQG" +
                    "hoUWd33M97eVl1R8wRf33z393j92Y1K3p48wVCzPviN7TLCu48AVNPQI7XGsiBr6e9pr39I397To9a35C0N3682046Kl4gGxHH4u9jldiiSp223tQM8h8hJx3Qx8G8nfIOhoFTra35w0jY4m6ZSrcnMRWu69PpAnwY7Y9c6yL40de9J2DrMtJXZWeS238" +
                    "Sa8XbTMFss2VlU66bb3L4JM87S4nT87sB693oOJMO50ut9Es21";
            }
            else if (str == "Diego")
            {
                connection = "";
            }

            return ValidarCodigo(connection);
        }

        public DbUsuarios DecodeUsuario(DbUsuarios objeto, bool state)
        {
            if (state == true)
            {
                objeto.Email = Cryptografia(objeto.Email);
                objeto.Telefone = Cryptografia(objeto.Telefone);
                objeto.EstadoCivil = Cryptografia(objeto.EstadoCivil);
                objeto.Nome = Cryptografia(objeto.Nome);
                objeto.Curso = Cryptografia(objeto.Curso);
                objeto.Escola = Cryptografia(objeto.Escola);
                objeto.Turno = Cryptografia(objeto.Turno);

                return objeto;
            }
            else
            {
                objeto.Email = ValidarCodigo(objeto.Email);
                objeto.Telefone = ValidarCodigo(objeto.Telefone);
                objeto.EstadoCivil = ValidarCodigo(objeto.EstadoCivil);
                objeto.Nome = ValidarCodigo(objeto.Nome);
                objeto.Curso = ValidarCodigo(objeto.Curso);
                objeto.Escola = ValidarCodigo(objeto.Escola);
                objeto.Turno = ValidarCodigo(objeto.Turno);
                return objeto;
            }
        }

        public List<DbUsuarios> DecodeListUsuarios(List<DbUsuarios> objetos, bool state)
        {
            List<DbUsuarios> usuarios = new List<DbUsuarios>();

            foreach (var item in objetos)
            {
                DbUsuarios objeto = new DbUsuarios();
                objeto = item;
                if (state == true)
                {
                    objeto.Email = Cryptografia(item.Email);
                    objeto.Telefone = Cryptografia(item.Telefone);
                    objeto.EstadoCivil = Cryptografia(item.EstadoCivil);
                    objeto.Nome = Cryptografia(item.Nome);
                    objeto.Curso = Cryptografia(item.Curso);
                    objeto.Escola = Cryptografia(item.Escola);
                    objeto.Turno = Cryptografia(item.Turno);

                    usuarios.Add(objeto);
                }
                else
                {
                    objeto.Email = ValidarCodigo(item.Email);
                    objeto.Telefone = ValidarCodigo(item.Telefone);
                    objeto.EstadoCivil = ValidarCodigo(item.EstadoCivil);
                    objeto.Nome = ValidarCodigo(item.Nome);
                    objeto.Curso = ValidarCodigo(item.Curso);
                    objeto.Escola = ValidarCodigo(item.Escola);
                    objeto.Turno = ValidarCodigo(item.Turno);

                    usuarios.Add(objeto);
                }
            }
            return usuarios;
        }

        public DbDados DecodeDados(DbDados objeto, bool state)
        {
            if (state == true)
            {
                objeto.NumMatricula = Cryptografia(objeto.NumMatricula);
                objeto.Senha = Cryptografia(objeto.Senha);
                objeto.Cpf = Cryptografia(objeto.Cpf);
             
                return objeto;
            }
            else
            {
                objeto.NumMatricula = ValidarCodigo(objeto.NumMatricula);
                objeto.Senha = ValidarCodigo(objeto.Senha);
                objeto.Cpf = ValidarCodigo(objeto.Cpf);
               
                return objeto;
            }
        }

        public List<DbDados> DecodeListDados(List<DbDados> objetos, bool state)
        {
            List<DbDados> dados = new List<DbDados>();

            foreach (var item in objetos)
            {
                DbDados objeto = new DbDados();
                objeto = item;
                if (state == true)
                {
                    objeto.NumMatricula = Cryptografia(item.NumMatricula);
                    objeto.Senha = Cryptografia(item.Senha);
                    objeto.Cpf = Cryptografia(item.Cpf);

                    dados.Add(objeto);
                }
                else
                {
                    objeto.NumMatricula = ValidarCodigo(item.NumMatricula);
                    objeto.Senha = ValidarCodigo(item.Senha);
                    objeto.Cpf = ValidarCodigo(item.Cpf);

                    dados.Add(objeto);
                }
            }
            return dados;
        }

        public DbEmpresas DecodeEmpresa(DbEmpresas objeto, bool state)
        {
            if (state == true)
            {
                objeto.Email = Cryptografia(objeto.Email);
                objeto.Telefone = Cryptografia(objeto.Telefone);
                objeto.Senha = Cryptografia(objeto.Senha);
                objeto.Nome = Cryptografia(objeto.Nome);
                objeto.RazaoSocial = Cryptografia(objeto.RazaoSocial);
                objeto.Cnpj = Cryptografia(objeto.Cnpj);
                objeto.NomeResponsavel = Cryptografia(objeto.NomeResponsavel);

                return objeto;
            }
            else
            {
                objeto.Email = ValidarCodigo(objeto.Email);
                objeto.Telefone = ValidarCodigo(objeto.Telefone);
                objeto.Senha = ValidarCodigo(objeto.Senha);
                objeto.Nome = ValidarCodigo(objeto.Nome);
                objeto.RazaoSocial = ValidarCodigo(objeto.RazaoSocial);
                objeto.Cnpj = ValidarCodigo(objeto.Cnpj);
                objeto.NomeResponsavel = ValidarCodigo(objeto.NomeResponsavel);
                return objeto;
            }
        }

        public List<DbEmpresas> DecodeListEmpresas(List<DbEmpresas> objetos, bool state)
        {
            List<DbEmpresas> empresas = new List<DbEmpresas>();

            foreach (var item in objetos)
            {
                DbEmpresas objeto = new DbEmpresas();
                objeto = item;
                if (state == true)
                {
                    objeto.Email = Cryptografia(item.Email);
                    objeto.Telefone = Cryptografia(item.Telefone);
                    objeto.Senha = Cryptografia(item.Senha);
                    objeto.Nome = Cryptografia(item.Nome);
                    objeto.RazaoSocial = Cryptografia(item.RazaoSocial);
                    objeto.Cnpj = Cryptografia(item.Cnpj);
                    objeto.NomeResponsavel = Cryptografia(item.NomeResponsavel);

                    empresas.Add(objeto);
                }
                else
                {
                    objeto.Email = ValidarCodigo(item.Email);
                    objeto.Telefone = ValidarCodigo(item.Telefone);
                    objeto.Senha = ValidarCodigo(item.Senha);
                    objeto.Nome = ValidarCodigo(item.Nome);
                    objeto.RazaoSocial = ValidarCodigo(item.RazaoSocial);
                    objeto.Cnpj = ValidarCodigo(item.Cnpj);
                    objeto.NomeResponsavel = ValidarCodigo(item.NomeResponsavel);
                    empresas.Add(objeto);
                }
            }
            return empresas;
        }
    }
}
