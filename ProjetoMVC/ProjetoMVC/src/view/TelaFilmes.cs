using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoMVC.src.view
{
    public partial class TelaFilmes : Form
    {
        public TelaFilmes()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            String nome_filme = txtFilme.Text;
            String genero_filme = txtGenero.Text;

            //Conecta ao banco
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\aluno\Downloads\Projeto_12-11-2015-11-13\Projeto 12-11\Aula banco de dados1509\AulaBancoDeDados\AulaBancoDeDados\programa_cadastro.mdf;Integrated Security=True");
            SqlCommand command = new SqlCommand("Insert Into Filme(nome_filme, genero_filme) values(@nome, @genero)", conn);

            //Abre a conexão
            conn.Open();

            command.Parameters.AddWithValue("@nome", nome_filme);
            command.Parameters.AddWithValue("@genero", genero_filme);
            int gravou = command.ExecuteNonQuery();
            if (gravou > 0)
            {
                MessageBox.Show("Cadastrado com sucesso!");
            }
            else
            {
                MessageBox.Show("Não cadastrado!");
            }

            //Atualiza a gridview
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from Filme", conn);

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];

            //Fecha a conexão
            conn.Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Length > 0)
            {
                SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\aluno\Downloads\Projeto_12-11-2015-11-13\Projeto 12-11\Aula banco de dados1509\AulaBancoDeDados\AulaBancoDeDados\programa_cadastro.mdf;Integrated Security=True");
                SqlCommand command = new SqlCommand("update Filme set nome_filme = @nome, genero_filme = @genero where id_filme = @id", conn);
                String nome_filme = txtFilme.Text;
                String genero_filme = txtGenero.Text;
                conn.Open();
                command.Parameters.AddWithValue("@nome", nome_filme);
                command.Parameters.AddWithValue("@genero", genero_filme);
                command.Parameters.AddWithValue("@id", txtID.Text);

                //Verifica se editou
                int editou = command.ExecuteNonQuery();

                if (editou > 0)
                {
                    MessageBox.Show("!Editado com sucesso!");
                    txtID.Text = "";
                    txtFilme.Text = "";
                    txtGenero.Text = "";
                }
                else
                {
                    MessageBox.Show("Não Editado!");
                }

                SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from Filme", conn);

                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = ds.Tables[0];

                conn.Close();
            }
            else
            {
                MessageBox.Show("Selecione um registro antes de editar!");
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\aluno\Downloads\Projeto_12-11-2015-11-13\Projeto 12-11\Aula banco de dados1509\AulaBancoDeDados\AulaBancoDeDados\programa_cadastro.mdf;Integrated Security=True");
            SqlCommand command = new SqlCommand("delete from Filme where id_filme = @id", conn);
            String nome_filme = txtFilme.Text;
            String genero_filme = txtGenero.Text;
            conn.Open();
            command.Parameters.AddWithValue("@id", txtID.Text);

            //Verifica se excluiu
            int excluiu = command.ExecuteNonQuery();
            if (excluiu > 0)
            {
                MessageBox.Show("!Excluido com sucesso!");
            }
            else
            {
                MessageBox.Show("Não Excluido!");
            }

            SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from Filme", conn);

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];

            conn.Close();
        }

        // When select an item on the gridview appears in textbox the registers
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                txtID.Text = row.Cells[0].Value.ToString();
                txtFilme.Text = row.Cells[1].Value.ToString();
                txtGenero.Text = row.Cells[2].Value.ToString();

            }
        }
    }
}
