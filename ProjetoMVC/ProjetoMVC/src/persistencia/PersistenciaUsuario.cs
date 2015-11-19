using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoMVC.src.model;
using System.Data;
namespace ProjetoMVC.src.persistencia
{
    class PersistenciaUsuario
    {
        public UsuarioDAO usuarioDAO { get; set; }
        public PersistenciaUsuario()
        {
            usuarioDAO = new UsuarioDAO();
        }
        
        public int gravar(Usuario u)
        {
           return usuarioDAO.gravar(u);
        }

        public void remover(Usuario u)
        {
            usuarioDAO.remover(u);
        }

        public List<Usuario> findAll()
        {
            return usuarioDAO.findAll();
        }

        public bool buscarPorLoginESenha(String login, String senha)
        {
            return usuarioDAO.buscarPorLoginESenha(login,senha);
        }

        public DataTable toDataTable(List<Usuario> usuarios)
        {
            return usuarioDAO.toDataTable(usuarios);
        }

        public List<Usuario> buscarPorNome(String nome)
        {
            return usuarioDAO.buscarPorNome(nome);
        }
    }
}
