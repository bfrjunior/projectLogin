using projetoLogin.apresentacao;
using projetoLogin.modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projetoLogin
{
    public partial class Form1 : Form
    {
        public object BemVindo { get; private set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCadastrese_Click(object sender, EventArgs e)
        {
            CadastreSe cad = new CadastreSe();
            cad.Show();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            Controle controle = new Controle();
            controle.acessar(txbLogin.Text, txbSenha.Text);

            if (controle.mensagem.Equals(""))
            {



                if (controle.tem)
                {
                    MessageBox.Show("Logado com Sucesso", "Entrando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BemVindo bv = new BemVindo();
                    bv.Show();
                }
                else
                {
                    MessageBox.Show("Login não encontrado,verifique login e senha", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(controle.mensagem);
            }
        }
    }
}
