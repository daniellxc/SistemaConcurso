using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using stack_concurso.domain.Modelo;

namespace stack_concurso.forms.acessorio
{
   public static class Sessao
    {
       private static tb_usuario _UsuarioLogado;

       public static tb_usuario UsuarioLogado
       {

           get
           {
               return _UsuarioLogado;
           }
           set
           {
               _UsuarioLogado = value;
           }
       }
    }
}
