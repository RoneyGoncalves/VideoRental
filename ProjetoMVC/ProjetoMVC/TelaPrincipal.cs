using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetoMVC.src.view;
namespace ProjetoMVC
{
    public partial class TelaPrincipal : Form
    {
        public TelaPrincipal()
        {
            InitializeComponent();
        }

        private void usuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelaCadastroUsuario telacad = new TelaCadastroUsuario();
            telacad.MdiParent = this;
            telacad.Show();
        }

        private void logarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelaLoginUsuario telalogin = new TelaLoginUsuario();
            telalogin.MdiParent = this;
            telalogin.Show();
        }

        private void porNomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelaBuscaNome telabuscanome = new TelaBuscaNome();
            telabuscanome.MdiParent = this;
            telabuscanome.Show();
        }

    }
}
