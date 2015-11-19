using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoMVC.src.controller
{
    class FilmeBean
    {
        public Filme filme { get; set; }

        public FilmeBean()
        {
            filme = new Filme();
        }
    }
}
