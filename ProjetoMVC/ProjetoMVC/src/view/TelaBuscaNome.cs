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
    public partial class TelaBuscaNome : Form
    {
        PersistenciaUsuario persistenciausuario;
        public TelaBuscaNome()
        {
            persistenciausuario = new PersistenciaUsuario();
            InitializeComponent();
            dgvResultado.DataSource = bindingSource1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String nome = txtNome.Text;
            var usuarios = persistenciausuario.buscarPorNome(nome);
            var tabela = persistenciausuario.toDataTable(usuarios);
            bindingSource1.DataSource = tabela;
        }
    }
}
