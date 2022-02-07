using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetoLogin.DAL
{
    class LoginDaoComandos
    {
        public bool tem = false;
        public String mensagem = "";//tudo ok
        SqlCommand cmd = new SqlCommand();
        conexao con = new conexao();
        SqlDataReader dr;
        //verifica no mbando de dados
        public bool verificarLogin(String login, String senha)
        {
            tem = false;
            //comandos sql verificar o banco de dados

            cmd.CommandText = "select * from logins where email = @login and senha = @senha";
            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@senha", senha);


            try
            {
                cmd.Connection = con.conectar();
               dr = cmd.ExecuteReader();
                if (dr.HasRows)//se foi encontrado
                {
                    tem = true;
                }
                con.desconectar();
                dr.Close();
            }
            catch (SqlException)
            {

                this.mensagem = "Erro Com Banco de Dados!";
            }
            return tem;
        }
        public String cadastrar(String email, String senha, String confSenha)
        {
            //inserir no banco
            if (senha.Equals(confSenha))
            {
                cmd.CommandText = "insert into logins value(@e,@s);";
                cmd.Parameters.AddWithValue("@e", email);
                cmd.Parameters.AddWithValue("@s", senha);
                try
                {
                    cmd.Connection = con.conectar();
                    cmd.ExecuteNonQuery();
                    con.desconectar();
                    this.mensagem = "cadastrado com sucesso!";
                    tem = true;
                }
                catch (SqlException)
                {

                    this.mensagem = "Erro com Bando de Dados";
                }
            }else
            {
                this.mensagem = "Senhas não conrrespondem";
            }
            return mensagem;
        }
    }
}
