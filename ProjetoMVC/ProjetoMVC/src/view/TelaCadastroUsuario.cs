using ProjetoMVC.src.controller;
using ProjetoMVC.src.persistencia;
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
    public partial class TelaCadastroUsuario : Form
    {
        private UsuarioBean usuarioBean;
        private PersistenciaUsuario persistenciaUsuario;
        public TelaCadastroUsuario()
        {
            InitializeComponent();
            usuarioBean = new UsuarioBean();
            persistenciaUsuario = new PersistenciaUsuario();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String nome = txtNome.Text;
            String cpf = txtCpf.Text;
            String email = txtEmail.Text;
            String login = txtLogin.Text;
            String senha = txtSenha.Text;

            try
            {


                //Verifica Nome
                if (nome.Length > 50)
                {
                    MessageBox.Show("Nome muito longo!");
                    return;
                }
                else if (nome.Length == 0)
                {
                    MessageBox.Show("Nome vazio!");
                    return;
                }


                /*// VERIFICA CPF
                if (cpf.Length != 11)
                {
                    MessageBox.Show("CPF Inválido!");
                    return;
                }*/

                //Verifica email
                if (email.Length == 0)
                {
                    MessageBox.Show("E-mail vazio!");
                    return;
                }
                else if (email.Contains("@") && email.Contains(".com"))
                {

                }
                else
                {
                    MessageBox.Show("E-mail Inválido!");
                    return;
                }

                //Verifica senha
                if (senha.Length != 6)
                {
                    MessageBox.Show("Senha não contém 6 dígitos");
                    return;
                }


                if (login.Length > 50 || login.Length == 0)
                {
                    MessageBox.Show("Login inválido");
                    
                }

            }
            catch
            {
                MessageBox.Show("Cath");
            
            }

            usuarioBean.usuario.Nome = txtNome.Text.ToUpper().Trim();
            usuarioBean.usuario.cpf = txtCpf.Text;
            usuarioBean.usuario.email = txtEmail.Text.Trim();
            usuarioBean.usuario.Senha = txtSenha.Text;
            usuarioBean.usuario.Login = txtLogin.Text.ToUpper().Trim();
            int gravou = persistenciaUsuario.gravar(usuarioBean.usuario);

            if (gravou > 0)
            {
                MessageBox.Show("Gravado com sucesso!");
            }
            else
            {
                MessageBox.Show("Não gravou!");
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
