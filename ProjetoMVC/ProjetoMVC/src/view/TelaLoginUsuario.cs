using ProjetoMVC.src.persistencia;
using ProjetoMVC.src.view;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoMVC.src.view
{
    public partial class TelaLoginUsuario : Form
    {
        private PersistenciaUsuario persistenciaUsuario;
        public TelaLoginUsuario()
        {
            InitializeComponent();
            persistenciaUsuario = new PersistenciaUsuario();
        }

        private void btnLogar_Click(object sender, EventArgs e)
        {
            String login = txtLogin.Text;
            String senha = txtSenha.Text;
            if (persistenciaUsuario.buscarPorLoginESenha(login, senha))
            {
                MessageBox.Show("Logado com sucesso!");
                TelaFilmes telafilmes = new TelaFilmes();
                telafilmes.Show();
            }
            else
            {
                MessageBox.Show("login ou senha inválido.");
            }
        }
    }
}
