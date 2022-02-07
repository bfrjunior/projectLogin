using projetoLogin.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetoLogin.modelo
{
    public class Controle
    {
        public bool tem;
        public string mensagem = "";

        public bool acessar(String login, String senha)
        {
            LoginDaoComandos loginDao = new LoginDaoComandos();
           tem = loginDao.verificarLogin(login,senha);
            if (!loginDao.mensagem.Equals(""))//!negando
            {
                this.mensagem = loginDao.mensagem;
            }
            return tem;
        }

        internal string cadastrar(string text1, string text2, object text3)
        {
            throw new NotImplementedException();
        }

        public string cadastrar(String email, String seha, String confSenha)
        {
            LoginDaoComandos loginDao = new LoginDaoComandos();
            this.mensagem = loginDao.cadastrar(email, confSenha, confSenha);
            if (loginDao.tem)//mensagem de sucesso
            {
                this.tem = true;
            }
            return mensagem;
        }
    }
}