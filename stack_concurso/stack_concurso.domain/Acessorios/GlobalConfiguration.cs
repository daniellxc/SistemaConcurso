using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace stack_concurso.domain.Acessorios
{
    public class GlobalConfiguration
    {
        #region header
        public static string empresa = "Serviço Nacional de Aprendizagem Comercial";
        public static string empresa_descricao = "Departamento Regional da Paraíba";
        #endregion
        
        #region bd
        public static String _bd_server_provider_name = "MySql.Data.MySqlClient";
        public static String _bd_server_base_name = "stack_concurso_sesc";
        private string _bd_server_path;
        private string _bd_server_login;
        private string _bd_server_password;

        public string Bd_server_path
        {
            get { return _bd_server_path; }
            set { _bd_server_path = value; }
        }
        public string Bd_server_login
        {
            get { return _bd_server_login; }
            set { _bd_server_login = value; }
        }
        public string Bd_server_password
        {
            get { return _bd_server_password; }
            set { _bd_server_password = value; }
        }

        public void getBDPath(String directory)
        {
            string nomeArquivo = System.IO.Path.GetDirectoryName(directory);
            try
            {               
                StreamReader rd = new StreamReader(nomeArquivo + "\\sql.dll");
                string linha = "";
                while (!rd.EndOfStream)
                {
                    linha = rd.ReadLine();
                    string[] teste = linha.Split('|');
                    _bd_server_path = teste[0];
                    _bd_server_login = teste[1];
                    _bd_server_password = teste[2];
                }
                rd.Close();
            }
            catch (Exception)
            {
                StreamWriter wr = new StreamWriter(nomeArquivo + "\\sql.dll", true);
                wr.WriteLine("localhost|admin|admin");
                _bd_server_path = "localhost";
                _bd_server_login = "admin";
                _bd_server_password = "admin";
            }
        }
        public void setBDPath(String directory)
        {
            try
            {
                string nomeArquivo = System.IO.Path.GetDirectoryName(directory);
                StreamWriter sw = new StreamWriter(nomeArquivo + "\\sql.dll",false);
                sw.WriteLine(_bd_server_path+"|"+_bd_server_login+"|"+_bd_server_password);
                sw.Close();
            }
            catch (IOException)
            {}
        }
        #endregion

    }
}
