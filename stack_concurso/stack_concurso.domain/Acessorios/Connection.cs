using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.EntityClient;

namespace stack_concurso.domain.Acessorios
{
   public class Connection
    {
        //MySqlProvider => "MySql.Data.MySqlClient"

        private string providerName = "";
        private string serverName = "";
        private string databaseName = "";
        private string userId = "";
        private string password = "";

        /// <summary>
        /// Providers:
        /// MySql => MySql.Data.MySqlClient
        /// SqlServer => System.Data.SqlClient
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="server"></param>
        /// <param name="dbName"></param>
        public Connection(string provider, string server, string dbName, string user, string password)
        {
            this.providerName = provider;
            this.serverName = server;
            this.databaseName = dbName;
            this.userId = user;
            this.password = password;
        }

        public Connection()
        {           
            GlobalConfiguration global = GenericSingleton<GlobalConfiguration>.GetInstance();
            this.userId = global.Bd_server_login;
            this.password = global.Bd_server_password;
            this.serverName = global.Bd_server_path;
            this.providerName = GlobalConfiguration._bd_server_provider_name;
            this.databaseName = GlobalConfiguration._bd_server_base_name;
        }

        public string getConnection()
        {
            string providerString = "server=" + serverName + ";User Id=" + userId + ";password=" + password + ";database=" + databaseName;
            EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder();
            entityBuilder.Provider = providerName;
            entityBuilder.ProviderConnectionString = providerString;
            entityBuilder.Metadata = @"res://*/Modelo.modelo.csdl|res://*/Modelo.modelo.ssdl|res://*/Modelo.modelo.msl";

            return entityBuilder.ToString();
        }
    }
}
