using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoMVC.src.model;
using System.Data.SqlClient;
using System.Data;
namespace ProjetoMVC.src.persistencia
{
    class UsuarioDAO
    {
        String conexao;
        String insere;
        String buscarloginsenha;
        String buscarnome;
        String buscatudo;
        SqlConnection conn;
        SqlCommand command;
        public UsuarioDAO()
        {
            conexao = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\aluno\Desktop\Projeto 1611\ProjetoMVCAtualizado\ProjetoMVC\ProjetoMVC\ProjetoMVC\src\database\DBUser.mdf;Integrated Security = True";
            insere = "Insert into Usuario(nome,login,senha,email,cpf) values (@nome,@login,@senha,@email,@cpf)";
            buscarloginsenha = "Select * from Usuario where login = @login and senha = @senha";
            buscatudo = "Select * from Usuario";
            buscarnome = "Select * from Usuario where nome = @nome";

        }

        public DataTable toDataTable(List<Usuario> usuarios)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Nome");
            dt.Columns.Add("Login");
            foreach (var item in usuarios)
            {
                var row = dt.NewRow();

                row["Nome"] = item.Nome;
                row["Login"] = item.Login;

                dt.Rows.Add(row);
            }

            return dt;
        }

        public int gravar(Usuario usuario)
        {
            conn = new SqlConnection(conexao);
            command = new SqlCommand(insere, conn);
            conn.Open();
            command.Parameters.AddWithValue("@nome", usuario.Nome);
            command.Parameters.AddWithValue("@login", usuario.Login);
            command.Parameters.AddWithValue("@senha", usuario.Senha);
            command.Parameters.AddWithValue("@cpf", usuario.cpf);
            command.Parameters.AddWithValue("@email", usuario.email);
            int gravou = command.ExecuteNonQuery();
            return gravou;
        }

        public void remover(Usuario usuario)
        {

        }

        public List<Usuario> findAll()
        {
            List<Usuario> usuarios = new List<Usuario>();
            conn = new SqlConnection(conexao);
            command = new SqlCommand(buscatudo, conn);
            conn.Open();
            var result = command.ExecuteReader();
            while(result.Read())
            {
                String nome = result["nome"].ToString();
                String login = result["login"].ToString();
                String senha = result["senha"].ToString();
                String email = result["email"].ToString();
                String cpf = result["cpf"].ToString();
                Usuario u = new Usuario();
                u.Nome = nome;
                u.Login = login;
                u.Senha = senha;
                u.cpf = cpf;
                u.email = email;

                usuarios.Add(u);
            }
            return usuarios;
        }


        public bool buscarPorLoginESenha(String login, String senha)
        {
            conn = new SqlConnection(conexao);
            command = new SqlCommand(buscarloginsenha, conn);
            conn.Open();
            command.Parameters.AddWithValue("@login", login);
            command.Parameters.AddWithValue("@senha", senha);
            var result = command.ExecuteReader();
            return result.HasRows;
        }

        public List<Usuario> buscarPorNome(String nomeuser)
        {
            List<Usuario> usuarios = new List<Usuario>();
            conn = new SqlConnection(conexao);
            command = new SqlCommand(buscarnome, conn);
            conn.Open();
            command.Parameters.AddWithValue("@nome", nomeuser);
            var result = command.ExecuteReader();
            while (result.Read())
            {
                String nome = result["nome"].ToString();
                String login = result["login"].ToString();
                String senha = result["senha"].ToString();
                Usuario u = new Usuario();
                u.Nome = nome;
                u.Login = login;
                u.Senha = senha;

                usuarios.Add(u);
            }
            return usuarios;
        }
    }
}
