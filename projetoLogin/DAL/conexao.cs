using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetoLogin.DAL
{
    public class conexao
    {
        SqlConnection con = new SqlConnection();

        public conexao()
        {
            con.ConnectionString = @"Data Source=FERNANDO-BRENDA;Initial Catalog=PROJETOLogin;Integrated Security=True";
        }
        public SqlConnection conectar()
        {
            if (con.State == System.Data.ConectionState.Closed)
            {
                con.Open();
            }
            return con;
        }
        public void desconectar()
        {
            if (con.State == System.Data.ConectionState.Open)
            {
                con.Close();
            }
        }
    }
}
