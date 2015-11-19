using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoMVC.src.model;
namespace ProjetoMVC.src.controller
{
    class UsuarioBean
    {
        public Usuario usuario { get; set; }

        public UsuarioBean()
        {
            usuario = new Usuario();
        }
    }
}
