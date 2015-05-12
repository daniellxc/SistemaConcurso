using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace stack_concurso.domain.Acessorios
{
   public sealed class GenericSingleton<T> where T:class , new()
    {
        private static T _instance;

        public static T GetInstance()
        {
            lock (typeof(T))
            {
                if (_instance == null)
                    _instance = new T();

                return _instance;
            }
        }
    }
}
