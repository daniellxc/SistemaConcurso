using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using stack_concurso.domain.Modelo;

namespace stack_concurso.domain.Acessorios
{
    public class Contexto
    {
        private entidades context;

        public entidades GetContexto()
        {
            lock (typeof(entidades))
                if (context == null)
                {
                    context = new entidades(new Connection().getConnection());
                    return context;
                }
                else
                    return context;
        }


    }
}
